namespace WinLoadingDialog.Core;

/// <summary>
/// Disposable scope returned by LoadingService.Begin.
/// </summary>
internal sealed class LoadingScope : IDisposable
{
    private readonly LoadingSessionManager _manager;
    private readonly Control _target;

    private int _disposed;

    internal LoadingScope(LoadingSessionManager manager, Control target)
    {
        _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        _target = target ?? throw new ArgumentNullException(nameof(target));
    }

    public void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) == 1)
            return;

        _manager.Hide(_target);
    }
}