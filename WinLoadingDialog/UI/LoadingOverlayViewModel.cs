using WinLoadingDialog.Controls;
using WinLoadingDialog.Models;
using WinLoadingDialog.Options;
using WinLoadingDialog.Theming;

namespace WinLoadingDialog.UI;

/// <summary>
/// Contains the resolved visual data that the overlay view needs to render.
/// </summary>
internal sealed class LoadingOverlayViewModel
{
    public LoadingVisualState State { get; init; } = LoadingVisualState.Loading;

    public string Title { get; init; } = string.Empty;

    public string Message { get; init; } = string.Empty;

    public LoadingPalette Palette { get; init; } = LoadingPalette.Light;

    public SpinnerMode SpinnerMode { get; init; } = SpinnerMode.Arc;

    public int AutoCloseDelayMs { get; init; }

    public bool BlockInput { get; init; } = true;

    public bool ShowCard { get; init; } = true;

    public static LoadingOverlayViewModel Loading(Control target, LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        return new LoadingOverlayViewModel
        {
            State = LoadingVisualState.Loading,
            Title = options.ResolveLoadingTitle(),
            Message = options.ResolveLoadingMessage(),
            Palette = options.Theme.Resolve(target),
            SpinnerMode = options.SpinnerMode,
            AutoCloseDelayMs = 0,
            BlockInput = options.BlockInput,
            ShowCard = options.ShowCard
        };
    }

    public static LoadingOverlayViewModel Success(Control target, LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        return new LoadingOverlayViewModel
        {
            State = LoadingVisualState.Success,
            Title = options.ResolveSuccessTitle(),
            Message = options.ResolveSuccessMessage(),
            Palette = options.Theme.Resolve(target),
            SpinnerMode = options.SpinnerMode,
            AutoCloseDelayMs = options.ResolveSuccessAutoCloseDelayMs(),
            BlockInput = options.BlockInput,
            ShowCard = options.ShowCard
        };
    }

    public static LoadingOverlayViewModel Error(Control target, LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        return new LoadingOverlayViewModel
        {
            State = LoadingVisualState.Error,
            Title = options.ResolveErrorTitle(),
            Message = options.ResolveErrorMessage(),
            Palette = options.Theme.Resolve(target),
            SpinnerMode = options.SpinnerMode,
            AutoCloseDelayMs = options.ResolveErrorAutoCloseDelayMs(),
            BlockInput = options.BlockInput,
            ShowCard = options.ShowCard
        };
    }

    public LoadingOverlayViewModel WithLoadingMessage(Control target, LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        return new LoadingOverlayViewModel
        {
            State = LoadingVisualState.Loading,
            Title = options.ResolveLoadingTitle(),
            Message = options.ResolveLoadingMessage(),
            Palette = options.Theme.Resolve(target),
            SpinnerMode = options.SpinnerMode,
            AutoCloseDelayMs = 0,
            BlockInput = options.BlockInput,
            ShowCard = options.ShowCard
        };
    }
}
