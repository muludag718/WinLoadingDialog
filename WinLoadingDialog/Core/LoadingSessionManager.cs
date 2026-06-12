using WinLoadingDialog.Options;

namespace WinLoadingDialog.Core;

/// <summary>
/// Manages loading sessions per target control.
/// </summary>
internal sealed class LoadingSessionManager
{
    private readonly object _sync = new();
    private readonly Dictionary<Control, LoadingSession> _sessions = new();

    private Control? _lastTarget;

    internal void Show(Control target, LoadingOptions options)
    {
        if (!CanUseTarget(target))
            return;

        UiDispatcher.Execute(target, () =>
        {
            LoadingSession session;

            lock (_sync)
            {
                session = GetOrCreateSessionOnUiThread(target);
            }

            session.Show(options ?? LoadingOptions.Default);
        });
    }

    internal void Update(Control target, LoadingOptions options)
    {
        if (!CanUseTarget(target))
            return;

        UiDispatcher.Execute(target, () =>
        {
            LoadingSession? session;

            lock (_sync)
            {
                session = TryGetSessionNoLock(target);
            }

            session?.Update(options ?? LoadingOptions.Default);
        });
    }

    internal void UpdateLast(LoadingOptions options)
    {
        LoadingSession? session = TryGetLastSession();

        if (session == null)
            return;

        UiDispatcher.Execute(session.Target, () =>
        {
            if (!session.IsDisposed)
                session.Update(options ?? LoadingOptions.Default);
        });
    }

    internal void Success(Control target, LoadingOptions options)
    {
        if (!CanUseTarget(target))
            return;

        UiDispatcher.Execute(target, () =>
        {
            LoadingSession session;

            lock (_sync)
            {
                session = GetOrCreateSessionOnUiThread(target);
            }

            session.Success(options ?? LoadingOptions.Default);
        });
    }

    internal void SuccessLast(LoadingOptions options)
    {
        LoadingSession? session = TryGetLastSession();

        if (session == null)
            return;

        UiDispatcher.Execute(session.Target, () =>
        {
            if (!session.IsDisposed)
                session.Success(options ?? LoadingOptions.Default);
        });
    }

    internal void Error(Control target, LoadingOptions options)
    {
        if (!CanUseTarget(target))
            return;

        UiDispatcher.Execute(target, () =>
        {
            LoadingSession session;

            lock (_sync)
            {
                session = GetOrCreateSessionOnUiThread(target);
            }

            session.Error(options ?? LoadingOptions.Default);
        });
    }

    internal void ErrorLast(LoadingOptions options)
    {
        LoadingSession? session = TryGetLastSession();

        if (session == null)
            return;

        UiDispatcher.Execute(session.Target, () =>
        {
            if (!session.IsDisposed)
                session.Error(options ?? LoadingOptions.Default);
        });
    }

    internal void Hide(Control target)
    {
        if (!CanUseTarget(target))
            return;

        UiDispatcher.Execute(target, () =>
        {
            LoadingSession? session;

            lock (_sync)
            {
                session = TryGetSessionNoLock(target);
            }

            session?.Hide();
        });
    }

    internal void HideLast()
    {
        LoadingSession? session = TryGetLastSession();

        if (session == null)
            return;

        UiDispatcher.Execute(session.Target, () =>
        {
            if (!session.IsDisposed)
                session.Hide();
        });
    }

    internal void ForceDispose(Control target)
    {
        if (target == null)
            return;

        LoadingSession? session;

        lock (_sync)
        {
            session = TryGetSessionNoLock(target);
        }

        if (session == null)
            return;

        UiDispatcher.Execute(session.Target, () =>
        {
            DisposeSession(session);
        });
    }

    internal void ForceDisposeAll()
    {
        List<LoadingSession> sessions;

        lock (_sync)
        {
            sessions = _sessions.Values.ToList();
        }

        foreach (LoadingSession session in sessions)
        {
            if (session.Target.IsDisposed || session.Target.Disposing)
            {
                DisposeSession(session);
                continue;
            }

            UiDispatcher.Execute(session.Target, () =>
            {
                DisposeSession(session);
            });
        }
    }

    internal IDisposable Begin(Control target, LoadingOptions options)
    {
        Show(target, options ?? LoadingOptions.Default);

        return new LoadingScope(this, target);
    }

    private LoadingSession GetOrCreateSessionOnUiThread(Control target)
    {
        CleanupDeadSessionsNoLock();

        if (_sessions.TryGetValue(target, out LoadingSession? existing) &&
            !existing.IsDisposed)
        {
            _lastTarget = target;
            return existing;
        }

        LoadingSession session = new(target);

        session.Closed += Session_Closed;
        session.Disposed += Session_Disposed;

        _sessions[target] = session;
        _lastTarget = target;

        return session;
    }

    private LoadingSession? TryGetSessionNoLock(Control target)
    {
        CleanupDeadSessionsNoLock();

        if (_sessions.TryGetValue(target, out LoadingSession? session) &&
            !session.IsDisposed)
        {
            _lastTarget = target;
            return session;
        }

        return null;
    }

    private LoadingSession? TryGetLastSession()
    {
        lock (_sync)
        {
            CleanupDeadSessionsNoLock();

            if (_lastTarget != null &&
                _sessions.TryGetValue(_lastTarget, out LoadingSession? last) &&
                !last.IsDisposed)
            {
                return last;
            }

            LoadingSession? fallback = _sessions.Values
                .LastOrDefault(session => !session.IsDisposed);

            if (fallback != null)
                _lastTarget = fallback.Target;

            return fallback;
        }
    }

    private void Session_Closed(object? sender, EventArgs e)
    {
        if (sender is LoadingSession session)
            DisposeSession(session);
    }

    private void Session_Disposed(object? sender, EventArgs e)
    {
        if (sender is LoadingSession session)
            RemoveSession(session);
    }

    private void DisposeSession(LoadingSession session)
    {
        RemoveSession(session);

        if (!session.IsDisposed)
            session.Dispose();
    }

    private void RemoveSession(LoadingSession session)
    {
        lock (_sync)
        {
            Control? removeKey = null;

            foreach (KeyValuePair<Control, LoadingSession> pair in _sessions)
            {
                if (ReferenceEquals(pair.Value, session))
                {
                    removeKey = pair.Key;
                    break;
                }
            }

            if (removeKey != null)
            {
                _sessions.Remove(removeKey);

                if (ReferenceEquals(_lastTarget, removeKey))
                {
                    _lastTarget = _sessions.Keys.LastOrDefault();
                }
            }
        }
    }

    private void CleanupDeadSessionsNoLock()
    {
        List<Control> deadTargets = new();

        foreach (KeyValuePair<Control, LoadingSession> pair in _sessions)
        {
            if (pair.Key.IsDisposed ||
                pair.Key.Disposing ||
                pair.Value.IsDisposed)
            {
                deadTargets.Add(pair.Key);
            }
        }

        foreach (Control target in deadTargets)
        {
            if (_sessions.TryGetValue(target, out LoadingSession? session) &&
                !session.IsDisposed)
            {
                session.Dispose();
            }

            _sessions.Remove(target);
        }

        if (_lastTarget != null &&
            (!_sessions.ContainsKey(_lastTarget) ||
             _lastTarget.IsDisposed ||
             _lastTarget.Disposing))
        {
            _lastTarget = _sessions.Keys.LastOrDefault();
        }
    }

    private static bool CanUseTarget(Control? target)
    {
        return target != null &&
               !target.IsDisposed &&
               !target.Disposing;
    }
}