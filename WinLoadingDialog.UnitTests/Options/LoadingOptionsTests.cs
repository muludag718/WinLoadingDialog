using NUnit.Framework;
using WinLoadingDialog.Controls;
using WinLoadingDialog.Localization;
using WinLoadingDialog.Options;
using WinLoadingDialog.Theming;

namespace WinLoadingDialog.UnitTests.Options;

[TestFixture]
public sealed class LoadingOptionsTests
{
    [Test]
    public void Default_UsesEnglishTexts()
    {
        LoadingOptions options = LoadingOptions.Default;

        Assert.Multiple(() =>
        {
            Assert.That(options.ResolveLoadingTitle(), Is.EqualTo("Loading"));
            Assert.That(options.ResolveLoadingMessage(), Is.EqualTo("Please wait..."));
            Assert.That(options.ResolveSuccessTitle(), Is.EqualTo("Completed"));
            Assert.That(options.ResolveErrorTitle(), Is.EqualTo("Error"));
        });
    }

    [Test]
    public void TurkishTexts_ResolveTurkishValues()
    {
        LoadingOptions options = new()
        {
            Texts = LoadingTexts.Turkish
        };

        Assert.Multiple(() =>
        {
            Assert.That(options.ResolveLoadingTitle(), Is.EqualTo("Yükleniyor"));
            Assert.That(options.ResolveLoadingMessage(), Is.EqualTo("Lütfen bekleyin..."));
            Assert.That(options.ResolveSuccessTitle(), Is.EqualTo("Tamamlandı"));
            Assert.That(options.ResolveErrorTitle(), Is.EqualTo("Hata"));
        });
    }

    [Test]
    public void ExplicitMessage_OverridesTextFallback()
    {
        LoadingOptions options = new()
        {
            Message = "Custom loading message"
        };

        Assert.That(options.ResolveLoadingMessage(), Is.EqualTo("Custom loading message"));
    }

    [Test]
    public void NegativeAutoCloseDelay_ResolvesToZero()
    {
        LoadingOptions options = new()
        {
            SuccessAutoCloseDelayMs = -500,
            ErrorAutoCloseDelayMs = -900
        };

        Assert.Multiple(() =>
        {
            Assert.That(options.ResolveSuccessAutoCloseDelayMs(), Is.EqualTo(0));
            Assert.That(options.ResolveErrorAutoCloseDelayMs(), Is.EqualTo(0));
        });
    }

    [Test]
    public void WithMessage_PreservesOtherOptions()
    {
        LoadingOptions original = new()
        {
            Theme = LoadingTheme.Dark,
            Texts = LoadingTexts.Turkish,
            SpinnerMode = SpinnerMode.DualRing,
            BlockInput = false,
            ShowCard = false
        };

        LoadingOptions updated = original.WithMessage("New message", "New title");

        Assert.Multiple(() =>
        {
            Assert.That(updated.ResolveLoadingMessage(), Is.EqualTo("New message"));
            Assert.That(updated.ResolveLoadingTitle(), Is.EqualTo("New title"));
            Assert.That(updated.Theme, Is.SameAs(original.Theme));
            Assert.That(updated.Texts, Is.SameAs(original.Texts));
            Assert.That(updated.SpinnerMode, Is.EqualTo(SpinnerMode.DualRing));
            Assert.That(updated.BlockInput, Is.False);
            Assert.That(updated.ShowCard, Is.False);
        });
    }

    [Test]
    public void WithSuccess_SetsSuccessMessageAndTitle()
    {
        LoadingOptions updated = LoadingOptions.Default.WithSuccess(
            message: "Saved",
            title: "Done");

        Assert.Multiple(() =>
        {
            Assert.That(updated.ResolveSuccessMessage(), Is.EqualTo("Saved"));
            Assert.That(updated.ResolveSuccessTitle(), Is.EqualTo("Done"));
        });
    }

    [Test]
    public void WithError_SetsErrorMessageAndTitle()
    {
        LoadingOptions updated = LoadingOptions.Default.WithError(
            message: "Failed",
            title: "Oops");

        Assert.Multiple(() =>
        {
            Assert.That(updated.ResolveErrorMessage(), Is.EqualTo("Failed"));
            Assert.That(updated.ResolveErrorTitle(), Is.EqualTo("Oops"));
        });
    }
}