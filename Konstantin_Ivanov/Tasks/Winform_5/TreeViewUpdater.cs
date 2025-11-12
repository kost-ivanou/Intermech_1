using System.IO;
using System.Windows.Forms;
using System;

namespace Winform_5
{
    public class TreeViewUpdater
    {
        private readonly TreeView _treeView;
        private readonly IconManager _iconManager;
        private readonly string _rootPath;

        public TreeViewUpdater(TreeView treeView, IconManager iconManager, string rootPath)
        {
            _treeView = treeView;
            _iconManager = iconManager;
            _rootPath = Path.GetFullPath(rootPath);
        }

        public void AddNode(string parentPath, string path, bool isFolder)
        {
            if (_treeView.InvokeRequired)
            {
                _treeView.Invoke(new Action(() => AddNode(parentPath, path, isFolder)));
                return;
            }

            AddNodeHierarchical(path, isFolder);
        }

        private void AddNodeHierarchical(string fullPath, bool isFolder)
        {
            string rootName = Path.GetFileName(_rootPath);
            if (string.IsNullOrEmpty(rootName)) rootName = _rootPath; 

            bool isDriveRoot = string.Equals(
                Path.GetPathRoot(_rootPath),
                _rootPath,
                StringComparison.OrdinalIgnoreCase);

            int iconRootIndex = isDriveRoot ? _iconManager.DriveIconIndex : _iconManager.FolderIconIndex;

            TreeNode rootNode;
            if (_treeView.Nodes.Count == 0)
            {
                rootNode = new TreeNode(rootName)
                {
                    Name = _rootPath,
                    ImageIndex = iconRootIndex,
                    SelectedImageIndex = iconRootIndex
                };
                _treeView.Nodes.Add(rootNode);
            }
            else
            {
                rootNode = _treeView.Nodes[0];
            }

            if (string.Equals(_rootPath, fullPath, StringComparison.OrdinalIgnoreCase)) return; 

            string relativePath = GetRelativePath(_rootPath, fullPath);
            if (string.IsNullOrEmpty(relativePath)) return;

            string[] parts = relativePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            TreeNode current = rootNode;
            string currentPath = _rootPath;

            foreach (string part in parts)
            {
                if (string.IsNullOrWhiteSpace(part)) continue;

                currentPath = Path.Combine(currentPath, part);
                TreeNode[] found = current.Nodes.Find(currentPath, false);

                TreeNode node;
                if (found.Length == 0)
                {
                    int iconIndex = _iconManager.GetIconIndex(Path.GetFullPath(currentPath), Directory.Exists(currentPath));
                    node = new TreeNode(part, iconIndex, iconIndex)
                    {
                        Name = currentPath
                    };
                    current.Nodes.Add(node);
                }
                else
                {
                    node = found[0];
                }

                current = node;
            }
        }

        private static string GetRelativePath(string basePath, string fullPath)
        {
            Uri baseUri = new Uri(AppendDirectorySeparator(basePath));
            Uri fullUri = new Uri(fullPath);
            Uri relativeUri = baseUri.MakeRelativeUri(fullUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.ToString())
                .Replace('/', Path.DirectorySeparatorChar);
            return relativePath;

        }

        private static string AppendDirectorySeparator(string path)
        {
            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                return path + Path.DirectorySeparatorChar;
            return path;
        }
    }
}
