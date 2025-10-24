using Microsoft.Win32;

namespace Winform_1
{
    public class TextSaveService : ITextSaveService
    {
        private string SubKeyName = "TextBox";
        private string ValueName = "TextBoxValue";

        public void SetText(string text)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(SubKeyName))
            {
                key.SetValue(ValueName, text, RegistryValueKind.String);
            }
        }

        public string GetText()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(SubKeyName))
            {
                return key.GetValue(ValueName, "").ToString();
            }
        }
    }
}
