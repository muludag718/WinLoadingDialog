using NUnit.Framework;
using WinLoadingDialog.Controls;
using WinLoadingDialog.Models;
using WinLoadingDialog.Theming;

namespace WinLoadingDialog.UnitTests.Controls;

[TestFixture]
[Apartment(ApartmentState.STA)]
public sealed class StateIconControlTests
{
    [Test]
    public void Constructor_SetsDefaultValues()
    {
        using StateIconControl icon = new();

        Assert.Multiple(() =>
        {
            Assert.That(icon.State, Is.EqualTo(LoadingVisualState.Success));
            Assert.That(icon.Thickness, Is.EqualTo(6f));
        });
    }

    [Test]
    public void Thickness_CannotBeLessThanOne()
    {
        using StateIconControl icon = new();

        icon.Thickness = -10f;

        Assert.That(icon.Thickness, Is.EqualTo(1f));
    }

    [Test]
    public void ApplyPalette_UpdatesStateColors()
    {
        using StateIconControl icon = new();

        LoadingPalette palette = new()
        {
            OverlayBackColor = Color.Black,
            CardBackColor = Color.White,
            CardBorderColor = Color.Gray,
            TitleForeColor = Color.Black,
            MessageForeColor = Color.DimGray,
            SpinnerColor = Color.Red,
            SpinnerTrackColor = Color.Blue,
            SuccessColor = Color.Green,
            ErrorColor = Color.Pink
        };

        icon.ApplyPalette(palette);

        Assert.Multiple(() =>
        {
            Assert.That(icon.SuccessColor, Is.EqualTo(Color.Green));
            Assert.That(icon.ErrorColor, Is.EqualTo(Color.Pink));
        });
    }

    [Test]
    public void State_CanBeChanged()
    {
        using StateIconControl icon = new();

        icon.State = LoadingVisualState.Error;

        Assert.That(icon.State, Is.EqualTo(LoadingVisualState.Error));
    }
}