using System.Drawing.Drawing2D;
using WinLoadingDialog.Models;
using WinLoadingDialog.Options;
using WinLoadingDialog.Theming;

namespace WinLoadingDialog.UI;

internal partial class LoadingOverlay : UserControl, ILoadingOverlayView
{
    private const int WmNcHitTest = 0x0084;
    private const int HtTransparent = -1;

    private Control? _targetControl;
    private Form? _hostForm;

    private bool _isActive;
    private bool _blockInput = true;
    private bool _showCard = true;
    private bool _managedResourcesCleaned;

    private int _fadeDirection; // 1 = fade in, -1 = fade out
    private int _overlayAlpha;
    private int _targetOverlayAlpha = LoadingDefaults.DefaultOverlayAlpha;
    private int _cardOffsetY;
    private int _pendingAutoCloseMs;

    private Color _overlayBaseColor = Color.Black;
    private Color _cardBorderColor = Color.FromArgb(225, 225, 225);

    private LoadingVisualState _currentState = LoadingVisualState.Loading;

    public event EventHandler? Closed;

    public bool IsReleased => _managedResourcesCleaned;

    public LoadingOverlay()
    {
        InitializeComponent();

        panelCard.Paint += PanelCard_Paint;
        panelCard.Resize += PanelCard_Resize;
        Resize += LoadingOverlay_Resize;
        autoCloseTimer.Tick += AutoCloseTimer_Tick;
        fadeTimer.Tick += FadeTimer_Tick;
        Disposed += LoadingOverlay_Disposed;

        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw,
            true);

