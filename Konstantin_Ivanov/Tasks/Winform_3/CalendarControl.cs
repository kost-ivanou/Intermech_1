using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Winform_3.Dialogs;

namespace Winform_3
{
    public class CalendarControl : Control
    {
        private int CELL_WIDTH = 100;
        private int CELL_HEIGHT = 90;

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
            using (var font = new Font("Segoe UI", 9))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
            {
                for (int i = 0; i < daysInMonth; i++)
                {
                    int row = i / 7;
                    int col = i % 7;
                    Rectangle cell = new Rectangle(col * CELL_WIDTH, row * CELL_HEIGHT, CELL_WIDTH, CELL_HEIGHT);
                    g.DrawRectangle(Pens.Gray, cell);
                    g.DrawString($"{i + 1} {currentMonth:MMM}", font, Brushes.Black, cell, sf);

                    var dayEvents = events.Where(ev => ev.DayIndex == i).OrderBy(ev => ev.Priority).ToList();
                    int y = cell.Top + 20;
                    foreach (var ev in dayEvents)
                    {
                        Rectangle evRect = new Rectangle(cell.Left + 5, y, CELL_WIDTH - 10, 20);
                        using (var brush = new SolidBrush(ev.Color))
                        {
                            g.FillRectangle(brush, evRect);
                            g.DrawRectangle(Pens.Black, evRect);
                            g.DrawString(ev.Title, font, Brushes.White, evRect);
                        }
                        y += 22;
                    }
                }
            }
        }

        private void CalendarControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
    {
                int index = GetDayIndex(e.Location);
                if (index < 0) return;

                var dayEvents = events.Where(ev => ev.DayIndex == index).ToList();
                if (dayEvents.Count >= 3)
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
                        var color = GetColorByPriority(dialog.Priority);
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
                            ev.Color = GetColorByPriority(ev.Priority);
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
            if (dayEvents.Count >= 3)
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
            int index = row * 7 + col;
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

            int row = index / 7;
            int col = index % 7;
            Rectangle cell = new Rectangle(col * CELL_WIDTH, row * CELL_HEIGHT, CELL_WIDTH, CELL_HEIGHT);

            var dayEvents = events.Where(ev => ev.DayIndex == index).ToList();
            int y = cell.Top + 20;
            foreach (var ev in dayEvents)
            {
                Rectangle evRect = new Rectangle(cell.Left + 5, y, CELL_WIDTH - 10, 20);
                if (evRect.Contains(point))
                {
                    return ev;
                }
                y += 20;
            }
            return null;
        }

        private Color GetColorByPriority(EventPriority priority)
        {
            switch (priority)
            {
                case EventPriority.Low: return Color.Green;
                case EventPriority.Medium: return Color.Goldenrod;
                case EventPriority.High: return Color.Red;
                default: return Color.Gray;
            }
        }
    }
}
