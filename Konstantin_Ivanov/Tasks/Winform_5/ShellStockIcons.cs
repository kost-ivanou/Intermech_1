using System.Drawing;
using System.Runtime.InteropServices;
using System;

namespace Winform_5
{
    public static class ShellStockIcons
    {
        private enum SHSTOCKICONID : uint
        {
            SIID_FOLDER = 3,          
            SIID_FOLDEROPEN = 4       
        }

        [Flags]
        private enum SHGSI : uint
        {
            SHGSI_ICON = 0x000000100,
            SHGSI_SMALLICON = 0x000000001,
            SHGSI_LARGEICON = 0x000000000,
            SHGSI_SHELLICONSIZE = 0x000000004
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct SHSTOCKICONINFO
        {
            public uint cbSize;
            public IntPtr hIcon;
            public int iSysIconIndex;
            public int iIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szPath;
        }

        [DllImport("Shell32.dll", SetLastError = false)]
        private static extern int SHGetStockIconInfo(
            SHSTOCKICONID siid,
            SHGSI uFlags,
            ref SHSTOCKICONINFO psii);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        public static Icon GetFolderIcon(bool open = false, bool small = true)
        {
            SHSTOCKICONID iconId = open ? SHSTOCKICONID.SIID_FOLDEROPEN : SHSTOCKICONID.SIID_FOLDER;
            SHGSI flags = SHGSI.SHGSI_ICON | SHGSI.SHGSI_SHELLICONSIZE;

            if (small)
                flags |= SHGSI.SHGSI_SMALLICON;

            SHSTOCKICONINFO info = new SHSTOCKICONINFO();
            info.cbSize = (uint)Marshal.SizeOf(typeof(SHSTOCKICONINFO));

            int hr = SHGetStockIconInfo(iconId, flags, ref info);
            if (hr != 0)
                throw new System.ComponentModel.Win32Exception(hr);

            Icon icon = (Icon)Icon.FromHandle(info.hIcon).Clone();
            DestroyIcon(info.hIcon);

            return icon;
        }
    }
}
