using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_1
{
    public partial class Form1: Form
    {
        private readonly ITextSaveService _textSaveService;

        public Form1(ITextSaveService textSaveService)
        {
            InitializeComponent();
            _textSaveService = textSaveService;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text.Length.ToString();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _textSaveService.SetText(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = _textSaveService.GetText();
        }
    }
}
