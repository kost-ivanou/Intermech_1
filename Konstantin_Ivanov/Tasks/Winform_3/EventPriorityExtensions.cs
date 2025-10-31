namespace Winform_3
{
    public static class EventPriorityExtensions
    {
        public static string ToFriendlyString(this EventPriority priority)
        {
            switch (priority)
            {
                case EventPriority.Low: return "Низкий";
                case EventPriority.Medium: return "Средний";
                case EventPriority.High: return "Высокий";
                default: return "";
            }
        }
    }
}
