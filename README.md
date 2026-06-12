# WinLoadingDialog

A lightweight, modern, and customizable loading overlay component for Windows Forms applications.

WinLoadingDialog helps you display clean loading dialogs on forms, panels, or any WinForms control. It supports multiple spinner animations, success/error states, themes, localization-friendly text configuration, async helper methods, and target-based session management.

---

## ✨ Features

- Form-level and control-level loading overlays
- 8 built-in spinner modes
- Light, dark, system, and custom themes
- English, Turkish, and custom text support
- Success and error result states
- Async helper methods
- Disposable loading scopes
- Target-based session management
- DPI-aware responsive layout
- MVP-style internal structure
- Clean public API through `LoadingService`

---

## 🌀 Spinner Modes

WinLoadingDialog includes 8 spinner modes:

| Mode | Description |
| --- | --- |
| `Arc` | Rotating arc with a soft tail |
| `Circle` | Classic segmented circular spinner |
| `CircularProgress` | Circular progress style spinner with track |
| `Dots` | Animated horizontal dots |
| `Pulse` | Pulsing circle animation |
| `Ring` | Rotating ring animation |
| `Bars` | Animated vertical bars |
| `DualRing` | Two rotating rings moving in opposite directions |

Example:

```csharp
LoadingService.Show(this, new LoadingOptions
{
    Message = "Loading data...",
    SpinnerMode = SpinnerMode.DualRing
});
```

---

## 🚀 Basic Usage

```csharp
using WinLoadingDialog.Services;

LoadingService.Show(this);

// Do work...

LoadingService.Hide(this);
```

---

## 💬 Show With Message

```csharp
LoadingService.Show(this, "Saving data...");

// Do work...

LoadingService.Success(this, "Saved successfully.");
```

---

## ⚙️ Using LoadingOptions

`LoadingOptions` is the main configuration object. You can use it to control text, theme, spinner mode, success/error messages, and behavior.

```csharp
using WinLoadingDialog.Controls;
using WinLoadingDialog.Localization;
using WinLoadingDialog.Options;
using WinLoadingDialog.Services;
using WinLoadingDialog.Theming;

LoadingService.Show(this, new LoadingOptions
{
    Message = "Saving data...",
    SpinnerMode = SpinnerMode.DualRing,
    Theme = LoadingTheme.Dark,
    Texts = LoadingTexts.English
});
```

---

## 🌍 Localization / Texts

The default text language is English.

### English

```csharp
LoadingService.Show(this, new LoadingOptions
{
    Texts = LoadingTexts.English,
    Message = "Loading records..."
});
```

### Turkish

```csharp
LoadingService.Show(this, new LoadingOptions
{
    Texts = LoadingTexts.Turkish,
    Message = "Veriler yükleniyor...",
    SpinnerMode = SpinnerMode.Circle,
    Theme = LoadingTheme.Light
});
```

### Custom Texts

```csharp
LoadingService.Show(this, new LoadingOptions
{
    Texts = LoadingTexts.FromValues(
        loadingTitle: "Processing",
        loadingMessage: "Please wait...",
        successTitle: "Done",
        successMessage: "Completed successfully.",
        errorTitle: "Failed",
        errorMessage: "Something went wrong."
    )
});
```

---

## 🎨 Themes

WinLoadingDialog supports:

- `LoadingTheme.Light`
- `LoadingTheme.Dark`
- `LoadingTheme.System`
- `LoadingTheme.FromPalette(...)`

### Light Theme

```csharp
LoadingService.Show(this, new LoadingOptions
{
    Theme = LoadingTheme.Light
});
```

### Dark Theme

```csharp
LoadingService.Show(this, new LoadingOptions
{
    Theme = LoadingTheme.Dark
});
```

### System Theme

```csharp
LoadingService.Show(this, new LoadingOptions
{
    Theme = LoadingTheme.System
});
```

### Custom Theme

```csharp
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

LoadingService.Show(this, new LoadingOptions
{
    Theme = LoadingTheme.FromPalette(palette),
    SpinnerMode = SpinnerMode.Dots,
    Message = "Custom theme loading..."
});
```

---

## ✅ Success State

```csharp
LoadingService.Success(this, "Operation completed successfully.");
```

With options:

```csharp
LoadingService.Success(this, new LoadingOptions
{
    SuccessTitle = "Saved",
    SuccessMessage = "Your changes were saved.",
    Theme = LoadingTheme.Light
});
```

---

## ❌ Error State

```csharp
LoadingService.Error(this, "Something went wrong.");
```

With options:

```csharp
LoadingService.Error(this, new LoadingOptions
{
    ErrorTitle = "Failed",
    ErrorMessage = "Unable to save changes.",
    Theme = LoadingTheme.Dark
});
```

---

## ⏳ RunAsync

`RunAsync` automatically shows the overlay before the operation and hides it when the task completes.

```csharp
await LoadingService.RunAsync(
    this,
    async () =>
    {
        await Task.Delay(1500);
    },
    new LoadingOptions
    {
        Message = "Loading data...",
        SpinnerMode = SpinnerMode.CircularProgress
    });
```

---

## 📦 Begin Scope

`Begin` returns an `IDisposable`. When the scope is disposed, the overlay is hidden automatically.

```csharp
using (LoadingService.Begin(this, "Loading..."))
{
    await Task.Delay(1500);
}
```

This is useful when you want a clean and safe loading lifecycle.

---

## 🧩 Panel / Control Overlay

The target can be any WinForms `Control`, not just a `Form`.

```csharp
LoadingService.Show(panel1, new LoadingOptions
{
    Message = "Panel is loading...",
    SpinnerMode = SpinnerMode.Bars
});
```

---

## 🧠 Multiple Targets

Each target has its own loading session.

```csharp
LoadingService.Show(this, "Form loading...");
LoadingService.Show(panel1, "Panel loading...");
LoadingService.Show(panel2, "Another panel loading...");
```

This means overlays do not overwrite each other.

---

## ⚠️ Important Usage Note

Call `LoadingService` after the target control handle has been created.

Recommended places:

- `Form.Load`
- `Form.Shown`
- `Button.Click`
- Async event handlers
- Any point after the target control is visible or handle-created

Avoid calling it directly inside a form constructor before the target handle exists.

---

## 🏗️ Project Structure

```txt
WinLoadingDialog/
  Controls/
    Spinner.cs
    SpinnerMode.cs
    StateIconControl.cs

  Core/
    LoadingSession.cs
    LoadingSessionManager.cs
    LoadingScope.cs
    UiDispatcher.cs

  Localization/
    LoadingTexts.cs

  Models/
    LoadingVisualState.cs

  Options/
    LoadingDefaults.cs
    LoadingOptions.cs

  Services/
    LoadingService.cs

  Theming/
    LoadingPalette.cs
    LoadingTheme.cs
    LoadingThemeMode.cs

  UI/
    ILoadingOverlayView.cs
    LoadingOverlayViewModel.cs
    LoadingOverlayPresenter.cs
    LoadingOverlay.cs
    LoadingOverlay.Designer.cs
```

---

## 🧪 Demo App

The included demo project shows:

- All spinner modes
- Light theme
- Dark theme
- Custom theme
- English texts
- Turkish texts
- Success and error states
- `RunAsync`
- `Begin` scope
- Panel-level overlay

---

## 📌 Roadmap Ideas

Possible future improvements:

- NuGet package publishing
- More spinner animations
- Built-in progress percentage support
- Cancellation button support
- More localization presets
- Unit tests for core/session behavior

---

## 📄 License

MIT
