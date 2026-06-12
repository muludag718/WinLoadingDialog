using System.ComponentModel;
using WinLoadingDialog.Controls;
using WinLoadingDialog.Models;
using Timer = System.Windows.Forms.Timer;

namespace WinLoadingDialog.UI;

partial class LoadingOverlay
{
    private System.ComponentModel.IContainer components = null;



    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new Container();
        panelCard = new Panel();
        lblTitle = new Label();
        lblMessage = new Label();
        stateIconControl = new StateIconControl();
        spinnerControl = new Spinner();
        fadeTimer = new Timer(components);
        autoCloseTimer = new Timer(components);
        panelCard.SuspendLayout();
        SuspendLayout();
        // 
        // panelCard
        // 
        panelCard.BackColor = Color.White;
        panelCard.Controls.Add(lblTitle);
        panelCard.Controls.Add(lblMessage);
        panelCard.Controls.Add(stateIconControl);
        panelCard.Controls.Add(spinnerControl);
        panelCard.Location = new Point(0, 0);
        panelCard.Name = "panelCard";
        panelCard.Size = new Size(360, 190);
        panelCard.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(32, 32, 32);
        lblTitle.Location = new Point(20, 95);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(320, 28);
        lblTitle.TabIndex = 2;
        lblTitle.Text = "Lütfen bekleyin";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblMessage
        // 
        lblMessage.Font = new Font("Segoe UI", 10F);
        lblMessage.ForeColor = Color.FromArgb(88, 88, 88);
        lblMessage.Location = new Point(25, 126);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new Size(310, 42);
        lblMessage.TabIndex = 3;
        lblMessage.Text = "Yükleniyor...";
        lblMessage.TextAlign = ContentAlignment.TopCenter;
        // 
        // stateIconControl
        // 
        stateIconControl.BackColor = Color.Transparent;
        stateIconControl.Location = new Point(148, 20);
        stateIconControl.Name = "stateIconControl";
        stateIconControl.Size = new Size(64, 64);
        stateIconControl.State = LoadingVisualState.Success;
        stateIconControl.TabIndex = 0;
        stateIconControl.Visible = false;
        // 
        // spinnerControl
        // 
        spinnerControl.BackColor = Color.Transparent;
        spinnerControl.Location = new Point(148, 20);
        spinnerControl.Name = "spinnerControl";
        spinnerControl.PreviewInDesigner = false;
        spinnerControl.Size = new Size(64, 64);
        spinnerControl.TabIndex = 1;
        // 
        // fadeTimer
        // 
        fadeTimer.Interval = 15;
        // 
        // autoCloseTimer
        // 
        autoCloseTimer.Interval = 1100;
        // 
        // LoadingOverlay
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.Transparent;
        Controls.Add(panelCard);
        DoubleBuffered = true;
        Name = "LoadingOverlay";
        Size = new Size(800, 430);
        panelCard.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel panelCard;
    private Label lblTitle;
    private Label lblMessage;
    private Spinner spinnerControl;
    private StateIconControl stateIconControl;
    private Timer fadeTimer;
    private Timer autoCloseTimer;
}
