using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;
using System.Diagnostics;

namespace Winform_5
{
    public class IconManager
    {
        private readonly ImageList _imageList;
        private readonly int _folderIconIndex;
        private readonly int _driveIconIndex;
        private readonly Dictionary<string, int> _iconCache = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        public ImageList ImageList => _imageList;
        public int FolderIconIndex => _folderIconIndex;
        public int DriveIconIndex => _driveIconIndex;

        public IconManager()
        {
            _imageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(16, 16)
            };

            Icon folderIcon = ShellIconStock.FolderIcon;
            _folderIconIndex = _imageList.Images.Count;
            _imageList.Images.Add(folderIcon);

            Icon driveIcon = ShellIconStock.HardDiskIcon;
            _driveIconIndex = _imageList.Images.Count;
            _imageList.Images.Add(driveIcon);
        }

        public int GetIconIndex(string path, bool isFolder)
        {
            try
            {
                if (IsDriveRoot(path)) return _driveIconIndex;

                if (isFolder) return _folderIconIndex;

                string ext = Path.GetExtension(path).ToLowerInvariant();

                if (_iconCache.TryGetValue(ext, out int cachedIndex)) return cachedIndex;

                Icon icon = Icon.ExtractAssociatedIcon(path);
                if (icon == null) return _folderIconIndex;

                _imageList.Images.Add(icon);
                int newIndex = _imageList.Images.Count - 1;
                _iconCache[ext] = newIndex;
                return newIndex;
            }
            catch
            {
                return _folderIconIndex;
            }
        }

        private static bool IsDriveRoot(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;

            string root = Path.GetPathRoot(path);
            return string.Equals(root, path, StringComparison.OrdinalIgnoreCase);
        }
    }
}
