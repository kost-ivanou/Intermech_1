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
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NoteManager noteManager = new NoteManager();
        private BindingList<Note> filteredNotes;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var note = new Note
            {
                title = "Новая заметка",
                content = String.Empty,
            };
            noteManager.Add(note);
            ApplyFilter();
            noteManager.Save();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            noteManager.Load();
            filteredNotes = noteManager.Notes;
            ApplyFilter();
        }

        private void lbNotes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = lbNotes.IndexFromPoint(e.Location);

                if (index != ListBox.NoMatches)
                {
                    lbNotes.SelectedIndex = index; 

                    Note note = (Note)lbNotes.Items[index];

                    var result = MessageBox.Show(
                        $"Удалить заметку \"{note.title}\"?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        noteManager.Notes.Remove(note);  
                        ApplyFilter();
                        noteManager.Save();
                    }
                }
            }
        }

        private void lbNotes_DoubleClick(object sender, EventArgs e)
        {
            if (lbNotes.SelectedItem is Note note)
            {
                var editor = new FormNoteEditor(note, noteManager);
                editor.ShowDialog();
            }
        }

        private void ApplyFilter()
        {
            string key = txtSearch.Text.ToLower();

            filteredNotes = new BindingList<Note>(
                noteManager.Notes
                       .Where(n => n.title.ToLower().Contains(key)
                                || n.content.ToLower().Contains(key))
                       .ToList()
            );

            lbNotes.DataSource = filteredNotes;
            lbNotes.DisplayMember = "title";
        }
    }
}
