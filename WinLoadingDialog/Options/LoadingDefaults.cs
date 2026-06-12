using WinLoadingDialog.Controls;
using WinLoadingDialog.Localization;
using WinLoadingDialog.Theming;

namespace WinLoadingDialog.Options;

/// <summary>
/// Default values used by WinLoadingDialog when no custom options are provided.
/// </summary>
public static class LoadingDefaults
{
    public const int SuccessAutoCloseDelayMs = 900;

    public const int ErrorAutoCloseDelayMs = 1300;

    public const int FadeTimerIntervalMs = 15;

    public const int DefaultCardCornerRadius = 22;

    public const int DefaultOverlayAlpha = 64;

    public static LoadingTexts Texts { get; } = LoadingTexts.English;

    public static LoadingTheme Theme { get; } = LoadingTheme.System;

    public static SpinnerMode SpinnerMode { get; } = SpinnerMode.Arc;
}