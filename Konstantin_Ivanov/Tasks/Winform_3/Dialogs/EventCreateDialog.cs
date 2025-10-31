using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_3.Dialogs
{
    public partial class EventCreateDialog: Form
    {
        public string EventTitle => txtEventTitle.Text;
        public EventPriority Priority => (EventPriority)cmbEventPriority.SelectedIndex;
        public EventCreateDialog()
        {
            InitializeComponent();
        }
    }
}
