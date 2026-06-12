using System.Drawing;
using System.Windows.Forms;

namespace WinLoadingDialog.Theming;

public sealed class LoadingTheme
{
    public LoadingThemeMode Mode { get; init; } = LoadingThemeMode.System;

    public LoadingPalette? CustomPalette { get; init; }

    public LoadingPalette Resolve(Control? target = null)
    {
        return Mode switch
        {
            LoadingThemeMode.Light => LoadingPalette.Light,
            LoadingThemeMode.Dark => LoadingPalette.Dark,
            LoadingThemeMode.Custom => CustomPalette ?? LoadingPalette.Light,
            LoadingThemeMode.System => ResolveSystemTheme(target),
            _ => LoadingPalette.Light
        };
    }

    public static LoadingTheme Light { get; } = new()
    {
        Mode = LoadingThemeMode.Light
    };

    public static LoadingTheme Dark { get; } = new()
    {
        Mode = LoadingThemeMode.Dark
    };

    public static LoadingTheme System { get; } = new()
    {
        Mode = LoadingThemeMode.System
    };

    public static LoadingTheme FromPalette(LoadingPalette palette)
    {
        ArgumentNullException.ThrowIfNull(palette);

        return new LoadingTheme
        {
            Mode = LoadingThemeMode.Custom,
            CustomPalette = palette
        };
    }

    private static LoadingPalette ResolveSystemTheme(Control? target)
    {
        if (target == null)
            return LoadingPalette.Light;

        Color backColor = target.BackColor;

        if (backColor == Color.Empty ||
            backColor == Color.Transparent)
        {
            Form? form = target.FindForm();

            if (form != null &&
                form.BackColor != Color.Empty &&
                form.BackColor != Color.Transparent)
            {
                backColor = form.BackColor;
            }
            else
            {
                backColor = SystemColors.Control;
            }
        }

        int brightness = (backColor.R + backColor.G + backColor.B) / 3;

        return brightness < 128
            ? LoadingPalette.Dark
            : LoadingPalette.Light;
    }
}