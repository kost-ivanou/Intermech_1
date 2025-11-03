using System.Drawing;

namespace Winform_3
{
    public static class CalendarHelper
    {
        public static Color GetColorByPriority(EventPriority priority)
        {
            switch (priority)
            {
                case EventPriority.Low:
                    return Color.Green;
                case EventPriority.Medium:
                    return Color.Goldenrod;
                case EventPriority.High:
                    return Color.Red;
                default:
                    return Color.Gray;
            }
        }
    }
}
