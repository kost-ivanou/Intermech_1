namespace Winform_5
{
    public class SearchResultEventArgs
    {
        public string ParentPath { get; }
        public string Path { get; }
        public bool IsFolder { get; }

        public SearchResultEventArgs(string parentPath, string path, bool isFolder)
        {
            ParentPath = parentPath;
            Path = path;
            IsFolder = isFolder;
        }
    }
}
