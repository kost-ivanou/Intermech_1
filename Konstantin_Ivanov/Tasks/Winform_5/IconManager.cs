using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;

namespace Winform_5
{
    public class IconManager
    {
        private readonly ImageList _imageList;
        private readonly int _folderIconIndex;
        private readonly Dictionary<string, int> _iconCache = new Dictionary<string, int>();

        public ImageList ImageList => _imageList;
        public int FolderIconIndex => _folderIconIndex;

        public IconManager()
        {
            _imageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(16, 16)
            };

            Icon folderIcon = ShellStockIcons.GetFolderIcon();
            
            _folderIconIndex = _imageList.Images.Count;
            _imageList.Images.Add(folderIcon);
        }

        public int GetIconIndex(string path, bool isFolder)
        {
            if (isFolder) return _folderIconIndex;

            string ext = Path.GetExtension(path).ToLower();
            if (_iconCache.TryGetValue(ext, out int idx)) return idx;
            try
            {
                Icon icon = Icon.ExtractAssociatedIcon(path);
                _imageList.Images.Add(icon);
                idx = _imageList.Images.Count - 1;
                _iconCache[ext] = idx;
                return idx;
            }
            catch
            {
                return _folderIconIndex;
            }
        }
    }
}
