using Newtonsoft.Json;
using System;
using System.ComponentModel;
namespace WpfTaskSheet.Model
{
    internal class TodoModel : INotifyPropertyChanged
    {
        private bool _is_Done;
        private string _text;

       /// <summary>
       /// Поля для сохранения в json
       /// </summary>
        [JsonProperty(PropertyName ="creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;


        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone
        {
            get { return _is_Done; }
            set {if (_is_Done == value)
                    return;
                _is_Done = value;
                OnPropertyChanged("IsDone");
            }
        }                                                       

        [JsonProperty(PropertyName ="text")]
        public string Text
        {
            get { return _text; }
            set {     if (_text == value)
                    return;
                    _text = value;
                OnPropertyChanged("Text");
            }
        }
        /// <summary>
        /// Событие изменения ресурса
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));            
        }
    }
}
