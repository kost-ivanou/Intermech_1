using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Winform_7
{
    public class NoteManager
    {
        public BindingList<Note> Notes { get; set; } = new BindingList<Note>();
        private string filePath = "notes.xml";

        public void Load()
        {
            if (!File.Exists(filePath)) return;

            FileInfo fi = new FileInfo(filePath);
            if (fi.Length == 0) return;

            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Note>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                Notes = (BindingList<Note>)serializer.Deserialize(fs);
            }
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Note>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, Notes);
            }
        }

        public void Add(Note note) => Notes.Add(note);
        public void Remove(Note note) => Notes.Remove(note);
    }
}
