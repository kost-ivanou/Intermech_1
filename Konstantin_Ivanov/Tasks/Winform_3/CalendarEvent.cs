using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_3
{
    public class CalendarEvent
    {
        public string Title { get; set; }
        public int DayIndex { get; set; }
        public Color Color { get; set; }
        public EventPriority Priority { get; set; }

        public CalendarEvent(string title, int dayIndex, Color color, EventPriority priority)
        {
            Title = title;
            DayIndex = dayIndex;
            Color = color;
            Priority = priority;
        }
    }
}
