using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_5
{
    public partial class Form1: Form
    {
        private FileSearcher _searcher;
        private TreeViewUpdater _treeUpdater;
        private IconManager _iconManager;

        public Form1()
        {
            InitializeComponent();

            _iconManager = new IconManager();
            treeView.ImageList = _iconManager.ImageList;

            _searcher = new FileSearcher();
            _searcher.ItemFound += Searcher_ItemFound;
            _searcher.SearchCompleted += Searcher_SearchCompleted;
        }

        private void btnChooseDirectory_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK) lblDirectory.Text = dialog.SelectedPath;
            }
        }

        private async void btnSearchStart_Click(object sender, EventArgs e)
        {
            string path = lblDirectory.Text;
            string mask = txtMask.Text;
            int threads = (int)nmbThreads.Value;

            _treeUpdater = new TreeViewUpdater(treeView, _iconManager, lblDirectory.Text);

            btnSearchStart.Enabled = false;
            treeView.Nodes.Clear();

            try
            {
                await Task.Run(() => _searcher.StartSearch(path, mask, threads));
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Поиск остановлен.");
            }
        }
        private void Searcher_ItemFound(object sender, SearchResultEventArgs e)
        {
            _treeUpdater.AddNode(e.ParentPath, e.Path, e.IsFolder);
        }

        private void Searcher_SearchCompleted(object sender, EventArgs e)
        {
            this.Invoke((Action)(() =>
            {
                MessageBox.Show("Поиск завершён.");
                btnSearchStart.Enabled = true;
            }));
        }
    }
}
