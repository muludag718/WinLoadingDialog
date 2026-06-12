using WinLoadingDialog.Options;

namespace WinLoadingDialog.UI;


/// <summary>
/// Coordinates loading state changes and updates the overlay view.
/// </summary>
internal sealed class LoadingOverlayPresenter : IDisposable
{
    private readonly Control _target;
    private readonly ILoadingOverlayView _view;

    private LoadingOptions _currentOptions = LoadingOptions.Default;
    private bool _disposed;

    internal LoadingOverlayPresenter(Control target, ILoadingOverlayView view)
    {
        _target = target ?? throw new ArgumentNullException(nameof(target));
        _view = view ?? throw new ArgumentNullException(nameof(view));

        _view.Closed += View_Closed;
    }

    internal event EventHandler? Closed;

    internal event EventHandler? Disposed;

    internal Control Target => _target;

    internal bool IsDisposed => _disposed;

    internal void ShowLoading(LoadingOptions options)
    {
        if (!CanUse())
            return;

        _currentOptions = options ?? LoadingOptions.Default;

        LoadingOverlayViewModel model =
            LoadingOverlayViewModel.Loading(_target, _currentOptions);

        _view.Attach(_target);
        _view.Render(model);
        _view.ShowAnimated();
    }

    internal void Update(LoadingOptions options)
    {
        if (!CanUse())
            return;

        _currentOptions = options ?? _currentOptions;

        LoadingOverlayViewModel model =
            LoadingOverlayViewModel.Loading(_target, _currentOptions);

        _view.Render(model);
    }

    internal void Success(LoadingOptions options)
    {
        if (!CanUse())
            return;

        _currentOptions = options ?? _currentOptions;

        LoadingOverlayViewModel model =
            LoadingOverlayViewModel.Success(_target, _currentOptions);

        _view.Attach(_target);
        _view.Render(model);
        _view.ShowAnimated();
    }

    internal void Error(LoadingOptions options)
    {
        if (!CanUse())
            return;

        _currentOptions = options ?? _currentOptions;

        LoadingOverlayViewModel model =
            LoadingOverlayViewModel.Error(_target, _currentOptions);

        _view.Attach(_target);
        _view.Render(model);
        _view.ShowAnimated();
    }

    internal void Hide()
    {
        if (_disposed)
            return;

        _view.HideAnimated();
    }

    internal void HideImmediate()
    {
        if (_disposed)
            return;

        _view.HideImmediate();
    }

    private bool CanUse()
    {
        return !_disposed &&
               !_target.IsDisposed &&
               !_target.Disposing &&
               !_view.IsReleased;
    }

    private void View_Closed(object? sender, EventArgs e)
    {
        Closed?.Invoke(this, EventArgs.Empty);
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        _disposed = true;

        _view.Closed -= View_Closed;

        if (!_view.IsReleased)
            _view.Release();

        _view.Dispose();

        Disposed?.Invoke(this, EventArgs.Empty);
    }
}
