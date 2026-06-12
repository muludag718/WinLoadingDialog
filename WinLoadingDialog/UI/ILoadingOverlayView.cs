namespace WinLoadingDialog.UI;

/// <summary>
/// Contract implemented by the WinForms overlay view.
/// </summary>
internal interface ILoadingOverlayView : IDisposable
{
    event EventHandler? Closed;

    bool IsReleased { get; }

    void Attach(Control target);

    void Render(LoadingOverlayViewModel model);

    void ShowAnimated();

    void HideAnimated();

    void HideImmediate();

    void Release();
}
