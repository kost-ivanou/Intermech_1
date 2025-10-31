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
    public partial class EventPriorityEditDialog: Form
    {
        public EventPriority selectedPriority => (EventPriority)cmbNewEventPriority.SelectedIndex;

        public EventPriorityEditDialog(EventPriority prevEventPriority)
        {
            InitializeComponent();
            cmbNewEventPriority.Text = prevEventPriority.ToFriendlyString();
        }
    }
}
