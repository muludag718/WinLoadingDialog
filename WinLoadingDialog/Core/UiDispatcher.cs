namespace WinLoadingDialog.Core;

/// <summary>
/// Executes actions safely on the UI thread of a target control.
/// </summary>
internal static class UiDispatcher
{
    internal static void Execute(Control target, Action action)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(action);

        if (target.IsDisposed || target.Disposing)
            return;

        Control invoker = ResolveInvoker(target);

        if (invoker.IsDisposed || invoker.Disposing)
            return;

        if (!invoker.IsHandleCreated)
        {
            throw new InvalidOperationException(
                "The target control handle must be created before using LoadingService. " +
                "Call LoadingService from Form.Load, Form.Shown, or later.");
        }

        if (invoker.InvokeRequired)
        {
            try
            {
                invoker.BeginInvoke(action);
            }
            catch (InvalidOperationException)
            {
                // The form may be closing while the invoke is queued.
            }
         

            return;
        }

        action();
    }

    private static Control ResolveInvoker(Control target)
    {
        Form? form = target.FindForm();

        if (form != null &&
            !form.IsDisposed &&
            !form.Disposing &&
            form.IsHandleCreated)
        {
            return form;
        }

        return target;
    }
}