using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace ToDoApp.models
{
    public class TodoModel : INotifyPropertyChanged
    {
        private bool isDone;
        private string text;

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone
        {
            get => isDone;
            set
            {
                if (isDone == value)
                {
                    return;
                }

                isDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }

        [JsonProperty(PropertyName = "text")]
        public string Text
        {
            get => text;
            set
            {
                if (text == value)
                {
                    return;
                }

                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
