using System;

namespace Winform_4
{
    public static class DownloadTaskStatusExtensions
    {
        public static string ToFriendlyString(this DownloadTaskStatus status)
        {
            switch (status)
            {
                case DownloadTaskStatus.Success: return "Завершено";
                case DownloadTaskStatus.Loading: return "Загрузка...";
                case DownloadTaskStatus.Paused: return "Пауза";
                case DownloadTaskStatus.Canceled: return "Отменено";
                case DownloadTaskStatus.Error: return "Ошибка загрузки";
                default: return "Неизвестный статус";
            }
        }

        public static string ToFriendlyString(this DownloadTaskStatus status, int retryCount, int maxRetries)
        {
            if (status == DownloadTaskStatus.Retrying) return $"Повтор {retryCount}/{maxRetries}";
            else return "Неизвестный статус";
        }

        public static string ToFriendlyString(this DownloadTaskStatus status, string errorMsg)
        {
            if (status == DownloadTaskStatus.Error) return "Ошибка: " + errorMsg;
            else return "Неизвестный статус";
        }
    }
}
