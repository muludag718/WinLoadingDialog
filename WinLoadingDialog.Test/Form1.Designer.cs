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
        tableMain = new TableLayoutPanel();
        panelHeader = new Panel();
        lblTitle = new Label();
        lblSubtitle = new Label();
        groupSpinnerModes = new GroupBox();
        flowSpinnerModes = new FlowLayoutPanel();
        btnArc = new Button();
        btnCircle = new Button();
        btnCircularProgress = new Button();
        btnDots = new Button();
        btnPulse = new Button();
        btnRing = new Button();
        btnBars = new Button();
        btnDualRing = new Button();
        groupThemes = new GroupBox();
        flowThemes = new FlowLayoutPanel();
        btnLightTheme = new Button();
        btnDarkTheme = new Button();
        btnCustomTheme = new Button();
        btnTurkish = new Button();
        groupStates = new GroupBox();
        flowStates = new FlowLayoutPanel();
        btnSuccess = new Button();
        btnError = new Button();
        btnRunAsync = new Button();
        btnBeginScope = new Button();
        groupPanelDemo = new GroupBox();
        tablePanelDemo = new TableLayoutPanel();
        panelDemoTarget = new Panel();
        lblPanelDemo = new Label();
        flowPanelButtons = new FlowLayoutPanel();
        btnPanelLoading = new Button();
        btnPanelSuccess = new Button();
        btnPanelError = new Button();

        tableMain.SuspendLayout();
        panelHeader.SuspendLayout();
        groupSpinnerModes.SuspendLayout();
        flowSpinnerModes.SuspendLayout();
        groupThemes.SuspendLayout();
        flowThemes.SuspendLayout();
        groupStates.SuspendLayout();
        flowStates.SuspendLayout();
        groupPanelDemo.SuspendLayout();
        tablePanelDemo.SuspendLayout();
        panelDemoTarget.SuspendLayout();
        flowPanelButtons.SuspendLayout();
        SuspendLayout();

        // tableMain
        tableMain.ColumnCount = 1;
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableMain.Controls.Add(panelHeader, 0, 0);
        tableMain.Controls.Add(groupSpinnerModes, 0, 1);
        tableMain.Controls.Add(groupThemes, 0, 2);
        tableMain.Controls.Add(groupStates, 0, 3);
        tableMain.Controls.Add(groupPanelDemo, 0, 4);
        tableMain.Dock = DockStyle.Fill;
        tableMain.Location = new Point(0, 0);
        tableMain.Name = "tableMain";
        tableMain.Padding = new Padding(14);
        tableMain.RowCount = 5;
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableMain.Size = new Size(920, 640);
        tableMain.TabIndex = 0;

        // panelHeader
        panelHeader.Controls.Add(lblTitle);
        panelHeader.Controls.Add(lblSubtitle);
        panelHeader.Dock = DockStyle.Fill;
        panelHeader.Location = new Point(17, 17);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(886, 76);
        panelHeader.TabIndex = 0;

        // lblTitle
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitle.Location = new Point(0, 4);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(264, 37);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "WinLoadingDialog";

        // lblSubtitle
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 10F);
        lblSubtitle.ForeColor = Color.DimGray;
        lblSubtitle.Location = new Point(4, 45);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(520, 19);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Spinner modes, themes, localization, success/error states and panel overlays.";

        // groupSpinnerModes
        groupSpinnerModes.Controls.Add(flowSpinnerModes);
        groupSpinnerModes.Dock = DockStyle.Fill;
        groupSpinnerModes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        groupSpinnerModes.Location = new Point(17, 99);
        groupSpinnerModes.Name = "groupSpinnerModes";
        groupSpinnerModes.Padding = new Padding(12);
        groupSpinnerModes.Size = new Size(886, 92);
        groupSpinnerModes.TabIndex = 1;
        groupSpinnerModes.TabStop = false;
        groupSpinnerModes.Text = "Spinner Modes";

        // flowSpinnerModes
        flowSpinnerModes.Controls.Add(btnArc);
        flowSpinnerModes.Controls.Add(btnCircle);
        flowSpinnerModes.Controls.Add(btnCircularProgress);
        flowSpinnerModes.Controls.Add(btnDots);
        flowSpinnerModes.Controls.Add(btnPulse);
        flowSpinnerModes.Controls.Add(btnRing);
        flowSpinnerModes.Controls.Add(btnBars);
        flowSpinnerModes.Controls.Add(btnDualRing);
        flowSpinnerModes.Dock = DockStyle.Fill;
        flowSpinnerModes.Location = new Point(12, 30);
        flowSpinnerModes.Name = "flowSpinnerModes";
        flowSpinnerModes.Size = new Size(862, 50);
        flowSpinnerModes.TabIndex = 0;

        // buttons
        ConfigureDemoButton(btnArc, "Arc");
        ConfigureDemoButton(btnCircle, "Circle");
        ConfigureDemoButton(btnCircularProgress, "Circular Progress");
        ConfigureDemoButton(btnDots, "Dots");
        ConfigureDemoButton(btnPulse, "Pulse");
        ConfigureDemoButton(btnRing, "Ring");
        ConfigureDemoButton(btnBars, "Bars");
        ConfigureDemoButton(btnDualRing, "Dual Ring");

     

        // groupThemes
        groupThemes.Controls.Add(flowThemes);
        groupThemes.Dock = DockStyle.Fill;
        groupThemes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        groupThemes.Location = new Point(17, 197);
        groupThemes.Name = "groupThemes";
        groupThemes.Padding = new Padding(12);
        groupThemes.Size = new Size(886, 82);
        groupThemes.TabIndex = 2;
        groupThemes.TabStop = false;
        groupThemes.Text = "Theme / Texts";

        // flowThemes
        flowThemes.Controls.Add(btnLightTheme);
        flowThemes.Controls.Add(btnDarkTheme);
        flowThemes.Controls.Add(btnCustomTheme);
        flowThemes.Controls.Add(btnTurkish);
        flowThemes.Dock = DockStyle.Fill;
        flowThemes.Location = new Point(12, 30);
        flowThemes.Name = "flowThemes";
        flowThemes.Size = new Size(862, 40);
        flowThemes.TabIndex = 0;

        ConfigureDemoButton(btnLightTheme, "Light Theme");
        ConfigureDemoButton(btnDarkTheme, "Dark Theme");
        ConfigureDemoButton(btnCustomTheme, "Custom Theme");
        ConfigureDemoButton(btnTurkish, "Turkish Texts");
    

        // groupStates
        groupStates.Controls.Add(flowStates);
        groupStates.Dock = DockStyle.Fill;
        groupStates.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        groupStates.Location = new Point(17, 285);
        groupStates.Name = "groupStates";
        groupStates.Padding = new Padding(12);
        groupStates.Size = new Size(886, 82);
        groupStates.TabIndex = 3;
        groupStates.TabStop = false;
        groupStates.Text = "States / Helpers";

        // flowStates
        flowStates.Controls.Add(btnSuccess);
        flowStates.Controls.Add(btnError);
        flowStates.Controls.Add(btnRunAsync);
        flowStates.Controls.Add(btnBeginScope);
        flowStates.Dock = DockStyle.Fill;
        flowStates.Location = new Point(12, 30);
        flowStates.Name = "flowStates";
        flowStates.Size = new Size(862, 40);
        flowStates.TabIndex = 0;

        ConfigureDemoButton(btnSuccess, "Success");
        ConfigureDemoButton(btnError, "Error");
        ConfigureDemoButton(btnRunAsync, "RunAsync");
        ConfigureDemoButton(btnBeginScope, "Begin Scope");
      

        // groupPanelDemo
        groupPanelDemo.Controls.Add(tablePanelDemo);
        groupPanelDemo.Dock = DockStyle.Fill;
        groupPanelDemo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        groupPanelDemo.Location = new Point(17, 373);
        groupPanelDemo.Name = "groupPanelDemo";
        groupPanelDemo.Padding = new Padding(12);
        groupPanelDemo.Size = new Size(886, 250);
        groupPanelDemo.TabIndex = 4;
        groupPanelDemo.TabStop = false;
        groupPanelDemo.Text = "Panel Target Demo";

        // tablePanelDemo
        tablePanelDemo.ColumnCount = 1;
        tablePanelDemo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tablePanelDemo.Controls.Add(panelDemoTarget, 0, 0);
        tablePanelDemo.Controls.Add(flowPanelButtons, 0, 1);
        tablePanelDemo.Dock = DockStyle.Fill;
        tablePanelDemo.Location = new Point(12, 30);
        tablePanelDemo.Name = "tablePanelDemo";
        tablePanelDemo.RowCount = 2;
        tablePanelDemo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tablePanelDemo.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tablePanelDemo.Size = new Size(862, 208);
        tablePanelDemo.TabIndex = 0;

        // panelDemoTarget
        panelDemoTarget.BackColor = Color.FromArgb(245, 247, 250);
        panelDemoTarget.BorderStyle = BorderStyle.FixedSingle;
        panelDemoTarget.Controls.Add(lblPanelDemo);
        panelDemoTarget.Dock = DockStyle.Fill;
        panelDemoTarget.Location = new Point(3, 3);
        panelDemoTarget.Name = "panelDemoTarget";
        panelDemoTarget.Size = new Size(856, 156);
        panelDemoTarget.TabIndex = 0;

        // lblPanelDemo
        lblPanelDemo.Dock = DockStyle.Fill;
        lblPanelDemo.Font = new Font("Segoe UI", 11F);
        lblPanelDemo.ForeColor = Color.DimGray;
        lblPanelDemo.Location = new Point(0, 0);
        lblPanelDemo.Name = "lblPanelDemo";
        lblPanelDemo.Size = new Size(854, 154);
        lblPanelDemo.TabIndex = 0;
        lblPanelDemo.Text = "This panel is a separate loading target.";
        lblPanelDemo.TextAlign = ContentAlignment.MiddleCenter;

        // flowPanelButtons
        flowPanelButtons.Controls.Add(btnPanelLoading);
        flowPanelButtons.Controls.Add(btnPanelSuccess);
        flowPanelButtons.Controls.Add(btnPanelError);
        flowPanelButtons.Dock = DockStyle.Fill;
        flowPanelButtons.Location = new Point(3, 165);
        flowPanelButtons.Name = "flowPanelButtons";
        flowPanelButtons.Size = new Size(856, 40);
        flowPanelButtons.TabIndex = 1;

        ConfigureDemoButton(btnPanelLoading, "Panel Loading");
        ConfigureDemoButton(btnPanelSuccess, "Panel Success");
        ConfigureDemoButton(btnPanelError, "Panel Error");
     

        // Form1
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(920, 640);
        Controls.Add(tableMain);
        MinimumSize = new Size(820, 560);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "WinLoadingDialog Demo";

        tableMain.ResumeLayout(false);
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        groupSpinnerModes.ResumeLayout(false);
        flowSpinnerModes.ResumeLayout(false);
        groupThemes.ResumeLayout(false);
        flowThemes.ResumeLayout(false);
        groupStates.ResumeLayout(false);
        flowStates.ResumeLayout(false);
        groupPanelDemo.ResumeLayout(false);
        tablePanelDemo.ResumeLayout(false);
        panelDemoTarget.ResumeLayout(false);
        flowPanelButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private static void ConfigureDemoButton(Button button, string text)
    {
        button.AutoSize = true;
        button.Font = new Font("Segoe UI", 9F);
        button.Margin = new Padding(4);
        button.MinimumSize = new Size(110, 34);
        button.Name = "btn" + text.Replace(" ", string.Empty);
        button.Padding = new Padding(8, 2, 8, 2);
        button.TabIndex = 0;
        button.Text = text;
        button.UseVisualStyleBackColor = true;
    }

    private TableLayoutPanel tableMain;
    private Panel panelHeader;
    private Label lblTitle;
    private Label lblSubtitle;

    private GroupBox groupSpinnerModes;
    private FlowLayoutPanel flowSpinnerModes;
    private Button btnArc;
    private Button btnCircle;
    private Button btnCircularProgress;
    private Button btnDots;
    private Button btnPulse;
    private Button btnRing;
    private Button btnBars;
    private Button btnDualRing;

    private GroupBox groupThemes;
    private FlowLayoutPanel flowThemes;
    private Button btnLightTheme;
    private Button btnDarkTheme;
    private Button btnCustomTheme;
    private Button btnTurkish;

    private GroupBox groupStates;
    private FlowLayoutPanel flowStates;
    private Button btnSuccess;
    private Button btnError;
    private Button btnRunAsync;
    private Button btnBeginScope;

    private GroupBox groupPanelDemo;
    private TableLayoutPanel tablePanelDemo;
    private Panel panelDemoTarget;
    private Label lblPanelDemo;
    private FlowLayoutPanel flowPanelButtons;
    private Button btnPanelLoading;
    private Button btnPanelSuccess;
    private Button btnPanelError;
}