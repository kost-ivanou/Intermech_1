using System;
using System.Configuration;
using System.Windows.Forms;

namespace Winform_4
{
    public partial class Form1: Form
    {
        private readonly DownloadTaskManager _manager = new DownloadTaskManager();
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private async void addFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Выберите файл";
                ofd.Filter = "Все файлы (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var task = _manager.AddDownload(ofd.FileName, _connectionString);
                    var control = new DownloadItemControl(task);
                    

                    pnlDownloads.Controls.Add(control); 

                    await task.StartAsync();
                }
            }
        }

        private void pauseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.PauseAll();
        }

        private void resumeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.ResumeAll();
        }
    }
}
