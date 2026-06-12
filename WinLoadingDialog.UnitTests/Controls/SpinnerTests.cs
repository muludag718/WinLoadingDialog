using NUnit.Framework;
using WinLoadingDialog.Controls;
using WinLoadingDialog.Theming;

namespace WinLoadingDialog.UnitTests.Controls;

[TestFixture]
[Apartment(ApartmentState.STA)]
public sealed class SpinnerTests
{
    [Test]
    public void Constructor_SetsDefaultValues()
    {
        using Spinner spinner = new();

        Assert.Multiple(() =>
        {
            Assert.That(spinner.Mode, Is.EqualTo(SpinnerMode.Arc));
            Assert.That(spinner.Thickness, Is.EqualTo(6f));
            Assert.That(spinner.Speed, Is.EqualTo(180f));
            Assert.That(spinner.SegmentCount, Is.EqualTo(12));
            Assert.That(spinner.SweepAngle, Is.EqualTo(90f));
            Assert.That(spinner.IsRunning, Is.False);
        });
    }

    [Test]
    public void Thickness_CannotBeLessThanOne()
    {
        using Spinner spinner = new();

        spinner.Thickness = -10f;

        Assert.That(spinner.Thickness, Is.EqualTo(1f));
    }

    [Test]
    public void Speed_CannotBeLessThanOne()
    {
        using Spinner spinner = new();

        spinner.Speed = 0f;

        Assert.That(spinner.Speed, Is.EqualTo(1f));
    }

    [Test]
    public void SegmentCount_CannotBeLessThanThree()
    {
        using Spinner spinner = new();

        spinner.SegmentCount = -5;

        Assert.That(spinner.SegmentCount, Is.EqualTo(3));
    }

    [Test]
    public void SweepAngle_IsClampedBetweenFiveAndThreeSixty()
    {
        using Spinner spinner = new();

        spinner.SweepAngle = -20f;
        Assert.That(spinner.SweepAngle, Is.EqualTo(5f));

        spinner.SweepAngle = 999f;
        Assert.That(spinner.SweepAngle, Is.EqualTo(360f));
    }

    [Test]
    public void ApplyPalette_UpdatesSpinnerColors()
    {
        using Spinner spinner = new();

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

        spinner.ApplyPalette(palette);

        Assert.Multiple(() =>
        {
            Assert.That(spinner.SpinnerColor, Is.EqualTo(Color.Red));
            Assert.That(spinner.TrackColor, Is.EqualTo(Color.Blue));
        });
    }

    [Test]
    public void Start_EnablesRunningStateWhenControlIsVisible()
    {
        using Form form = new()
        {
            ShowInTaskbar = false,
            StartPosition = FormStartPosition.Manual,
            Location = new Point(-2000, -2000),
            Size = new Size(200, 200)
        };

        using Spinner spinner = new()
        {
            Visible = true
        };

        form.Controls.Add(spinner);

        form.Show();

        try
        {
            spinner.Start();

            Assert.That(spinner.IsRunning, Is.True);
        }
        finally
        {
            form.Close();
        }
    }

    [Test]
    public void Stop_DisablesRunningState()
    {
        using Form form = new()
        {
            ShowInTaskbar = false,
            StartPosition = FormStartPosition.Manual,
            Location = new Point(-2000, -2000),
            Size = new Size(200, 200)
        };

        using Spinner spinner = new()
        {
            Visible = true
        };

        form.Controls.Add(spinner);

        form.Show();

        try
        {
            spinner.Start();
            spinner.Stop();

            Assert.That(spinner.IsRunning, Is.False);
        }
        finally
        {
            form.Close();
        }
    }
}