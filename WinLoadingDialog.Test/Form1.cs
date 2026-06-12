using WinLoadingDialog.Controls;
using WinLoadingDialog.Localization;
using WinLoadingDialog.Options;
using WinLoadingDialog.Services;
using WinLoadingDialog.Theming;

namespace WinLoadingDialog.Test;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        btnArc.Click += btnArc_Click;
        btnCircle.Click += btnCircle_Click;
        btnCircularProgress.Click += btnCircularProgress_Click;
        btnDots.Click += btnDots_Click;
        btnPulse.Click += btnPulse_Click;
        btnRing.Click += btnRing_Click;
        btnBars.Click += btnBars_Click;
        btnDualRing.Click += btnDualRing_Click;
        btnLightTheme.Click += btnLightTheme_Click;
        btnDarkTheme.Click += btnDarkTheme_Click;
        btnCustomTheme.Click += btnCustomTheme_Click;
        btnTurkish.Click += btnTurkish_Click;
        btnSuccess.Click += btnSuccess_Click;
        btnError.Click += btnError_Click;
        btnRunAsync.Click += btnRunAsync_Click;
        btnBeginScope.Click += btnBeginScope_Click;
        btnPanelLoading.Click += btnPanelLoading_Click;
        btnPanelSuccess.Click += btnPanelSuccess_Click;
        btnPanelError.Click += btnPanelError_Click;
    }

    private async Task ShowSpinnerDemoAsync(SpinnerMode mode)
    {
        LoadingOptions options = new()
        {
            Message = $"{mode} spinner is running...",
            SpinnerMode = mode,
            Theme = LoadingTheme.System,
            Texts = LoadingTexts.English
        };

        LoadingService.Show(this, options);

        await Task.Delay(1400);

        LoadingService.Success(this, options.WithSuccess($"{mode} demo completed."));
    }

    private async void btnArc_Click(object? sender, EventArgs e)
    {
        await ShowSpinnerDemoAsync(SpinnerMode.Arc);
    }

    private async void btnCircle_Click(object? sender, EventArgs e)
    {
        await ShowSpinnerDemoAsync(SpinnerMode.Circle);
    }

    private async void btnCircularProgress_Click(object? sender, EventArgs e)
    {
        await ShowSpinnerDemoAsync(SpinnerMode.CircularProgress);
    }

    private async void btnDots_Click(object? sender, EventArgs e)
    {
        await ShowSpinnerDemoAsync(SpinnerMode.Dots);
    }

    private async void btnPulse_Click(object? sender, EventArgs e)
    {
        await ShowSpinnerDemoAsync(SpinnerMode.Pulse);
    }

    private async void btnRing_Click(object? sender, EventArgs e)
    {
        await ShowSpinnerDemoAsync(SpinnerMode.Ring);
    }

    private async void btnBars_Click(object? sender, EventArgs e)
    {
        await ShowSpinnerDemoAsync(SpinnerMode.Bars);
    }

    private async void btnDualRing_Click(object? sender, EventArgs e)
    {
        await ShowSpinnerDemoAsync(SpinnerMode.DualRing);
    }

    private async void btnLightTheme_Click(object? sender, EventArgs e)
    {
        LoadingOptions options = new()
        {
            Theme = LoadingTheme.Light,
            SpinnerMode = SpinnerMode.Ring,
            Message = "Light theme loading..."
        };

        LoadingService.Show(this, options);

        await Task.Delay(1200);

        LoadingService.Success(this, options.WithSuccess("Light theme completed."));
    }

    private async void btnDarkTheme_Click(object? sender, EventArgs e)
    {
        LoadingOptions options = new()
        {
            Theme = LoadingTheme.Dark,
            SpinnerMode = SpinnerMode.DualRing,
            Message = "Dark theme loading..."
        };

        LoadingService.Show(this, options);

        await Task.Delay(1200);

        LoadingService.Success(this, options.WithSuccess("Dark theme completed."));
    }

    private async void btnCustomTheme_Click(object? sender, EventArgs e)
    {
        LoadingPalette palette = new()
        {
            OverlayBackColor = Color.FromArgb(120, 30, 20, 70),
            CardBackColor = Color.FromArgb(252, 248, 255),
            CardBorderColor = Color.FromArgb(160, 110, 220),
            TitleForeColor = Color.FromArgb(55, 30, 85),
            MessageForeColor = Color.FromArgb(100, 80, 125),
            SpinnerColor = Color.FromArgb(130, 70, 220),
            SpinnerTrackColor = Color.FromArgb(220, 205, 245),
            SuccessColor = Color.FromArgb(30, 150, 100),
            ErrorColor = Color.FromArgb(210, 70, 90)
        };

        LoadingOptions options = new()
        {
            Theme = LoadingTheme.FromPalette(palette),
            SpinnerMode = SpinnerMode.Dots,
            Message = "Custom theme loading..."
        };

        LoadingService.Show(this, options);

        await Task.Delay(1200);

        LoadingService.Success(this, options.WithSuccess("Custom theme completed."));
    }

    private async void btnTurkish_Click(object? sender, EventArgs e)
    {
        LoadingOptions options = new()
        {
            Texts = LoadingTexts.Turkish,
            Theme = LoadingTheme.Light,
            SpinnerMode = SpinnerMode.Circle,
            Message = "Veriler yükleniyor..."
        };

        LoadingService.Show(this, options);

        await Task.Delay(1200);

        LoadingService.Success(this, options.WithSuccess("İşlem başarıyla tamamlandı."));
    }

    private void btnSuccess_Click(object? sender, EventArgs e)
    {
        LoadingService.Success(this, new LoadingOptions
        {
            Message = "This message is ignored for success state.",
            SuccessMessage = "Operation completed successfully.",
            SpinnerMode = SpinnerMode.Arc,
            Theme = LoadingTheme.System
        });
    }

    private void btnError_Click(object? sender, EventArgs e)
    {
        LoadingService.Error(this, new LoadingOptions
        {
            ErrorMessage = "Something went wrong.",
            SpinnerMode = SpinnerMode.Arc,
            Theme = LoadingTheme.System
        });
    }

    private async void btnRunAsync_Click(object? sender, EventArgs e)
    {
        await LoadingService.RunAsync(
            this,
            async () =>
            {
                await Task.Delay(1600);
            },
            new LoadingOptions
            {
                Message = "RunAsync helper is executing...",
                SpinnerMode = SpinnerMode.CircularProgress,
                Theme = LoadingTheme.System
            });
    }

    private async void btnBeginScope_Click(object? sender, EventArgs e)
    {
        using (LoadingService.Begin(this, new LoadingOptions
        {
            Message = "Begin scope is active...",
            SpinnerMode = SpinnerMode.Pulse,
            Theme = LoadingTheme.System
        }))
        {
            await Task.Delay(1600);
        }
    }

    private async void btnPanelLoading_Click(object? sender, EventArgs e)
    {
        LoadingOptions options = new()
        {
            Message = "Panel is loading...",
            SpinnerMode = SpinnerMode.Bars,
            Theme = LoadingTheme.Light
        };

        LoadingService.Show(panelDemoTarget, options);

        await Task.Delay(1500);

        LoadingService.Hide(panelDemoTarget);
    }

    private void btnPanelSuccess_Click(object? sender, EventArgs e)
    {
        LoadingService.Success(panelDemoTarget, new LoadingOptions
        {
            Theme = LoadingTheme.Light,
            SuccessMessage = "Panel operation completed."
        });
    }

    private void btnPanelError_Click(object? sender, EventArgs e)
    {
        LoadingService.Error(panelDemoTarget, new LoadingOptions
        {
            Theme = LoadingTheme.Light,
            ErrorMessage = "Panel operation failed."
        });
    }
}