        Visible = false;
    }

    public void Attach(Control target)
    {
        if (!CanUseTarget(target) || _managedResourcesCleaned)
            return;

        if (ReferenceEquals(_targetControl, target) && Parent == target)
        {
            EnsureVisibleOnTop();
            return;
        }

        DetachFromTarget();

        _targetControl = target;
        _hostForm = target.FindForm();

        target.Controls.Add(this);

        Dock = DockStyle.Fill;
        BringToFront();

        target.Resize += Target_Changed;
        target.VisibleChanged += Target_Changed;
        target.Disposed += Target_Disposed;

        if (_hostForm != null)
        {
            _hostForm.Move += HostForm_Changed;
            _hostForm.Resize += HostForm_Changed;
            _hostForm.VisibleChanged += HostForm_Changed;
            _hostForm.FormClosed += HostForm_FormClosed;
        }

        UpdateCardLayout();
        UpdateCardLocation();
    }

    public void Render(LoadingOverlayViewModel model)
    {
        if (IsDisposed || _managedResourcesCleaned)
            return;

        ArgumentNullException.ThrowIfNull(model);

        _isActive = true;
        _currentState = model.State;
        _pendingAutoCloseMs = model.AutoCloseDelayMs;
        _blockInput = model.BlockInput;
        _showCard = model.ShowCard;

        ApplyPalette(model.Palette);

        panelCard.Visible = _showCard;

        lblTitle.Text = model.Title;
        lblMessage.Text = model.Message;

        spinnerControl.Mode = model.SpinnerMode;

        if (model.State == LoadingVisualState.Loading)
        {
            stateIconControl.Visible = false;

            spinnerControl.Visible = true;
            spinnerControl.Start();
        }
        else
        {
            spinnerControl.Stop();
            spinnerControl.Visible = false;

            stateIconControl.State = model.State;
            stateIconControl.Visible = true;
            stateIconControl.BringToFront();
        }

        UpdateCardLayout();
        UpdateCardLocation();
        Invalidate();
    }

    public void ShowAnimated()
    {
        if (IsDisposed || _managedResourcesCleaned)
            return;

        autoCloseTimer.Stop();
        fadeTimer.Stop();

        if (!Visible)
        {
            _overlayAlpha = 0;
            _cardOffsetY = ScaleByDpi(10);
            Visible = true;
            BringToFront();
        }

        EnsureVisibleOnTop();

        _fadeDirection = 1;
        fadeTimer.Start();
    }

    public void HideAnimated()
    {
        if (IsDisposed || _managedResourcesCleaned)
            return;

        autoCloseTimer.Stop();

        if (!Visible)
        {
            CloseCore();
            return;
        }

        _fadeDirection = -1;
        fadeTimer.Start();
    }

    public void HideImmediate()
    {
        if (IsDisposed || _managedResourcesCleaned)
            return;

        CloseCore();
    }

    public void Release()
    {
        CleanupManagedResources(stopTimers: true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Color overlayColor = Color.FromArgb(
            _overlayAlpha,
            _overlayBaseColor.R,
            _overlayBaseColor.G,
            _overlayBaseColor.B);

        using SolidBrush brush = new(overlayColor);
        e.Graphics.FillRectangle(brush, ClientRectangle);
    }

    protected override void WndProc(ref Message m)
    {
        if (!_blockInput && m.Msg == WmNcHitTest)
        {
            m.Result = new IntPtr(HtTransparent);
            return;
        }

        base.WndProc(ref m);
    }

    private void ApplyPalette(LoadingPalette palette)
    {
        _targetOverlayAlpha = palette.OverlayBackColor.A;
        _overlayBaseColor = Color.FromArgb(
            255,
            palette.OverlayBackColor.R,
            palette.OverlayBackColor.G,
            palette.OverlayBackColor.B);

        _cardBorderColor = palette.CardBorderColor;

        panelCard.BackColor = palette.CardBackColor;
        lblTitle.ForeColor = palette.TitleForeColor;
        lblMessage.ForeColor = palette.MessageForeColor;

        spinnerControl.ApplyPalette(palette);
        stateIconControl.ApplyPalette(palette);
    }

    private static bool CanUseTarget(Control? target)
    {
        return target != null &&
               !target.IsDisposed &&
               !target.Disposing;
    }

    private void CloseCore()
    {
        fadeTimer.Stop();
        autoCloseTimer.Stop();

        _fadeDirection = 0;
        _isActive = false;
        _overlayAlpha = 0;
        _cardOffsetY = 0;
        _pendingAutoCloseMs = 0;

        spinnerControl.Stop();
        spinnerControl.Visible = true;
        stateIconControl.Visible = false;

        Visible = false;
        Invalidate();

        DetachFromTarget();

        Closed?.Invoke(this, EventArgs.Empty);
    }

    private void DetachFromTarget()
    {
        Control? parent = Parent;

        if (parent != null && !parent.IsDisposed && !parent.Disposing)
        {
            parent.Controls.Remove(this);
        }

        Unbind();
    }

    private void EnsureVisibleOnTop()
    {
        if (_targetControl == null || _targetControl.IsDisposed)
            return;

        if (!Visible)
            Visible = true;

        BringToFront();

        UpdateCardLayout();
        UpdateCardLocation();
        Invalidate();
    }

    private void UpdateCardLayout()
    {
        if (ClientSize.Width <= 0 || ClientSize.Height <= 0)
            return;

        if (!_showCard)
            return;

        int margin = ScaleByDpi(24);

        int cardMinWidth = ScaleByDpi(260);
        int cardMaxWidth = ScaleByDpi(380);

        int cardMinHeight = ScaleByDpi(150);
        int cardMaxHeight = ScaleByDpi(200);

        int availableWidth = Math.Max(1, ClientSize.Width - margin * 2);
        int availableHeight = Math.Max(1, ClientSize.Height - margin * 2);

        int cardWidth = Clamp(availableWidth, cardMinWidth, cardMaxWidth);
        int cardHeight = Clamp(availableHeight, cardMinHeight, cardMaxHeight);

        cardWidth = Math.Min(cardWidth, ClientSize.Width);
        cardHeight = Math.Min(cardHeight, ClientSize.Height);

        panelCard.Size = new Size(cardWidth, cardHeight);

        int topPadding = Math.Max(ScaleByDpi(14), cardHeight / 10);
        int iconSize = Clamp(cardHeight / 3, ScaleByDpi(42), ScaleByDpi(68));

        int iconX = (cardWidth - iconSize) / 2;
        int iconY = topPadding;

        spinnerControl.Location = new Point(iconX, iconY);
        spinnerControl.Size = new Size(iconSize, iconSize);

        stateIconControl.Location = new Point(iconX, iconY);
        stateIconControl.Size = new Size(iconSize, iconSize);

        int titleY = iconY + iconSize + ScaleByDpi(10);
        int titleHeight = ScaleByDpi(28);

        lblTitle.Location = new Point(ScaleByDpi(20), titleY);
        lblTitle.Size = new Size(
            Math.Max(1, cardWidth - ScaleByDpi(40)),
            titleHeight);

        int messageY = titleY + titleHeight + ScaleByDpi(4);
        int messageHeight = Math.Max(
            ScaleByDpi(28),
            cardHeight - messageY - ScaleByDpi(14));

        lblMessage.Location = new Point(ScaleByDpi(24), messageY);
        lblMessage.Size = new Size(
            Math.Max(1, cardWidth - ScaleByDpi(48)),
            messageHeight);

        UpdateCardRegion();
    }

    private void UpdateCardLocation()
    {
        if (!_showCard)
            return;

        int x = (ClientSize.Width - panelCard.Width) / 2;
        int y = (ClientSize.Height - panelCard.Height) / 2 + _cardOffsetY;

        if (x < 0)
            x = 0;

        if (y < 0)
            y = 0;

        panelCard.Location = new Point(x, y);
    }

    private void UpdateCardRegion()
    {
        if (panelCard.Width <= 1 || panelCard.Height <= 1)
            return;

        Rectangle rect = new(0, 0, panelCard.Width - 1, panelCard.Height - 1);

        using GraphicsPath path = CreateRoundedRectangle(
            rect,
            ScaleByDpi(LoadingDefaults.DefaultCardCornerRadius));

        panelCard.Region?.Dispose();
        panelCard.Region = new Region(path);
    }

    private static GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
    {
        GraphicsPath path = new();

        if (bounds.Width <= 0 || bounds.Height <= 0)
            return path;

        radius = Math.Max(1, radius);
        radius = Math.Min(radius, Math.Min(bounds.Width, bounds.Height) / 2);

        int d = radius * 2;

        path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
        path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
        path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
        path.CloseFigure();

        return path;
    }

    private void Unbind()
    {
        if (_targetControl != null)
        {
            _targetControl.Resize -= Target_Changed;
            _targetControl.VisibleChanged -= Target_Changed;
            _targetControl.Disposed -= Target_Disposed;
        }

        if (_hostForm != null)
        {
            _hostForm.Move -= HostForm_Changed;
            _hostForm.Resize -= HostForm_Changed;
            _hostForm.VisibleChanged -= HostForm_Changed;
            _hostForm.FormClosed -= HostForm_FormClosed;
        }

        _targetControl = null;
        _hostForm = null;
    }

    private void Target_Changed(object? sender, EventArgs e)
    {
        if (!_isActive)
            return;

        UpdateCardLayout();
        UpdateCardLocation();
        BringToFront();
        Invalidate();
    }

    private void HostForm_Changed(object? sender, EventArgs e)
    {
        if (!_isActive)
            return;

        UpdateCardLayout();
        UpdateCardLocation();
        BringToFront();
        Invalidate();
    }

    private void Target_Disposed(object? sender, EventArgs e)
    {
        HideImmediate();
    }

    private void HostForm_FormClosed(object? sender, FormClosedEventArgs e)
    {
        HideImmediate();
    }

    private void PanelCard_Paint(object? sender, PaintEventArgs e)
    {
        if (!_showCard)
            return;

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rect = new(0, 0, panelCard.Width - 1, panelCard.Height - 1);

        using GraphicsPath path = CreateRoundedRectangle(
            rect,
            ScaleByDpi(LoadingDefaults.DefaultCardCornerRadius));

        using Pen borderPen = new(_cardBorderColor, 1f);

        e.Graphics.DrawPath(borderPen, path);
    }

    private void PanelCard_Resize(object? sender, EventArgs e)
    {
        UpdateCardRegion();
    }

    private void LoadingOverlay_Resize(object? sender, EventArgs e)
    {
        UpdateCardLayout();
        UpdateCardLocation();
    }

    private void FadeTimer_Tick(object? sender, EventArgs e)
    {
        if (_fadeDirection > 0)
        {
            TickFadeIn();
            return;
        }

        if (_fadeDirection < 0)
        {
            TickFadeOut();
        }
    }

    private void TickFadeIn()
    {
        bool finished = true;

        if (_overlayAlpha < _targetOverlayAlpha)
        {
            _overlayAlpha += 8;

            if (_overlayAlpha > _targetOverlayAlpha)
                _overlayAlpha = _targetOverlayAlpha;

            finished = false;
        }

        if (_showCard && _cardOffsetY > 0)
        {
            _cardOffsetY -= ScaleByDpi(2);

            if (_cardOffsetY < 0)
                _cardOffsetY = 0;

            finished = false;
        }

        UpdateCardLocation();
        Invalidate();

        if (!finished)
            return;

        fadeTimer.Stop();
        _fadeDirection = 0;

        if (_pendingAutoCloseMs > 0 &&
            _currentState != LoadingVisualState.Loading)
        {
            autoCloseTimer.Interval = _pendingAutoCloseMs;
            autoCloseTimer.Start();
        }
    }

    private void TickFadeOut()
    {
        bool finished = true;

        if (_overlayAlpha > 0)
        {
            _overlayAlpha -= 10;

            if (_overlayAlpha < 0)
                _overlayAlpha = 0;

            finished = false;
        }

        int maxOffset = ScaleByDpi(8);

        if (_showCard && _cardOffsetY < maxOffset)
        {
            _cardOffsetY += ScaleByDpi(2);
            finished = false;
        }

        UpdateCardLocation();
        Invalidate();

        if (!finished)
            return;

        fadeTimer.Stop();
        _fadeDirection = 0;
        CloseCore();
    }

    private void AutoCloseTimer_Tick(object? sender, EventArgs e)
    {
        autoCloseTimer.Stop();
        HideAnimated();
    }

    private void LoadingOverlay_Disposed(object? sender, EventArgs e)
    {
        CleanupManagedResources(stopTimers: false);
    }

    private void CleanupManagedResources(bool stopTimers)
    {
        if (_managedResourcesCleaned)
            return;

        _managedResourcesCleaned = true;

        Disposed -= LoadingOverlay_Disposed;

        fadeTimer.Tick -= FadeTimer_Tick;
        autoCloseTimer.Tick -= AutoCloseTimer_Tick;

        panelCard.Paint -= PanelCard_Paint;
        panelCard.Resize -= PanelCard_Resize;
        Resize -= LoadingOverlay_Resize;

        if (stopTimers)
        {
            fadeTimer.Stop();
            autoCloseTimer.Stop();
            spinnerControl.Stop();
        }

        panelCard.Region?.Dispose();
        panelCard.Region = null;

        DetachFromTarget();
    }

    private int ScaleByDpi(int value)
    {
        int dpi = DeviceDpi <= 0 ? 96 : DeviceDpi;
        return Math.Max(1, value * dpi / 96);
    }

    private static int Clamp(int value, int min, int max)
    {
        if (min > max)
            (min, max) = (max, min);

        if (value < min)
            return min;

        if (value > max)
            return max;

        return value;
    }
}