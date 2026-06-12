using WinLoadingDialog.Core;
using WinLoadingDialog.Options;

namespace WinLoadingDialog.Services;

/// <summary>
/// Provides a simple public API for showing loading overlays on WinForms controls.
/// </summary>
public static class LoadingService
{
    private static readonly LoadingSessionManager SessionManager = new();

    public static void Show(Control target)
    {
        Show(target, LoadingOptions.Default);
    }

    public static void Show(Control target, string message)
    {
        Show(target, LoadingOptions.Default.WithMessage(message));
    }

    public static void Show(Control target, string message, string title)
    {
        Show(target, LoadingOptions.Default.WithMessage(message, title));
    }

    public static void Show(Control target, LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(target);

        SessionManager.Show(target, options ?? LoadingOptions.Default);
    }

    public static void Update(string message)
    {
        Update(LoadingOptions.Default.WithMessage(message));
    }

    public static void Update(string message, string title)
    {
        Update(LoadingOptions.Default.WithMessage(message, title));
    }

    public static void Update(LoadingOptions options)
    {
        SessionManager.UpdateLast(options ?? LoadingOptions.Default);
    }

    public static void Update(Control target, string message)
    {
        Update(target, LoadingOptions.Default.WithMessage(message));
    }

    public static void Update(Control target, string message, string title)
    {
        Update(target, LoadingOptions.Default.WithMessage(message, title));
    }

    public static void Update(Control target, LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(target);

        SessionManager.Update(target, options ?? LoadingOptions.Default);
    }

    public static void Success()
    {
        Success(LoadingOptions.Default);
    }

    public static void Success(string message)
    {
        Success(LoadingOptions.Default.WithSuccess(message));
    }

    public static void Success(string message, string title)
    {
        Success(LoadingOptions.Default.WithSuccess(message, title));
    }

    public static void Success(LoadingOptions options)
    {
        SessionManager.SuccessLast(options ?? LoadingOptions.Default);
    }

    public static void Success(Control target)
    {
        Success(target, LoadingOptions.Default);
    }

    public static void Success(Control target, string message)
    {
        Success(target, LoadingOptions.Default.WithSuccess(message));
    }

    public static void Success(Control target, string message, string title)
    {
        Success(target, LoadingOptions.Default.WithSuccess(message, title));
    }

    public static void Success(Control target, LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(target);

        SessionManager.Success(target, options ?? LoadingOptions.Default);
    }

    public static void Error()
    {
        Error(LoadingOptions.Default);
    }

    public static void Error(string message)
    {
        Error(LoadingOptions.Default.WithError(message));
    }

    public static void Error(string message, string title)
    {
        Error(LoadingOptions.Default.WithError(message, title));
    }

    public static void Error(LoadingOptions options)
    {
        SessionManager.ErrorLast(options ?? LoadingOptions.Default);
    }

    public static void Error(Control target)
    {
        Error(target, LoadingOptions.Default);
    }

    public static void Error(Control target, string message)
    {
        Error(target, LoadingOptions.Default.WithError(message));
    }

    public static void Error(Control target, string message, string title)
    {
        Error(target, LoadingOptions.Default.WithError(message, title));
    }

    public static void Error(Control target, LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(target);

        SessionManager.Error(target, options ?? LoadingOptions.Default);
    }

    public static void Hide()
    {
        SessionManager.HideLast();
    }

    public static void Hide(Control target)
    {
        ArgumentNullException.ThrowIfNull(target);

        SessionManager.Hide(target);
    }

    public static void ForceDispose()
    {
        SessionManager.ForceDisposeAll();
    }

    public static void ForceDispose(Control target)
    {
        ArgumentNullException.ThrowIfNull(target);

        SessionManager.ForceDispose(target);
    }

    public static IDisposable Begin(Control target)
    {
        return Begin(target, LoadingOptions.Default);
    }

    public static IDisposable Begin(Control target, string message)
    {
        return Begin(target, LoadingOptions.Default.WithMessage(message));
    }

    public static IDisposable Begin(Control target, string message, string title)
    {
        return Begin(target, LoadingOptions.Default.WithMessage(message, title));
    }

    public static IDisposable Begin(Control target, LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(target);

        return SessionManager.Begin(target, options ?? LoadingOptions.Default);
    }

    public static async Task RunAsync(Control target, Func<Task> action)
    {
        await RunAsync(target, action, LoadingOptions.Default);
    }

    public static async Task RunAsync(
        Control target,
        Func<Task> action,
        string message)
    {
        await RunAsync(target, action, LoadingOptions.Default.WithMessage(message));
    }

    public static async Task RunAsync(
        Control target,
        Func<Task> action,
        string message,
        string title)
    {
        await RunAsync(target, action, LoadingOptions.Default.WithMessage(message, title));
    }

    public static async Task RunAsync(
        Control target,
        Func<Task> action,
        LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(action);

        Show(target, options ?? LoadingOptions.Default);

        try
        {
            await action();
        }
        finally
        {
            Hide(target);
        }
    }

    public static async Task RunAsync(
        Control target,
        Func<CancellationToken, Task> action,
        CancellationToken cancellationToken)
    {
        await RunAsync(target, action, cancellationToken, LoadingOptions.Default);
    }

    public static async Task RunAsync(
        Control target,
        Func<CancellationToken, Task> action,
        CancellationToken cancellationToken,
        string message)
    {
        await RunAsync(
            target,
            action,
            cancellationToken,
            LoadingOptions.Default.WithMessage(message));
    }

    public static async Task RunAsync(
        Control target,
        Func<CancellationToken, Task> action,
        CancellationToken cancellationToken,
        string message,
        string title)
    {
        await RunAsync(
            target,
            action,
            cancellationToken,
            LoadingOptions.Default.WithMessage(message, title));
    }

    public static async Task RunAsync(
        Control target,
        Func<CancellationToken, Task> action,
        CancellationToken cancellationToken,
        LoadingOptions options)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(action);

        Show(target, options ?? LoadingOptions.Default);

        try
        {
            await action(cancellationToken);
        }
        finally
        {
            Hide(target);
        }
    }
}