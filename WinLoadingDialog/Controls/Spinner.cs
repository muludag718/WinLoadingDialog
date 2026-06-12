using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using WinLoadingDialog.Theming;
using Timer = System.Windows.Forms.Timer;

namespace WinLoadingDialog.Controls;

/// <summary>
/// A customizable animated loading indicator with multiple spinner modes.
/// </summary>
[ToolboxItem(true)]
public sealed class Spinner : Control
{
    private readonly Timer _timer;
    private readonly Stopwatch _watch;

    private bool _requestedRunning;
    private bool _autoStart;
    private bool _autoStartApplied;
    private bool _previewInDesigner = true;

    private SpinnerMode _mode = SpinnerMode.Arc;
    private Color _spinnerColor = Color.FromArgb(0, 122, 204);
    private Color _trackColor = Color.Gainsboro;
    private float _thickness = 6f;
    private float _speed = 180f;
    private int _segmentCount = 12;
    private float _sweepAngle = 90f;

    public Spinner()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor,
            true);

        BackColor = Color.Transparent;
        Size = new Size(72, 72);

        _watch = new Stopwatch();

        _timer = new Timer
        {
            Interval = 16
        };

        _timer.Tick += Timer_Tick;
    }

    private bool InDesignerHost =>
        LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
        DesignMode ||
        Site?.DesignMode == true;

    [Category("Behavior")]
    [DefaultValue(SpinnerMode.Arc)]
    public SpinnerMode Mode
    {
        get => _mode;
        set
        {
            if (_mode == value)
                return;

            _mode = value;
            Invalidate();
        }
    }

    [Category("Behavior")]
    [DefaultValue(false)]
    public bool AutoStart
    {
        get => _autoStart;
        set
        {
            if (_autoStart == value)
                return;

            _autoStart = value;

            if (!_autoStart)
                _autoStartApplied = true;

            TryApplyAutoStart();
            UpdateAnimationState();
        }
    }

    [Category("Behavior")]
    [DefaultValue(true)]
    public bool PreviewInDesigner
    {
        get => _previewInDesigner;
        set
        {
            if (_previewInDesigner == value)
                return;

            _previewInDesigner = value;
            UpdateAnimationState();
        }
    }

    [Category("Appearance")]
    public Color SpinnerColor
    {
        get => _spinnerColor;
        set
        {
            if (_spinnerColor == value)
                return;

            _spinnerColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color TrackColor
    {
        get => _trackColor;
        set
        {
            if (_trackColor == value)
                return;

            _trackColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(6f)]
    public float Thickness
    {
        get => _thickness;
        set
        {
            float newValue = Math.Max(1f, value);

            if (Math.Abs(_thickness - newValue) < float.Epsilon)
                return;

            _thickness = newValue;
            Invalidate();
        }
    }

    [Category("Behavior")]
    [DefaultValue(180f)]
    public float Speed
    {
        get => _speed;
        set
        {
            float newValue = Math.Max(1f, value);

            if (Math.Abs(_speed - newValue) < float.Epsilon)
                return;

            _speed = newValue;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(12)]
    public int SegmentCount
    {
        get => _segmentCount;
        set
        {
            int newValue = Math.Max(3, value);

            if (_segmentCount == newValue)
                return;

            _segmentCount = newValue;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(90f)]
    public float SweepAngle
    {
        get => _sweepAngle;
        set
        {
            float newValue = Math.Max(5f, Math.Min(360f, value));

            if (Math.Abs(_sweepAngle - newValue) < float.Epsilon)
                return;

            _sweepAngle = newValue;
            Invalidate();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsRunning => _timer.Enabled;

    public void ApplyPalette(LoadingPalette palette)
    {
        ArgumentNullException.ThrowIfNull(palette);

        SpinnerColor = palette.SpinnerColor;
        TrackColor = palette.SpinnerTrackColor;
    }

    public void Start()
    {
        _autoStartApplied = true;
        _requestedRunning = true;
        _watch.Restart();
        UpdateAnimationState();
    }

    public void Stop()
    {
        _autoStartApplied = true;
        _requestedRunning = false;
        UpdateAnimationState();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        TryApplyAutoStart();
        UpdateAnimationState();
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
        base.OnVisibleChanged(e);

        TryApplyAutoStart();
        UpdateAnimationState();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _timer.Tick -= Timer_Tick;
            _timer.Stop();
            _timer.Dispose();
            _watch.Stop();
        }

        base.Dispose(disposing);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        switch (Mode)
        {
            case SpinnerMode.Arc:
                DrawArc(e.Graphics);
                break;

            case SpinnerMode.Circle:
                DrawCircle(e.Graphics);
                break;

            case SpinnerMode.CircularProgress:
                DrawCircularProgress(e.Graphics);
                break;

            case SpinnerMode.Dots:
                DrawDots(e.Graphics);
                break;

            case SpinnerMode.Pulse:
                DrawPulse(e.Graphics);
                break;

            case SpinnerMode.Ring:
                DrawRing(e.Graphics);
                break;

            case SpinnerMode.Bars:
                DrawBars(e.Graphics);
                break;

            case SpinnerMode.DualRing:
                DrawDualRing(e.Graphics);
                break;

            default:
                DrawArc(e.Graphics);
                break;
        }
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        Invalidate();
    }

    private void TryApplyAutoStart()
    {
        if (InDesignerHost)
            return;

        if (!_autoStart || _autoStartApplied || !Visible || IsDisposed)
            return;

        _autoStartApplied = true;
        _requestedRunning = true;
        _watch.Restart();
    }

    private void UpdateAnimationState()
    {
        if (IsDisposed)
            return;

        bool shouldRun = InDesignerHost
            ? _previewInDesigner && Visible
            : _requestedRunning && Visible;

        if (shouldRun)
        {
            if (!_watch.IsRunning)
                _watch.Start();

            if (!_timer.Enabled)
                _timer.Start();
        }
        else
        {
            if (_timer.Enabled)
                _timer.Stop();

            if (_watch.IsRunning)
                _watch.Stop();
        }

        Invalidate();
    }

    private RectangleF GetSquareBounds(float padding)
    {
        float size = Math.Min(ClientSize.Width, ClientSize.Height) - padding * 2f;

        if (size <= 0f)
            return RectangleF.Empty;

        float x = (ClientSize.Width - size) / 2f;
        float y = (ClientSize.Height - size) / 2f;

        return new RectangleF(x, y, size, size);
    }

    private float GetAnimatedAngle()
    {
        return (float)((_watch.Elapsed.TotalMilliseconds * (Speed / 1000f)) % 360f);
    }

    private double GetElapsedMs()
    {
        return _watch.Elapsed.TotalMilliseconds;
    }

    private void DrawArc(Graphics g)
    {
        RectangleF rect = GetSquareBounds(Thickness + 2f);

        if (rect.IsEmpty)
            return;

        double t = GetElapsedMs();

        if (!_timer.Enabled)
            t = 600d;

        float startAngle = GetAnimatedAngle();
        float pulse = (float)((Math.Sin(t / 220.0) + 1.0) / 2.0);
        float sweep = 42f + 96f * pulse;

        using Pen mainPen = new(SpinnerColor, Thickness)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        using Pen tailPen = new(Color.FromArgb(90, SpinnerColor), Thickness)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        g.DrawArc(mainPen, rect, startAngle, sweep);
        g.DrawArc(tailPen, rect, startAngle + sweep + 10f, 24f);
    }

    private void DrawCircle(Graphics g)
    {
        RectangleF rect = GetSquareBounds(Thickness + 2f);

        if (rect.IsEmpty)
            return;

        float cx = rect.X + rect.Width / 2f;
        float cy = rect.Y + rect.Height / 2f;

        float outerRadius = rect.Width / 2f;
        float lineLength = Math.Max(outerRadius * 0.32f, Thickness * 1.5f);
        float innerRadius = Math.Max(2f, outerRadius - lineLength);

        float baseAngle = GetAnimatedAngle();
        float step = 360f / SegmentCount;

        for (int i = 0; i < SegmentCount; i++)
        {
            float alphaFactor = (float)(i + 1) / SegmentCount;
            int alpha = (int)(255 * alphaFactor);

            using Pen pen = new(Color.FromArgb(alpha, SpinnerColor), Thickness)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };

            float degrees = baseAngle + step * i;
            float radians = degrees * (float)Math.PI / 180f;

            float x1 = cx + (float)Math.Cos(radians) * innerRadius;
            float y1 = cy + (float)Math.Sin(radians) * innerRadius;

            float x2 = cx + (float)Math.Cos(radians) * outerRadius;
            float y2 = cy + (float)Math.Sin(radians) * outerRadius;

            g.DrawLine(pen, x1, y1, x2, y2);
        }
    }

    private void DrawCircularProgress(Graphics g)
    {
        RectangleF rect = GetSquareBounds(Thickness + 2f);

        if (rect.IsEmpty)
            return;

        float angle = GetAnimatedAngle();

        using Pen trackPen = new(TrackColor, Thickness)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        using Pen progressPen = new(SpinnerColor, Thickness)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        g.DrawArc(trackPen, rect, 0f, 359.9f);
        g.DrawArc(progressPen, rect, angle, SweepAngle);
    }

    private void DrawDots(Graphics g)
    {
        RectangleF rect = GetSquareBounds(2f);

        if (rect.IsEmpty)
            return;

        int count = Math.Max(3, SegmentCount);
        double t = GetElapsedMs();

        float spacing = rect.Width / (count + 1);
        float maxRadius = Math.Max(2f, Math.Min(rect.Width, rect.Height) / 12f);
        float centerY = rect.Y + rect.Height / 2f;

        for (int i = 0; i < count; i++)
        {
            double phase = t / 180.0 + i * 0.65;
            float factor = (float)((Math.Sin(phase) + 1.0) / 2.0);
            float radius = maxRadius * (0.45f + 0.55f * factor);

            int alpha = 80 + (int)(175 * factor);

            using SolidBrush brush = new(Color.FromArgb(alpha, SpinnerColor));

            float cx = rect.X + spacing * (i + 1);

            g.FillEllipse(
                brush,
                cx - radius,
                centerY - radius,
                radius * 2f,
                radius * 2f);
        }
    }

    private void DrawPulse(Graphics g)
    {
        RectangleF rect = GetSquareBounds(2f);

        if (rect.IsEmpty)
            return;

        double t = GetElapsedMs();
        float pulse = (float)((Math.Sin(t / 250.0) + 1.0) / 2.0);

        float maxSize = Math.Min(rect.Width, rect.Height);
        float size = maxSize * (0.45f + 0.35f * pulse);

        int alpha = 70 + (int)(130 * (1f - pulse));

        using SolidBrush pulseBrush = new(Color.FromArgb(alpha, SpinnerColor));
        using SolidBrush centerBrush = new(SpinnerColor);

        float x = rect.X + (rect.Width - size) / 2f;
        float y = rect.Y + (rect.Height - size) / 2f;

        g.FillEllipse(pulseBrush, x, y, size, size);

        float centerSize = maxSize * 0.34f;
        float centerX = rect.X + (rect.Width - centerSize) / 2f;
        float centerY = rect.Y + (rect.Height - centerSize) / 2f;

        g.FillEllipse(centerBrush, centerX, centerY, centerSize, centerSize);
    }

    private void DrawRing(Graphics g)
    {
        RectangleF rect = GetSquareBounds(Thickness + 2f);

        if (rect.IsEmpty)
            return;

        float angle = GetAnimatedAngle();

        using Pen trackPen = new(Color.FromArgb(80, TrackColor), Thickness)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        using Pen ringPen = new(SpinnerColor, Thickness)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        g.DrawArc(trackPen, rect, 0f, 359.9f);
        g.DrawArc(ringPen, rect, angle, 270f);
    }

    private void DrawBars(Graphics g)
    {
        RectangleF rect = GetSquareBounds(2f);

        if (rect.IsEmpty)
            return;

        int count = Math.Max(3, SegmentCount);
        double t = GetElapsedMs();

        float gap = Math.Max(2f, rect.Width * 0.035f);
        float barWidth = Math.Max(2f, (rect.Width - gap * (count - 1)) / count);
        float maxHeight = rect.Height;
        float minHeight = rect.Height * 0.28f;

        for (int i = 0; i < count; i++)
        {
            double phase = t / 160.0 + i * 0.5;
            float factor = (float)((Math.Sin(phase) + 1.0) / 2.0);

            float height = minHeight + (maxHeight - minHeight) * factor;
            float x = rect.X + i * (barWidth + gap);
            float y = rect.Y + (rect.Height - height) / 2f;

            int alpha = 90 + (int)(165 * factor);

            using SolidBrush brush = new(Color.FromArgb(alpha, SpinnerColor));

            using GraphicsPath path = CreateRoundedRectangle(
                new RectangleF(x, y, barWidth, height),
                barWidth / 2f);

            g.FillPath(brush, path);
        }
    }

    private void DrawDualRing(Graphics g)
    {
        RectangleF outer = GetSquareBounds(Thickness + 2f);

        if (outer.IsEmpty)
            return;

        RectangleF inner = outer;
        float inset = Math.Max(Thickness * 1.8f, outer.Width * 0.16f);
        inner.Inflate(-inset, -inset);

        float angle = GetAnimatedAngle();

        using Pen outerPen = new(SpinnerColor, Thickness)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        using Pen innerPen = new(Color.FromArgb(150, SpinnerColor), Math.Max(1f, Thickness * 0.75f))
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        g.DrawArc(outerPen, outer, angle, 220f);
        g.DrawArc(innerPen, inner, -angle, 220f);
    }

    private static GraphicsPath CreateRoundedRectangle(RectangleF bounds, float radius)
    {
        GraphicsPath path = new();

        if (bounds.Width <= 0 || bounds.Height <= 0)
            return path;

        radius = Math.Max(1f, radius);
        radius = Math.Min(radius, Math.Min(bounds.Width, bounds.Height) / 2f);

        float d = radius * 2f;

        path.AddArc(bounds.X, bounds.Y, d, d, 180f, 90f);
        path.AddArc(bounds.Right - d, bounds.Y, d, d, 270f, 90f);
        path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0f, 90f);
        path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90f, 90f);
        path.CloseFigure();

        return path;
    }
}