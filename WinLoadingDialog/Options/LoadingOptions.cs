using WinLoadingDialog.Controls;
using WinLoadingDialog.Localization;
using WinLoadingDialog.Theming;

namespace WinLoadingDialog.Options;

/// <summary>
/// Defines the visual and behavioral options for a loading overlay.
/// </summary>
public sealed class LoadingOptions
{
    public string? Title { get; init; }

    public string? Message { get; init; }

    public string? SuccessTitle { get; init; }

    public string? SuccessMessage { get; init; }

    public string? ErrorTitle { get; init; }

    public string? ErrorMessage { get; init; }

    public LoadingTexts Texts { get; init; } = LoadingDefaults.Texts;

    public LoadingTheme Theme { get; init; } = LoadingDefaults.Theme;

    public SpinnerMode SpinnerMode { get; init; } = LoadingDefaults.SpinnerMode;

    public int SuccessAutoCloseDelayMs { get; init; } = LoadingDefaults.SuccessAutoCloseDelayMs;

    public int ErrorAutoCloseDelayMs { get; init; } = LoadingDefaults.ErrorAutoCloseDelayMs;

    public bool BlockInput { get; init; } = true;

    public bool ShowCard { get; init; } = true;

    public static LoadingOptions Default { get; } = new();

    public string ResolveLoadingTitle()
    {
        return UseOrDefault(Title, Texts.LoadingTitle);
    }

    public string ResolveLoadingMessage()
    {
        return UseOrDefault(Message, Texts.LoadingMessage);
    }

    public string ResolveSuccessTitle()
    {
        return UseOrDefault(SuccessTitle, Texts.SuccessTitle);
    }

    public string ResolveSuccessMessage()
    {
        return UseOrDefault(SuccessMessage, Texts.SuccessMessage);
    }

    public string ResolveErrorTitle()
    {
        return UseOrDefault(ErrorTitle, Texts.ErrorTitle);
    }

    public string ResolveErrorMessage()
    {
        return UseOrDefault(ErrorMessage, Texts.ErrorMessage);
    }

    public int ResolveSuccessAutoCloseDelayMs()
    {
        return Math.Max(0, SuccessAutoCloseDelayMs);
    }

    public int ResolveErrorAutoCloseDelayMs()
    {
        return Math.Max(0, ErrorAutoCloseDelayMs);
    }

    public LoadingOptions WithMessage(string? message, string? title = null)
    {
        return new LoadingOptions
        {
            Title = title ?? Title,
            Message = message ?? Message,
            SuccessTitle = SuccessTitle,
            SuccessMessage = SuccessMessage,
            ErrorTitle = ErrorTitle,
            ErrorMessage = ErrorMessage,
            Texts = Texts,
            Theme = Theme,
            SpinnerMode = SpinnerMode,
            SuccessAutoCloseDelayMs = SuccessAutoCloseDelayMs,
            ErrorAutoCloseDelayMs = ErrorAutoCloseDelayMs,
            BlockInput = BlockInput,
            ShowCard = ShowCard
        };
    }

    public LoadingOptions WithSuccess(string? message = null, string? title = null)
    {
        return new LoadingOptions
        {
            Title = Title,
            Message = Message,
            SuccessTitle = title ?? SuccessTitle,
            SuccessMessage = message ?? SuccessMessage,
            ErrorTitle = ErrorTitle,
            ErrorMessage = ErrorMessage,
            Texts = Texts,
            Theme = Theme,
            SpinnerMode = SpinnerMode,
            SuccessAutoCloseDelayMs = SuccessAutoCloseDelayMs,
            ErrorAutoCloseDelayMs = ErrorAutoCloseDelayMs,
            BlockInput = BlockInput,
            ShowCard = ShowCard
        };
    }

    public LoadingOptions WithError(string? message = null, string? title = null)
    {
        return new LoadingOptions
        {
            Title = Title,
            Message = Message,
            SuccessTitle = SuccessTitle,
            SuccessMessage = SuccessMessage,
            ErrorTitle = title ?? ErrorTitle,
            ErrorMessage = message ?? ErrorMessage,
            Texts = Texts,
            Theme = Theme,
            SpinnerMode = SpinnerMode,
            SuccessAutoCloseDelayMs = SuccessAutoCloseDelayMs,
            ErrorAutoCloseDelayMs = ErrorAutoCloseDelayMs,
            BlockInput = BlockInput,
            ShowCard = ShowCard
        };
    }

    private static string UseOrDefault(string? value, string fallback)
    {
        return string.IsNullOrWhiteSpace(value)
            ? fallback
            : value;
    }
}