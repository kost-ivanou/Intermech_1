using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_7
{
    public partial class FormNoteEditor: Form
    {
        private Note note;
        private NoteManager noteManager;
        public FormNoteEditor(Note note, NoteManager noteManager)
        {
            InitializeComponent();
            this.note = note;
            this.noteManager = noteManager;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            note.title = txtTitle.Text;
            noteManager.Save();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            note.content = txtContent.Text;
            noteManager.Save();
        }

        private void FormNoteEditor_Load(object sender, EventArgs e)
        {
            txtTitle.Text = note.title;
            txtContent.Text = note.content;
        }
    }
}
