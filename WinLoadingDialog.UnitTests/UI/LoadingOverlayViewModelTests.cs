using NUnit.Framework;
using WinLoadingDialog.Controls;
using WinLoadingDialog.Localization;
using WinLoadingDialog.Models;
using WinLoadingDialog.Options;
using WinLoadingDialog.Theming;
using WinLoadingDialog.UI;

namespace WinLoadingDialog.UnitTests.UI;

[TestFixture]
[Apartment(ApartmentState.STA)]
public sealed class LoadingOverlayViewModelTests
{
    [Test]
    public void Loading_CreatesLoadingViewModel()
    {
        using Panel target = new();

        LoadingOptions options = new()
        {
            Message = "Loading test",
            SpinnerMode = SpinnerMode.Bars,
            Theme = LoadingTheme.Light
        };

        LoadingOverlayViewModel model =
            LoadingOverlayViewModel.Loading(target, options);

        Assert.Multiple(() =>
        {
            Assert.That(model.State, Is.EqualTo(LoadingVisualState.Loading));
            Assert.That(model.Title, Is.EqualTo("Loading"));
            Assert.That(model.Message, Is.EqualTo("Loading test"));
            Assert.That(model.SpinnerMode, Is.EqualTo(SpinnerMode.Bars));
            Assert.That(model.AutoCloseDelayMs, Is.EqualTo(0));
            Assert.That(model.BlockInput, Is.True);
            Assert.That(model.ShowCard, Is.True);
        });
    }

    [Test]
    public void Success_CreatesSuccessViewModel()
    {
        using Panel target = new();

        LoadingOptions options = new()
        {
            SuccessTitle = "Saved",
            SuccessMessage = "Done",
            SuccessAutoCloseDelayMs = 500
        };

        LoadingOverlayViewModel model =
            LoadingOverlayViewModel.Success(target, options);

        Assert.Multiple(() =>
        {
            Assert.That(model.State, Is.EqualTo(LoadingVisualState.Success));
            Assert.That(model.Title, Is.EqualTo("Saved"));
            Assert.That(model.Message, Is.EqualTo("Done"));
            Assert.That(model.AutoCloseDelayMs, Is.EqualTo(500));
        });
    }

    [Test]
    public void Error_CreatesErrorViewModel()
    {
        using Panel target = new();

        LoadingOptions options = new()
        {
            ErrorTitle = "Failed",
            ErrorMessage = "Broken",
            ErrorAutoCloseDelayMs = 700
        };

        LoadingOverlayViewModel model =
            LoadingOverlayViewModel.Error(target, options);

        Assert.Multiple(() =>
        {
            Assert.That(model.State, Is.EqualTo(LoadingVisualState.Error));
            Assert.That(model.Title, Is.EqualTo("Failed"));
            Assert.That(model.Message, Is.EqualTo("Broken"));
            Assert.That(model.AutoCloseDelayMs, Is.EqualTo(700));
        });
    }

    [Test]
    public void Loading_UsesTurkishTexts()
    {
        using Panel target = new();

        LoadingOptions options = new()
        {
            Texts = LoadingTexts.Turkish
        };

        LoadingOverlayViewModel model =
            LoadingOverlayViewModel.Loading(target, options);

        Assert.Multiple(() =>
        {
            Assert.That(model.Title, Is.EqualTo("Yükleniyor"));
            Assert.That(model.Message, Is.EqualTo("Lütfen bekleyin..."));
        });
    }

    [Test]
    public void Loading_ResolvesThemePalette()
    {
        using Panel target = new();

        LoadingOptions options = new()
        {
            Theme = LoadingTheme.Dark
        };

        LoadingOverlayViewModel model =
            LoadingOverlayViewModel.Loading(target, options);

        Assert.That(model.Palette.CardBackColor, Is.EqualTo(LoadingPalette.Dark.CardBackColor));
    }
}