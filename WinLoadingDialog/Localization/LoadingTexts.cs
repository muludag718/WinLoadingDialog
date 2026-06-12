namespace WinLoadingDialog.Localization;

public sealed class LoadingTexts
{
    public string LoadingTitle { get; init; } = "Loading";

    public string LoadingMessage { get; init; } = "Please wait...";

    public string SuccessTitle { get; init; } = "Completed";

    public string SuccessMessage { get; init; } = "Operation completed successfully.";

    public string ErrorTitle { get; init; } = "Error";

    public string ErrorMessage { get; init; } = "An error occurred.";

    public static LoadingTexts English { get; } = new();

    public static LoadingTexts Turkish { get; } = new()
    {
        LoadingTitle = "Yükleniyor",
        LoadingMessage = "Lütfen bekleyin...",
        SuccessTitle = "Tamamlandı",
        SuccessMessage = "İşlem başarıyla tamamlandı.",
        ErrorTitle = "Hata",
        ErrorMessage = "Bir hata oluştu."
    };

    public static LoadingTexts FromValues(
        string? loadingTitle = null,
        string? loadingMessage = null,
        string? successTitle = null,
        string? successMessage = null,
        string? errorTitle = null,
        string? errorMessage = null)
    {
        return new LoadingTexts
        {
            LoadingTitle = string.IsNullOrWhiteSpace(loadingTitle)
                ? English.LoadingTitle
                : loadingTitle,

            LoadingMessage = string.IsNullOrWhiteSpace(loadingMessage)
                ? English.LoadingMessage
                : loadingMessage,

            SuccessTitle = string.IsNullOrWhiteSpace(successTitle)
                ? English.SuccessTitle
                : successTitle,

            SuccessMessage = string.IsNullOrWhiteSpace(successMessage)
                ? English.SuccessMessage
                : successMessage,

            ErrorTitle = string.IsNullOrWhiteSpace(errorTitle)
                ? English.ErrorTitle
                : errorTitle,

            ErrorMessage = string.IsNullOrWhiteSpace(errorMessage)
                ? English.ErrorMessage
                : errorMessage
        };
    }
}