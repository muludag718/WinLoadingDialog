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
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        cmbSpinnerMode.DataSource = Enum.GetValues<SpinnerMode>();

        cmbTheme.Items.Add("System");
        cmbTheme.Items.Add("Light");
        cmbTheme.Items.Add("Dark");
        cmbTheme.Items.Add("Custom");
        cmbTheme.SelectedIndex = 0;

        cmbTexts.Items.Add("English");
        cmbTexts.Items.Add("Turkish");
        cmbTexts.SelectedIndex = 0;

        chkBlockInput.CheckedChanged += PreviewSettingChanged;
        chkShowCard.CheckedChanged += PreviewSettingChanged;

        ApplyLivePreview();
    }

    private void cmbSpinnerMode_SelectedIndexChanged(object? sender, EventArgs e)
    {
        ApplyLivePreview();
    }

    private void cmbTheme_SelectedIndexChanged(object? sender, EventArgs e)
    {
        ApplyLivePreview();
    }

    private void cmbTexts_SelectedIndexChanged(object? sender, EventArgs e)
    {
        ApplyLivePreview();
    }

    private void PreviewSettingChanged(object? sender, EventArgs e)
    {
        ApplyLivePreview();
    }

    private async void btnShowLoading_Click(object? sender, EventArgs e)
    {
        LoadingOptions options = CreateOptions("Loading on target panel...");

        SetStatus("Showing loading overlay on target panel.");

        LoadingService.Show(targetPanel, options);

        await Task.Delay(1600);

        LoadingService.Hide(targetPanel);

        SetStatus("Target panel loading overlay hidden.");
    }

    private void btnShowSuccess_Click(object? sender, EventArgs e)
    {
        LoadingOptions options = CreateOptions().WithSuccess(
            message: GetTexts() == LoadingTexts.Turkish
                ? "İşlem başarıyla tamamlandı."
                : "Operation completed successfully.",
            title: GetTexts() == LoadingTexts.Turkish
                ? "Tamamlandı"
                : "Completed");

        SetStatus("Showing success state.");

        LoadingService.Success(targetPanel, options);
    }

    private void btnShowError_Click(object? sender, EventArgs e)
    {
        LoadingOptions options = CreateOptions().WithError(
            message: GetTexts() == LoadingTexts.Turkish
                ? "Bir hata oluştu."
                : "Something went wrong.",
            title: GetTexts() == LoadingTexts.Turkish
                ? "Hata"
                : "Error");

        SetStatus("Showing error state.");

        LoadingService.Error(targetPanel, options);
    }

    private async void btnRunAsync_Click(object? sender, EventArgs e)
    {
        SetStatus("RunAsync demo started.");

        await LoadingService.RunAsync(
            targetPanel,
            async () =>
            {
                await Task.Delay(1700);
            },
            CreateOptions("RunAsync is executing..."));

        SetStatus("RunAsync demo completed.");
    }

    private async void btnBeginScope_Click(object? sender, EventArgs e)
    {
        SetStatus("Begin scope demo started.");

        using (LoadingService.Begin(targetPanel, CreateOptions("Begin scope is active...")))
        {
            await Task.Delay(1700);
        }

        SetStatus("Begin scope demo completed.");
    }

    private async void btnShowFormOverlay_Click(object? sender, EventArgs e)
    {
        LoadingOptions options = CreateOptions("This overlay is attached to the whole form.");

        SetStatus("Showing form-level overlay.");

        LoadingService.Show(this, options);

        await Task.Delay(1600);

        LoadingService.Success(this, options.WithSuccess("Form overlay completed."));

        SetStatus("Form-level overlay completed.");
    }

    private void btnHideAll_Click(object? sender, EventArgs e)
    {
        LoadingService.ForceDispose();

        SetStatus("All overlays disposed.");
    }

    private LoadingOptions CreateOptions(string? message = null)
    {
        LoadingTexts texts = GetTexts();

        string resolvedMessage = message ??
            (texts == LoadingTexts.Turkish
                ? "Veriler yükleniyor..."
                : "Loading data...");

        return new LoadingOptions
        {
            Message = resolvedMessage,
            Texts = texts,
            Theme = GetTheme(),
            SpinnerMode = GetSpinnerMode(),
            BlockInput = chkBlockInput.Checked,
            ShowCard = chkShowCard.Checked
        };
    }

    private SpinnerMode GetSpinnerMode()
    {
        return cmbSpinnerMode.SelectedItem is SpinnerMode mode
            ? mode
            : SpinnerMode.Arc;
    }

    private LoadingTexts GetTexts()
    {
        string? value = cmbTexts.SelectedItem?.ToString();

        return value == "Turkish"
            ? LoadingTexts.Turkish
            : LoadingTexts.English;
    }

    private LoadingTheme GetTheme()
    {
        string? value = cmbTheme.SelectedItem?.ToString();

        return value switch
        {
            "Light" => LoadingTheme.Light,
            "Dark" => LoadingTheme.Dark,
            "Custom" => LoadingTheme.FromPalette(CreateCustomPalette()),
            _ => LoadingTheme.System
        };
    }

    private LoadingPalette ResolvePreviewPalette()
    {
        return GetTheme().Resolve(previewPanel);
    }

    private static LoadingPalette CreateCustomPalette()
    {
        return new LoadingPalette
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
    }

    private void ApplyLivePreview()
    {
        SpinnerMode mode = GetSpinnerMode();
        LoadingTexts texts = GetTexts();
        LoadingPalette palette = ResolvePreviewPalette();

        liveSpinner.Mode = mode;
        liveSpinner.ApplyPalette(palette);
        liveSpinner.Start();

        previewCard.BackColor = palette.CardBackColor;
        lblPreviewTitle.ForeColor = palette.TitleForeColor;
        lblPreviewSubtitle.ForeColor = palette.MessageForeColor;

        lblPreviewTitle.Text = mode.ToString();
        lblPreviewSubtitle.Text = texts == LoadingTexts.Turkish
            ? "Canlı animasyon önizlemesi"
            : "Live animation preview";

        targetPanel.BackColor = GetTheme() == LoadingTheme.Dark
            ? Color.FromArgb(38, 38, 38)
            : Color.FromArgb(250, 250, 252);

        lblTargetTitle.ForeColor = palette.TitleForeColor;
        lblTargetSubtitle.ForeColor = palette.MessageForeColor;

        lblTargetTitle.Text = texts == LoadingTexts.Turkish
            ? "Hedef Panel"
            : "Target Panel";

        lblTargetSubtitle.Text = texts == LoadingTexts.Turkish
            ? "Soldaki aksiyonlarla overlay'i bu panel üzerinde test edebilirsin."
            : "Use the actions on the left to test the overlay on this panel.";

        lblModeCount.Text = "8 spinner modes available";
    }

    private void SetStatus(string text)
    {
        lblStatus.Text = text;
    }
}