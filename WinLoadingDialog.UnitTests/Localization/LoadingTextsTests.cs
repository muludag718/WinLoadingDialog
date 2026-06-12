using NUnit.Framework;
using WinLoadingDialog.Localization;

namespace WinLoadingDialog.UnitTests.Localization;

[TestFixture]
public sealed class LoadingTextsTests
{
    [Test]
    public void English_ReturnsDefaultEnglishTexts()
    {
        LoadingTexts texts = LoadingTexts.English;

        Assert.Multiple(() =>
        {
            Assert.That(texts.LoadingTitle, Is.EqualTo("Loading"));
            Assert.That(texts.LoadingMessage, Is.EqualTo("Please wait..."));
            Assert.That(texts.SuccessTitle, Is.EqualTo("Completed"));
            Assert.That(texts.ErrorTitle, Is.EqualTo("Error"));
        });
    }

    [Test]
    public void Turkish_ReturnsTurkishTexts()
    {
        LoadingTexts texts = LoadingTexts.Turkish;

        Assert.Multiple(() =>
        {
            Assert.That(texts.LoadingTitle, Is.EqualTo("Yükleniyor"));
            Assert.That(texts.LoadingMessage, Is.EqualTo("Lütfen bekleyin..."));
            Assert.That(texts.SuccessTitle, Is.EqualTo("Tamamlandı"));
            Assert.That(texts.ErrorTitle, Is.EqualTo("Hata"));
        });
    }

    [Test]
    public void FromValues_OverridesProvidedValues()
    {
        LoadingTexts texts = LoadingTexts.FromValues(
            loadingTitle: "Processing",
            errorMessage: "Custom error");

        Assert.Multiple(() =>
        {
            Assert.That(texts.LoadingTitle, Is.EqualTo("Processing"));
            Assert.That(texts.LoadingMessage, Is.EqualTo(LoadingTexts.English.LoadingMessage));
            Assert.That(texts.ErrorMessage, Is.EqualTo("Custom error"));
        });
    }

    [Test]
    public void FromValues_UsesEnglishFallbackForEmptyValues()
    {
        LoadingTexts texts = LoadingTexts.FromValues(
            loadingTitle: "",
            loadingMessage: "   ");

        Assert.Multiple(() =>
        {
            Assert.That(texts.LoadingTitle, Is.EqualTo(LoadingTexts.English.LoadingTitle));
            Assert.That(texts.LoadingMessage, Is.EqualTo(LoadingTexts.English.LoadingMessage));
        });
    }
}