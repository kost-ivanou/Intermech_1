using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_3
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();

            var calendar = new CalendarControl
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(calendar);
        }
    }
}
