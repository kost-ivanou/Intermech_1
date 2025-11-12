using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Winform_5
{
    public static class ShellIconStock
    {
        private const string ShellIconsLib = @"C:\WINDOWS\System32\shell32.dll";

        private const int folder = 4;
        private const int hardDisk = 8;

        [DllImport("shell32.dll", EntryPoint = "ExtractIcon")]
        extern static IntPtr ExtractIcon(
            IntPtr hInst,
            string lpszExeFileName,
            int nIconIndex);

        static public Icon GetIcon(int index)
        {
            IntPtr Hicon = ExtractIcon(
               IntPtr.Zero, ShellIconsLib, index);
            Icon icon = Icon.FromHandle(Hicon);
            return icon;
        }

        static public Icon FolderIcon
        {
            get { return GetIcon(folder); }
        }

        static public Icon HardDiskIcon
        {
            get { return GetIcon(hardDisk); }
        }
    }
}
