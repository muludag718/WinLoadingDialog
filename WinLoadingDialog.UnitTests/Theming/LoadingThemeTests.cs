using NUnit.Framework;
using WinLoadingDialog.Theming;

namespace WinLoadingDialog.UnitTests.Theming;

[TestFixture]
[Apartment(ApartmentState.STA)]
public sealed class LoadingThemeTests
{
    [Test]
    public void Light_ResolvesLightPalette()
    {
        LoadingPalette palette = LoadingTheme.Light.Resolve();

        Assert.That(palette.CardBackColor, Is.EqualTo(LoadingPalette.Light.CardBackColor));
    }

    [Test]
    public void Dark_ResolvesDarkPalette()
    {
        LoadingPalette palette = LoadingTheme.Dark.Resolve();

        Assert.That(palette.CardBackColor, Is.EqualTo(LoadingPalette.Dark.CardBackColor));
    }

    [Test]
    public void FromPalette_ResolvesCustomPalette()
    {
        LoadingPalette custom = new()
        {
            OverlayBackColor = Color.FromArgb(100, 1, 2, 3),
            CardBackColor = Color.Red,
            CardBorderColor = Color.Blue,
            TitleForeColor = Color.White,
            MessageForeColor = Color.Gray,
            SpinnerColor = Color.Green,
            SpinnerTrackColor = Color.Yellow,
            SuccessColor = Color.Lime,
            ErrorColor = Color.Pink
        };

        LoadingTheme theme = LoadingTheme.FromPalette(custom);

        LoadingPalette resolved = theme.Resolve();

        Assert.That(resolved.CardBackColor, Is.EqualTo(Color.Red));
    }

    [Test]
    public void System_UsesDarkPaletteForDarkTarget()
    {
        using Panel panel = new()
        {
            BackColor = Color.FromArgb(30, 30, 30)
        };

        LoadingPalette palette = LoadingTheme.System.Resolve(panel);

        Assert.That(palette.CardBackColor, Is.EqualTo(LoadingPalette.Dark.CardBackColor));
    }

    [Test]
    public void System_UsesLightPaletteForLightTarget()
    {
        using Panel panel = new()
        {
            BackColor = Color.White
        };

        LoadingPalette palette = LoadingTheme.System.Resolve(panel);

        Assert.That(palette.CardBackColor, Is.EqualTo(LoadingPalette.Light.CardBackColor));
    }
}