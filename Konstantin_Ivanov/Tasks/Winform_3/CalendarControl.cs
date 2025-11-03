using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Winform_3.Dialogs;

namespace Winform_3
{
    public class CalendarControl : Control
    {
        private const int CELL_WIDTH = 100;
        private const int CELL_HEIGHT = 90;

        private const int DAYS_IN_WEEK = 7;
        private const int MAX_EVENTS_PER_DAY = 3;
        private const int EVENT_RECT_HEIGHT = 20;
        private const int EVENT_RECT_MARGIN = 5;
        private const int EVENT_MARGIN_TOP = 20;
        private const int EVENT_VERTICAL_SPACING = 22;

        private List<CalendarEvent> events = new List<CalendarEvent>();
        private int daysInMonth;
        private DateTime currentMonth;

        public CalendarControl()
        {
            DoubleBuffered = true;
            AllowDrop = true;

            MouseDown += CalendarControl_MouseDown;
            DragEnter += CalendarControl_DragEnter;
            DragOver += CalendarControl_DragOver;
            DragDrop += CalendarControl_DragDrop;

            currentMonth = DateTime.Today;
            daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);

            MouseDoubleClick += CalendarControl_MouseDoubleClick;
        }

        protected void AddEvent(CalendarEvent ev)
        {
            events.Add(ev);
            Invalidate();
        }

        protected void RemoveEvent(CalendarEvent ev)
        {   
            events.Remove(ev);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawCalendar(e.Graphics);
        }

        private void DrawCalendar(Graphics g)
        {
            g.Clear(Color.White);
            var font = FontHelper.Get("Default");

            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
            {
                for (int i = 0; i < daysInMonth; i++)
                {
                    DrawDayCell(g, font, sf, i);
                }
            }
        }

        private void DrawDayCell(Graphics g, Font font, StringFormat sf, int dayIndex)
        {
            int row = dayIndex / DAYS_IN_WEEK;
            int col = dayIndex % DAYS_IN_WEEK;
            Rectangle cell = new Rectangle(col * CELL_WIDTH, row * CELL_HEIGHT, CELL_WIDTH, CELL_HEIGHT);

            DrawCellBackground(g, cell);
            DrawDayHeader(g, font, sf, cell, dayIndex);
            DrawDayEvents(g, font, cell, dayIndex);
        }

        private void DrawCellBackground(Graphics g, Rectangle cell)
        {
            g.DrawRectangle(Pens.Gray, cell);
        }

        private void DrawDayHeader(Graphics g, Font font, StringFormat sf, Rectangle cell, int dayIndex)
        {
            string text = $"{dayIndex + 1} {currentMonth:MMM}";
            g.DrawString(text, font, Brushes.Black, cell, sf);
        }

        private void DrawDayEvents(Graphics g, Font font, Rectangle cell, int dayIndex)
        {
            var dayEvents = events
                .Where(ev => ev.DayIndex == dayIndex)
                .OrderBy(ev => ev.Priority)
                .ToList();

            int y = cell.Top + EVENT_MARGIN_TOP;

            foreach (var ev in dayEvents)
            {
                DrawEvent(g, font, ev, cell, ref y);
                y += EVENT_VERTICAL_SPACING;
            }
        }

        private void DrawEvent(Graphics g, Font font, CalendarEvent ev, Rectangle cell, ref int y)
        {
            Rectangle evRect = new Rectangle(
                cell.Left + EVENT_RECT_MARGIN,
                y,
                CELL_WIDTH - 2 * EVENT_RECT_MARGIN,
                EVENT_RECT_HEIGHT);

            using (var brush = new SolidBrush(ev.Color))
            {
                g.FillRectangle(brush, evRect);
                g.DrawRectangle(Pens.Black, evRect);
                g.DrawString(ev.Title, font, Brushes.White, evRect);
            }
        }

        private void CalendarControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
    {
                int index = GetDayIndex(e.Location);
                if (index < 0) return;

                var dayEvents = events.Where(ev => ev.DayIndex == index).ToList();
                if (dayEvents.Count >= MAX_EVENTS_PER_DAY)
                {
                    MessageBox.Show(
                        "Вы не можете добавить более 3 событий в один день.",
                        "Ограничение событий",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                using (var dialog = new EventCreateDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var color = CalendarHelper.GetColorByPriority(dialog.Priority);
                        AddEvent(new CalendarEvent(dialog.EventTitle, index, color, dialog.Priority));
                    }
                }
            }
        }

        private void CalendarControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var ev = GetEventFromPoint(e.Location);
                if (ev != null)
                {
                    DoDragDrop(ev, DragDropEffects.Move);
                }
            }

            else if (e.Button == MouseButtons.Right)
            {
                var ev = GetEventFromPoint(e.Location);
                if (ev != null)
                {
                    using (var dialog = new EventPriorityEditDialog(ev.Priority))
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            ev.Priority = dialog.selectedPriority;
                            ev.Color = CalendarHelper.GetColorByPriority(ev.Priority);
                            Invalidate();
                        }
                    }
                }
            }

            else if (e.Button == MouseButtons.Middle){
                var ev = GetEventFromPoint(e.Location);
                if (ev != null)
                {
                    var result = MessageBox.Show(
                        $"Удалить событие \"{ev.Title}\"?",
                        "Удаление события",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        events.Remove(ev);
                        Invalidate();
                    }
                }
            }
        }

        private void CalendarControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CalendarEvent)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void CalendarControl_DragOver(object sender, DragEventArgs e)
        {
            Invalidate();
        }

        private void CalendarControl_DragDrop(object sender, DragEventArgs e)
        {
            var ev = (CalendarEvent)e.Data.GetData(typeof(CalendarEvent));
            Point clientPoint = PointToClient(new Point(e.X, e.Y));
            int targetIndex = GetDayIndex(clientPoint);
            var dayEvents = events.Where(even => even.DayIndex == targetIndex).ToList();
            if (dayEvents.Count >= MAX_EVENTS_PER_DAY)
            {
                MessageBox.Show(
                    "Вы не можете добавить более 3 событий в один день.",
                    "Ограничение событий",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (targetIndex >= 0)
            {
                ev.DayIndex = targetIndex;
            }
            Invalidate();
        }

        private int GetDayIndex(Point point)
        {
            int col = point.X / CELL_WIDTH;
            int row = point.Y / CELL_HEIGHT;
            int index = row * DAYS_IN_WEEK + col;
            if (index < 0 || index >= daysInMonth)
            {
                return -1;
            }
            return index;
        }

        private CalendarEvent GetEventFromPoint(Point point)
        {
            int index = GetDayIndex(point);
            if (index < 0)
            {
                return null;
            }

            int row = index / DAYS_IN_WEEK;
            int col = index % DAYS_IN_WEEK;
            Rectangle cell = new Rectangle(col * CELL_WIDTH, row * CELL_HEIGHT, CELL_WIDTH, CELL_HEIGHT);

            var dayEvents = events.Where(ev => ev.DayIndex == index).ToList();
            int y = cell.Top + EVENT_MARGIN_TOP;
            foreach (var ev in dayEvents)
            {
                Rectangle evRect = new Rectangle(cell.Left + EVENT_RECT_MARGIN, y, CELL_WIDTH - 2 * EVENT_RECT_MARGIN, EVENT_RECT_HEIGHT);
                if (evRect.Contains(point))
                {
                    return ev;
                }
                y += EVENT_VERTICAL_SPACING;
            }
            return null;
        }
    }
}
