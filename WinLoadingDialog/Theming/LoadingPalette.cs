using System.Drawing;

namespace WinLoadingDialog.Theming;

public sealed class LoadingPalette
{
    public Color OverlayBackColor { get; init; }

    public Color CardBackColor { get; init; }

    public Color CardBorderColor { get; init; }

    public Color TitleForeColor { get; init; }

    public Color MessageForeColor { get; init; }

    public Color SpinnerColor { get; init; }

    public Color SpinnerTrackColor { get; init; }

    public Color SuccessColor { get; init; }

    public Color ErrorColor { get; init; }

    public static LoadingPalette Light { get; } = new()
    {
        OverlayBackColor = Color.FromArgb(64, 0, 0, 0),
        CardBackColor = Color.White,
        CardBorderColor = Color.FromArgb(225, 225, 225),
        TitleForeColor = Color.FromArgb(32, 32, 32),
        MessageForeColor = Color.FromArgb(88, 88, 88),
        SpinnerColor = Color.FromArgb(0, 122, 204),
        SpinnerTrackColor = Color.FromArgb(220, 220, 220),
        SuccessColor = Color.FromArgb(46, 160, 67),
        ErrorColor = Color.FromArgb(220, 53, 69)
    };

    public static LoadingPalette Dark { get; } = new()
    {
        OverlayBackColor = Color.FromArgb(150, 0, 0, 0),
        CardBackColor = Color.FromArgb(38, 38, 38),
        CardBorderColor = Color.FromArgb(70, 70, 70),
        TitleForeColor = Color.White,
        MessageForeColor = Color.FromArgb(210, 210, 210),
        SpinnerColor = Color.FromArgb(80, 170, 255),
        SpinnerTrackColor = Color.FromArgb(80, 80, 80),
        SuccessColor = Color.FromArgb(75, 201, 125),
        ErrorColor = Color.FromArgb(255, 100, 110)
    };
}