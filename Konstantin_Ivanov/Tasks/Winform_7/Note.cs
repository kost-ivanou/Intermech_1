using System;
using System.ComponentModel;

namespace Winform_7
{
    public class Note : INotifyPropertyChanged
    {
        private string Title;
        private string Content;

        public string title
        {
            get => Title;
            set
            {
                if (Title != value)
                {
                    Title = value;
                    OnPropertyChanged("title");
                }
            }
        }

        public string content
        {
            get => Content;
            set
            {
                if (Content != value)
                {
                    Content = value;
                    OnPropertyChanged("content");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
