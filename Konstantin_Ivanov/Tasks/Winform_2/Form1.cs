using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_2
{
    public partial class Form1: Form
    {
        private readonly Regex doubleSymbolRegex = new Regex(@"(.)\1");
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int cursorPos = textBox1.SelectionStart;

            if (doubleSymbolRegex.IsMatch(textBox1.Text))
            {
                textBox1.Text = doubleSymbolRegex.Replace(textBox1.Text, "$1");
                textBox1.SelectionStart = cursorPos - 1;
            }
        }
    }
}
