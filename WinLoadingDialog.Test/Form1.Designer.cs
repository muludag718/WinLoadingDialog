using WinLoadingDialog.Controls;

namespace WinLoadingDialog.Test;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        mainLayout = new TableLayoutPanel();
        headerPanel = new Panel();
        lblHeaderTitle = new Label();
        lblHeaderSubtitle = new Label();
        contentLayout = new TableLayoutPanel();
        leftPanel = new Panel();
        groupActions = new GroupBox();
        actionsLayout = new TableLayoutPanel();
        btnShowLoading = new Button();
        btnShowSuccess = new Button();
        btnShowError = new Button();
        btnRunAsync = new Button();
        btnBeginScope = new Button();
        btnShowFormOverlay = new Button();
        btnHideAll = new Button();
        groupSettings = new GroupBox();
        settingsLayout = new TableLayoutPanel();
        lblSpinnerMode = new Label();
        cmbSpinnerMode = new ComboBox();
        lblTheme = new Label();
        cmbTheme = new ComboBox();
        lblTexts = new Label();
        cmbTexts = new ComboBox();
        chkBlockInput = new CheckBox();
        chkShowCard = new CheckBox();
        lblModeCount = new Label();
        rightLayout = new TableLayoutPanel();
        groupPreview = new GroupBox();
        previewPanel = new Panel();
        previewCard = new Panel();
        liveSpinner = new Spinner();
        lblPreviewTitle = new Label();
        lblPreviewSubtitle = new Label();
        groupTarget = new GroupBox();
        targetPanel = new Panel();
        lblTargetSubtitle = new Label();
        lblTargetTitle = new Label();
        lblStatus = new Label();
        mainLayout.SuspendLayout();
        headerPanel.SuspendLayout();
        contentLayout.SuspendLayout();
        leftPanel.SuspendLayout();
        groupActions.SuspendLayout();
        actionsLayout.SuspendLayout();
        groupSettings.SuspendLayout();
        settingsLayout.SuspendLayout();
        rightLayout.SuspendLayout();
        groupPreview.SuspendLayout();
        previewPanel.SuspendLayout();
        previewCard.SuspendLayout();
        groupTarget.SuspendLayout();
        targetPanel.SuspendLayout();
        SuspendLayout();
        // 
        // mainLayout
        // 
        mainLayout.ColumnCount = 1;
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainLayout.Controls.Add(headerPanel, 0, 0);
        mainLayout.Controls.Add(contentLayout, 0, 1);
        mainLayout.Controls.Add(lblStatus, 0, 2);
        mainLayout.Dock = DockStyle.Fill;
        mainLayout.Location = new Point(0, 0);
        mainLayout.Name = "mainLayout";
        mainLayout.Padding = new Padding(16);
        mainLayout.RowCount = 3;
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        mainLayout.Size = new Size(1040, 680);
        mainLayout.TabIndex = 0;
        // 
        // headerPanel
        // 
        headerPanel.Controls.Add(lblHeaderTitle);
        headerPanel.Controls.Add(lblHeaderSubtitle);
        headerPanel.Dock = DockStyle.Fill;
        headerPanel.Location = new Point(19, 19);
        headerPanel.Name = "headerPanel";
        headerPanel.Size = new Size(1002, 76);
        headerPanel.TabIndex = 0;
        // 
        // lblHeaderTitle
        // 
        lblHeaderTitle.AutoSize = true;
        lblHeaderTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblHeaderTitle.ForeColor = Color.FromArgb(25, 25, 25);
        lblHeaderTitle.Location = new Point(0, 2);
        lblHeaderTitle.Name = "lblHeaderTitle";
        lblHeaderTitle.Size = new Size(282, 41);
        lblHeaderTitle.TabIndex = 0;
        lblHeaderTitle.Text = "WinLoadingDialog";
        // 
        // lblHeaderSubtitle
        // 
        lblHeaderSubtitle.AutoSize = true;
        lblHeaderSubtitle.Font = new Font("Segoe UI", 10F);
        lblHeaderSubtitle.ForeColor = Color.DimGray;
        lblHeaderSubtitle.Location = new Point(4, 47);
        lblHeaderSubtitle.Name = "lblHeaderSubtitle";
        lblHeaderSubtitle.Size = new Size(694, 19);
        lblHeaderSubtitle.TabIndex = 1;
        lblHeaderSubtitle.Text = "Interactive demo for spinner modes, themes, localization, overlay targets, success/error states and async helpers.";
        // 
        // contentLayout
        // 
        contentLayout.ColumnCount = 2;
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 330F));
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        contentLayout.Controls.Add(leftPanel, 0, 0);
        contentLayout.Controls.Add(rightLayout, 1, 0);
        contentLayout.Dock = DockStyle.Fill;
        contentLayout.Location = new Point(19, 101);
        contentLayout.Name = "contentLayout";
        contentLayout.RowCount = 1;
        contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        contentLayout.Size = new Size(1002, 528);
        contentLayout.TabIndex = 1;
        // 
        // leftPanel
        // 
        leftPanel.Controls.Add(groupActions);
        leftPanel.Controls.Add(groupSettings);
        leftPanel.Dock = DockStyle.Fill;
        leftPanel.Location = new Point(3, 3);
        leftPanel.Name = "leftPanel";
        leftPanel.Padding = new Padding(0, 0, 12, 0);
        leftPanel.Size = new Size(324, 522);
        leftPanel.TabIndex = 0;
        // 
        // groupActions
        // 
        groupActions.Controls.Add(actionsLayout);
        groupActions.Dock = DockStyle.Fill;
        groupActions.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        groupActions.Location = new Point(0, 258);
        groupActions.Name = "groupActions";
        groupActions.Padding = new Padding(12);
        groupActions.Size = new Size(312, 264);
        groupActions.TabIndex = 1;
        groupActions.TabStop = false;
        groupActions.Text = "Actions";
        // 
        // actionsLayout
        // 
        actionsLayout.ColumnCount = 1;
        actionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        actionsLayout.Controls.Add(btnShowLoading, 0, 0);
        actionsLayout.Controls.Add(btnShowSuccess, 0, 1);
        actionsLayout.Controls.Add(btnShowError, 0, 2);
        actionsLayout.Controls.Add(btnRunAsync, 0, 3);
        actionsLayout.Controls.Add(btnBeginScope, 0, 4);
        actionsLayout.Controls.Add(btnShowFormOverlay, 0, 5);
        actionsLayout.Controls.Add(btnHideAll, 0, 6);
        actionsLayout.Dock = DockStyle.Fill;
        actionsLayout.Location = new Point(12, 30);
        actionsLayout.Name = "actionsLayout";
        actionsLayout.RowCount = 7;
        actionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
        actionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
        actionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
        actionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
        actionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
        actionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
        actionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
        actionsLayout.Size = new Size(288, 222);
        actionsLayout.TabIndex = 0;
        // 
        // btnShowLoading
        // 
        btnShowLoading.Dock = DockStyle.Fill;
        btnShowLoading.Font = new Font("Segoe UI", 9F);
        btnShowLoading.Location = new Point(3, 4);
        btnShowLoading.Margin = new Padding(3, 4, 3, 4);
        btnShowLoading.Name = "btnShowLoading";
        btnShowLoading.Size = new Size(282, 23);
        btnShowLoading.TabIndex = 0;
        btnShowLoading.Text = "Show Loading on Target";
        btnShowLoading.UseVisualStyleBackColor = true;
        btnShowLoading.Click += btnShowLoading_Click;
        // 
        // btnShowSuccess
        // 
        btnShowSuccess.Dock = DockStyle.Fill;
        btnShowSuccess.Font = new Font("Segoe UI", 9F);
        btnShowSuccess.Location = new Point(3, 35);
        btnShowSuccess.Margin = new Padding(3, 4, 3, 4);
        btnShowSuccess.Name = "btnShowSuccess";
        btnShowSuccess.Size = new Size(282, 23);
        btnShowSuccess.TabIndex = 1;
        btnShowSuccess.Text = "Show Success";
        btnShowSuccess.UseVisualStyleBackColor = true;
        btnShowSuccess.Click += btnShowSuccess_Click;
        // 
        // btnShowError
        // 
        btnShowError.Dock = DockStyle.Fill;
        btnShowError.Font = new Font("Segoe UI", 9F);
        btnShowError.Location = new Point(3, 66);
        btnShowError.Margin = new Padding(3, 4, 3, 4);
        btnShowError.Name = "btnShowError";
        btnShowError.Size = new Size(282, 23);
        btnShowError.TabIndex = 2;
        btnShowError.Text = "Show Error";
        btnShowError.UseVisualStyleBackColor = true;
        btnShowError.Click += btnShowError_Click;
        // 
        // btnRunAsync
        // 
        btnRunAsync.Dock = DockStyle.Fill;
        btnRunAsync.Font = new Font("Segoe UI", 9F);
        btnRunAsync.Location = new Point(3, 97);
        btnRunAsync.Margin = new Padding(3, 4, 3, 4);
        btnRunAsync.Name = "btnRunAsync";
        btnRunAsync.Size = new Size(282, 23);
        btnRunAsync.TabIndex = 3;
        btnRunAsync.Text = "RunAsync Demo";
        btnRunAsync.UseVisualStyleBackColor = true;
        btnRunAsync.Click += btnRunAsync_Click;
        // 
        // btnBeginScope
        // 
        btnBeginScope.Dock = DockStyle.Fill;
        btnBeginScope.Font = new Font("Segoe UI", 9F);
        btnBeginScope.Location = new Point(3, 128);
        btnBeginScope.Margin = new Padding(3, 4, 3, 4);
        btnBeginScope.Name = "btnBeginScope";
        btnBeginScope.Size = new Size(282, 23);
        btnBeginScope.TabIndex = 4;
        btnBeginScope.Text = "Begin Scope Demo";
        btnBeginScope.UseVisualStyleBackColor = true;
        btnBeginScope.Click += btnBeginScope_Click;
        // 
        // btnShowFormOverlay
        // 
        btnShowFormOverlay.Dock = DockStyle.Fill;
        btnShowFormOverlay.Font = new Font("Segoe UI", 9F);
        btnShowFormOverlay.Location = new Point(3, 159);
        btnShowFormOverlay.Margin = new Padding(3, 4, 3, 4);
        btnShowFormOverlay.Name = "btnShowFormOverlay";
        btnShowFormOverlay.Size = new Size(282, 23);
        btnShowFormOverlay.TabIndex = 5;
        btnShowFormOverlay.Text = "Show Form Overlay";
        btnShowFormOverlay.UseVisualStyleBackColor = true;
        btnShowFormOverlay.Click += btnShowFormOverlay_Click;
        // 
        // btnHideAll
        // 
        btnHideAll.Dock = DockStyle.Fill;
        btnHideAll.Font = new Font("Segoe UI", 9F);
        btnHideAll.Location = new Point(3, 190);
        btnHideAll.Margin = new Padding(3, 4, 3, 4);
        btnHideAll.Name = "btnHideAll";
        btnHideAll.Size = new Size(282, 28);
        btnHideAll.TabIndex = 6;
        btnHideAll.Text = "Hide / Dispose All";
        btnHideAll.UseVisualStyleBackColor = true;
        btnHideAll.Click += btnHideAll_Click;
        // 
        // groupSettings
        // 
        groupSettings.Controls.Add(settingsLayout);
        groupSettings.Dock = DockStyle.Top;
        groupSettings.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        groupSettings.Location = new Point(0, 0);
        groupSettings.Name = "groupSettings";
        groupSettings.Padding = new Padding(12);
        groupSettings.Size = new Size(312, 258);
        groupSettings.TabIndex = 0;
        groupSettings.TabStop = false;
        groupSettings.Text = "Demo Settings";
        // 
        // settingsLayout
        // 
        settingsLayout.ColumnCount = 1;
        settingsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        settingsLayout.Controls.Add(lblSpinnerMode, 0, 0);
        settingsLayout.Controls.Add(cmbSpinnerMode, 0, 1);
        settingsLayout.Controls.Add(lblTheme, 0, 2);
        settingsLayout.Controls.Add(cmbTheme, 0, 3);
        settingsLayout.Controls.Add(lblTexts, 0, 4);
        settingsLayout.Controls.Add(cmbTexts, 0, 5);
        settingsLayout.Controls.Add(chkBlockInput, 0, 6);
        settingsLayout.Controls.Add(chkShowCard, 0, 7);
        settingsLayout.Controls.Add(lblModeCount, 0, 8);
        settingsLayout.Dock = DockStyle.Fill;
        settingsLayout.Location = new Point(12, 30);
        settingsLayout.Name = "settingsLayout";
        settingsLayout.RowCount = 9;
        settingsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        settingsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        settingsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        settingsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        settingsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        settingsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        settingsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        settingsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        settingsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        settingsLayout.Size = new Size(288, 216);
        settingsLayout.TabIndex = 0;
        // 
        // lblSpinnerMode
        // 
        lblSpinnerMode.Dock = DockStyle.Fill;
        lblSpinnerMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSpinnerMode.ForeColor = Color.FromArgb(45, 45, 45);
        lblSpinnerMode.Location = new Point(3, 0);
        lblSpinnerMode.Name = "lblSpinnerMode";
        lblSpinnerMode.Size = new Size(282, 24);
        lblSpinnerMode.TabIndex = 0;
        lblSpinnerMode.Text = "Spinner Mode";
        lblSpinnerMode.TextAlign = ContentAlignment.BottomLeft;
        // 
        // cmbSpinnerMode
        // 
        cmbSpinnerMode.Dock = DockStyle.Fill;
        cmbSpinnerMode.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSpinnerMode.Font = new Font("Segoe UI", 9F);
        cmbSpinnerMode.FormattingEnabled = true;
        cmbSpinnerMode.Location = new Point(3, 27);
        cmbSpinnerMode.Name = "cmbSpinnerMode";
        cmbSpinnerMode.Size = new Size(282, 23);
        cmbSpinnerMode.TabIndex = 1;
        cmbSpinnerMode.SelectedIndexChanged += cmbSpinnerMode_SelectedIndexChanged;
        // 
        // lblTheme
        // 
        lblTheme.Dock = DockStyle.Fill;
        lblTheme.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTheme.ForeColor = Color.FromArgb(45, 45, 45);
        lblTheme.Location = new Point(3, 60);
        lblTheme.Name = "lblTheme";
        lblTheme.Size = new Size(282, 24);
        lblTheme.TabIndex = 2;
        lblTheme.Text = "Theme";
        lblTheme.TextAlign = ContentAlignment.BottomLeft;
        // 
        // cmbTheme
        // 
        cmbTheme.Dock = DockStyle.Fill;
        cmbTheme.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTheme.Font = new Font("Segoe UI", 9F);
        cmbTheme.FormattingEnabled = true;
        cmbTheme.Location = new Point(3, 87);
        cmbTheme.Name = "cmbTheme";
        cmbTheme.Size = new Size(282, 23);
        cmbTheme.TabIndex = 3;
        cmbTheme.SelectedIndexChanged += cmbTheme_SelectedIndexChanged;
        // 
        // lblTexts
        // 
        lblTexts.Dock = DockStyle.Fill;
        lblTexts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTexts.ForeColor = Color.FromArgb(45, 45, 45);
        lblTexts.Location = new Point(3, 120);
        lblTexts.Name = "lblTexts";
        lblTexts.Size = new Size(282, 24);
        lblTexts.TabIndex = 4;
        lblTexts.Text = "Texts";
        lblTexts.TextAlign = ContentAlignment.BottomLeft;
        // 
        // cmbTexts
        // 
        cmbTexts.Dock = DockStyle.Fill;
        cmbTexts.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTexts.Font = new Font("Segoe UI", 9F);
        cmbTexts.FormattingEnabled = true;
        cmbTexts.Location = new Point(3, 147);
        cmbTexts.Name = "cmbTexts";
        cmbTexts.Size = new Size(282, 23);
        cmbTexts.TabIndex = 5;
        cmbTexts.SelectedIndexChanged += cmbTexts_SelectedIndexChanged;
        // 
        // chkBlockInput
        // 
        chkBlockInput.AutoSize = true;
        chkBlockInput.Checked = true;
        chkBlockInput.CheckState = CheckState.Checked;
        chkBlockInput.Dock = DockStyle.Fill;
        chkBlockInput.Font = new Font("Segoe UI", 9F);
        chkBlockInput.Location = new Point(3, 183);
        chkBlockInput.Name = "chkBlockInput";
        chkBlockInput.Size = new Size(282, 24);
        chkBlockInput.TabIndex = 6;
        chkBlockInput.Text = "Block input while overlay is visible";
        chkBlockInput.UseVisualStyleBackColor = true;
        // 
        // chkShowCard
        // 
        chkShowCard.AutoSize = true;
        chkShowCard.Checked = true;
        chkShowCard.CheckState = CheckState.Checked;
        chkShowCard.Dock = DockStyle.Fill;
        chkShowCard.Font = new Font("Segoe UI", 9F);
        chkShowCard.Location = new Point(3, 213);
        chkShowCard.Name = "chkShowCard";
        chkShowCard.Size = new Size(282, 24);
        chkShowCard.TabIndex = 7;
        chkShowCard.Text = "Show centered card";
        chkShowCard.UseVisualStyleBackColor = true;
        // 
        // lblModeCount
        // 
        lblModeCount.Dock = DockStyle.Fill;
        lblModeCount.Font = new Font("Segoe UI", 8.5F);
        lblModeCount.ForeColor = Color.DimGray;
        lblModeCount.Location = new Point(3, 240);
        lblModeCount.Name = "lblModeCount";
        lblModeCount.Size = new Size(282, 1);
        lblModeCount.TabIndex = 8;
        lblModeCount.Text = "8 spinner modes available";
        // 
        // rightLayout
        // 
        rightLayout.ColumnCount = 1;
        rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rightLayout.Controls.Add(groupPreview, 0, 0);
        rightLayout.Controls.Add(groupTarget, 0, 1);
        rightLayout.Dock = DockStyle.Fill;
        rightLayout.Location = new Point(333, 3);
        rightLayout.Name = "rightLayout";
        rightLayout.RowCount = 2;
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rightLayout.Size = new Size(666, 522);
        rightLayout.TabIndex = 1;
        // 
        // groupPreview
        // 
        groupPreview.Controls.Add(previewPanel);
        groupPreview.Dock = DockStyle.Fill;
        groupPreview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        groupPreview.Location = new Point(3, 3);
        groupPreview.Name = "groupPreview";
        groupPreview.Padding = new Padding(12);
        groupPreview.Size = new Size(660, 244);
        groupPreview.TabIndex = 0;
        groupPreview.TabStop = false;
        groupPreview.Text = "Live Spinner Preview";
        // 
        // previewPanel
        // 
        previewPanel.BackColor = Color.FromArgb(245, 247, 250);
        previewPanel.Controls.Add(previewCard);
        previewPanel.Dock = DockStyle.Fill;
        previewPanel.Location = new Point(12, 30);
        previewPanel.Name = "previewPanel";
        previewPanel.Padding = new Padding(20);
        previewPanel.Size = new Size(636, 202);
        previewPanel.TabIndex = 0;
        // 
        // previewCard
        // 
        previewCard.Anchor = AnchorStyles.None;
        previewCard.BackColor = Color.White;
        previewCard.BorderStyle = BorderStyle.FixedSingle;
        previewCard.Controls.Add(liveSpinner);
        previewCard.Controls.Add(lblPreviewTitle);
        previewCard.Controls.Add(lblPreviewSubtitle);
        previewCard.Location = new Point(171, 21);
        previewCard.Name = "previewCard";
        previewCard.Size = new Size(294, 160);
        previewCard.TabIndex = 0;
        // 
        // liveSpinner
        // 
        liveSpinner.BackColor = Color.Transparent;
        liveSpinner.Location = new Point(111, 18);
        liveSpinner.Name = "liveSpinner";
        liveSpinner.Size = new Size(72, 72);
        liveSpinner.SpinnerColor = Color.FromArgb(0, 122, 204);
        liveSpinner.TabIndex = 0;
        liveSpinner.TrackColor = Color.Gainsboro;
        // 
        // lblPreviewTitle
        // 
        lblPreviewTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblPreviewTitle.ForeColor = Color.FromArgb(32, 32, 32);
        lblPreviewTitle.Location = new Point(18, 96);
        lblPreviewTitle.Name = "lblPreviewTitle";
        lblPreviewTitle.Size = new Size(256, 24);
        lblPreviewTitle.TabIndex = 1;
        lblPreviewTitle.Text = "Arc";
        lblPreviewTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblPreviewSubtitle
        // 
        lblPreviewSubtitle.Font = new Font("Segoe UI", 9F);
        lblPreviewSubtitle.ForeColor = Color.DimGray;
        lblPreviewSubtitle.Location = new Point(18, 122);
        lblPreviewSubtitle.Name = "lblPreviewSubtitle";
        lblPreviewSubtitle.Size = new Size(256, 22);
        lblPreviewSubtitle.TabIndex = 2;
        lblPreviewSubtitle.Text = "Animated preview";
        lblPreviewSubtitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // groupTarget
        // 
        groupTarget.Controls.Add(targetPanel);
        groupTarget.Dock = DockStyle.Fill;
        groupTarget.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        groupTarget.Location = new Point(3, 253);
        groupTarget.Name = "groupTarget";
        groupTarget.Padding = new Padding(12);
        groupTarget.Size = new Size(660, 266);
        groupTarget.TabIndex = 1;
        groupTarget.TabStop = false;
        groupTarget.Text = "Overlay Target Panel";
        // 
        // targetPanel
        // 
        targetPanel.BackColor = Color.FromArgb(250, 250, 252);
        targetPanel.BorderStyle = BorderStyle.FixedSingle;
        targetPanel.Controls.Add(lblTargetSubtitle);
        targetPanel.Controls.Add(lblTargetTitle);
        targetPanel.Dock = DockStyle.Fill;
        targetPanel.Location = new Point(12, 30);
        targetPanel.Name = "targetPanel";
        targetPanel.Size = new Size(636, 224);
        targetPanel.TabIndex = 0;
        // 
        // lblTargetSubtitle
        // 
        lblTargetSubtitle.Font = new Font("Segoe UI", 10F);
        lblTargetSubtitle.ForeColor = Color.DimGray;
        lblTargetSubtitle.Location = new Point(20, 112);
        lblTargetSubtitle.Name = "lblTargetSubtitle";
        lblTargetSubtitle.Size = new Size(594, 42);
        lblTargetSubtitle.TabIndex = 1;
        lblTargetSubtitle.Text = "Click an action on the left to display an overlay on this panel.";
        lblTargetSubtitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTargetTitle
        // 
        lblTargetTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTargetTitle.ForeColor = Color.FromArgb(36, 36, 36);
        lblTargetTitle.Location = new Point(20, 68);
        lblTargetTitle.Name = "lblTargetTitle";
        lblTargetTitle.Size = new Size(594, 42);
        lblTargetTitle.TabIndex = 0;
        lblTargetTitle.Text = "Target Panel";
        lblTargetTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblStatus
        // 
        lblStatus.Dock = DockStyle.Fill;
        lblStatus.Font = new Font("Segoe UI", 9F);
        lblStatus.ForeColor = Color.DimGray;
        lblStatus.Location = new Point(19, 632);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(1002, 32);
        lblStatus.TabIndex = 2;
        lblStatus.Text = "Ready";
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1040, 680);
        Controls.Add(mainLayout);
        MinimumSize = new Size(960, 620);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "WinLoadingDialog Demo";
        Load += Form1_Load;
        mainLayout.ResumeLayout(false);
        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        contentLayout.ResumeLayout(false);
        leftPanel.ResumeLayout(false);
        groupActions.ResumeLayout(false);
        actionsLayout.ResumeLayout(false);
        groupSettings.ResumeLayout(false);
        settingsLayout.ResumeLayout(false);
        settingsLayout.PerformLayout();
        rightLayout.ResumeLayout(false);
        groupPreview.ResumeLayout(false);
        previewPanel.ResumeLayout(false);
        previewCard.ResumeLayout(false);
        groupTarget.ResumeLayout(false);
        targetPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel mainLayout;
    private Panel headerPanel;
    private Label lblHeaderTitle;
    private Label lblHeaderSubtitle;
    private TableLayoutPanel contentLayout;

    private Panel leftPanel;
    private GroupBox groupSettings;
    private TableLayoutPanel settingsLayout;
    private Label lblSpinnerMode;
    private ComboBox cmbSpinnerMode;
    private Label lblTheme;
    private ComboBox cmbTheme;
    private Label lblTexts;
    private ComboBox cmbTexts;
    private CheckBox chkBlockInput;
    private CheckBox chkShowCard;
    private Label lblModeCount;

    private GroupBox groupActions;
    private TableLayoutPanel actionsLayout;
    private Button btnShowLoading;
    private Button btnShowSuccess;
    private Button btnShowError;
    private Button btnRunAsync;
    private Button btnBeginScope;
    private Button btnShowFormOverlay;
    private Button btnHideAll;

    private TableLayoutPanel rightLayout;
    private GroupBox groupPreview;
    private Panel previewPanel;
    private Panel previewCard;
    private Spinner liveSpinner;
    private Label lblPreviewTitle;
    private Label lblPreviewSubtitle;

    private GroupBox groupTarget;
    private Panel targetPanel;
    private Label lblTargetTitle;
    private Label lblTargetSubtitle;

    private Label lblStatus;
}