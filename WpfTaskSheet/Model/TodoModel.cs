using System;
using System.ComponentModel;
namespace WpfTaskSheet.Model
{
    internal class TodoModel : INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _is_Done;

        public bool IsDone
        {
            get { return _is_Done; }
            set {if (_is_Done == value)
                    return;
                _is_Done = value;
                OnPropertyChanged("IsDone");
            }
        }

        private string _text;


        public string Text
        {
            get { return _text; }
            set {     if (_text == value)
                    return;
                    _text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));            
        }
    }
}
