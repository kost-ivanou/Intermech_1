using System.Collections.Generic;
using System.Drawing;

namespace Winform_3
{
    public static class FontHelper
    {
        private static readonly Dictionary<string, Font> fonts = new Dictionary<string, Font>();

        static FontHelper()
        {
            fonts["Default"] = new Font("Segoe UI", 9);
        }

        public static Font Get(string key)
        {
            if (fonts.TryGetValue(key, out var font)) return font;
            throw new KeyNotFoundException($"Шрифт '{key}' не найден.");
        }

        public static void DisposeAll()
        {
            foreach (var f in fonts.Values)
                f.Dispose();
            fonts.Clear();
        }
    }
}
