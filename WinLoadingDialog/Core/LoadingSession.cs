using WinLoadingDialog.Options;
using WinLoadingDialog.UI;

namespace WinLoadingDialog.Core;

/// <summary>
/// Represents one loading overlay session attached to a single target control.
/// </summary>
internal sealed class LoadingSession : IDisposable
{
    private readonly LoadingOverlayPresenter _presenter;

    private bool _disposed;

    internal LoadingSession(Control target)
    {
        Target = target ?? throw new ArgumentNullException(nameof(target));

        _presenter = new LoadingOverlayPresenter(
            Target,
            new LoadingOverlay());

        _presenter.Closed += Presenter_Closed;
        _presenter.Disposed += Presenter_Disposed;

        Target.Disposed += Target_Disposed;
    }

    internal Control Target { get; }

    internal int Depth { get; private set; }

    internal bool IsDisposed => _disposed;

    internal event EventHandler? Closed;

    internal event EventHandler? Disposed;

    internal void Show(LoadingOptions options)
    {
        if (!CanUse())
            return;

        Depth++;

        _presenter.ShowLoading(options ?? LoadingOptions.Default);
    }

    internal void Update(LoadingOptions options)
    {
        if (!CanUse())
            return;

        _presenter.Update(options ?? LoadingOptions.Default);
    }

    internal void Success(LoadingOptions options)
    {
        if (!CanUse())
            return;

        Depth = 0;

        _presenter.Success(options ?? LoadingOptions.Default);
    }

    internal void Error(LoadingOptions options)
    {
        if (!CanUse())
            return;

        Depth = 0;

        _presenter.Error(options ?? LoadingOptions.Default);
    }

    internal void Hide()
    {
        if (!CanUse())
            return;

        if (Depth > 0)
            Depth--;

        if (Depth > 0)
            return;

        Depth = 0;

        _presenter.Hide();
    }

    internal void HideImmediate()
    {
        if (!CanUse())
            return;

        Depth = 0;

        _presenter.HideImmediate();
    }

    private bool CanUse()
    {
        return !_disposed &&
               !Target.IsDisposed &&
               !Target.Disposing &&
               !_presenter.IsDisposed;
    }

    private void Presenter_Closed(object? sender, EventArgs e)
    {
        Depth = 0;
        Closed?.Invoke(this, EventArgs.Empty);
    }

    private void Presenter_Disposed(object? sender, EventArgs e)
    {
        Dispose();
    }

    private void Target_Disposed(object? sender, EventArgs e)
    {
        Dispose();
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        _disposed = true;

        Target.Disposed -= Target_Disposed;

        _presenter.Closed -= Presenter_Closed;
        _presenter.Disposed -= Presenter_Disposed;

        _presenter.Dispose();

        Disposed?.Invoke(this, EventArgs.Empty);
    }
}