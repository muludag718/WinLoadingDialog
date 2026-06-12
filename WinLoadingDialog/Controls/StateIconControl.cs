using System.ComponentModel;
using System.Drawing.Drawing2D;
using WinLoadingDialog.Models;
using WinLoadingDialog.Theming;

namespace WinLoadingDialog.Controls;

/// <summary>
/// Displays the final success or error state icon used by the loading overlay.
/// </summary>
[ToolboxItem(false)]
public sealed class StateIconControl : Control
{
    private LoadingVisualState _state = LoadingVisualState.Success;
    private Color _successColor = Color.FromArgb(46, 160, 67);
    private Color _errorColor = Color.FromArgb(220, 53, 69);
    private float _thickness = 6f;

    public StateIconControl()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor,
            true);

        BackColor = Color.Transparent;
        Size = new Size(64, 64);
    }

    [Category("Appearance")]
    [DefaultValue(LoadingVisualState.Success)]
    public LoadingVisualState State
    {
        get => _state;
        set
        {
            if (_state == value)
                return;

            _state = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color SuccessColor
    {
        get => _successColor;
        set
        {
            if (_successColor == value)
                return;

            _successColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color ErrorColor
    {
        get => _errorColor;
        set
        {
            if (_errorColor == value)
                return;

            _errorColor = value;
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

    public void ApplyPalette(LoadingPalette palette)
    {
        ArgumentNullException.ThrowIfNull(palette);

        SuccessColor = palette.SuccessColor;
        ErrorColor = palette.ErrorColor;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        switch (State)
        {
            case LoadingVisualState.Success:
                DrawSuccess(e.Graphics);
                break;

            case LoadingVisualState.Error:
                DrawError(e.Graphics);
                break;

            case LoadingVisualState.Loading:
            default:
                break;
        }
    }

    private RectangleF GetIconBounds()
    {
        float padding = Math.Max(Thickness + 2f, 6f);
        float size = Math.Min(ClientSize.Width, ClientSize.Height) - padding * 2f;

        if (size <= 0f)
            return RectangleF.Empty;

        float x = (ClientSize.Width - size) / 2f;
        float y = (ClientSize.Height - size) / 2f;

        return new RectangleF(x, y, size, size);
    }

    private void DrawSuccess(Graphics g)
    {
        RectangleF rect = GetIconBounds();

        if (rect.IsEmpty)
            return;

        using Pen circlePen = new(SuccessColor, Math.Max(1f, Thickness * 0.72f));
        using Pen checkPen = new(SuccessColor, Thickness)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round,
            LineJoin = LineJoin.Round
        };

        g.DrawEllipse(circlePen, rect);

        PointF p1 = new(
            rect.X + rect.Width * 0.27f,
            rect.Y + rect.Height * 0.53f);

        PointF p2 = new(
            rect.X + rect.Width * 0.43f,
            rect.Y + rect.Height * 0.68f);

        PointF p3 = new(
            rect.X + rect.Width * 0.74f,
            rect.Y + rect.Height * 0.34f);

        g.DrawLines(checkPen, new[] { p1, p2, p3 });
    }

    private void DrawError(Graphics g)
    {
        RectangleF rect = GetIconBounds();

        if (rect.IsEmpty)
            return;

        using Pen circlePen = new(ErrorColor, Math.Max(1f, Thickness * 0.72f));
        using Pen crossPen = new(ErrorColor, Thickness)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        g.DrawEllipse(circlePen, rect);

        float inset = rect.Width * 0.31f;

        PointF p1 = new(rect.X + inset, rect.Y + inset);
        PointF p2 = new(rect.Right - inset, rect.Bottom - inset);

        PointF p3 = new(rect.Right - inset, rect.Y + inset);
        PointF p4 = new(rect.X + inset, rect.Bottom - inset);

        g.DrawLine(crossPen, p1, p2);
        g.DrawLine(crossPen, p3, p4);
    }
}