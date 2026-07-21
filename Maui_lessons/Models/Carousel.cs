using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maui_lessons.Models
{
    public class Carousel : INotifyPropertyChanged
    {
        // реализация интерфейса INotifyPropertyChanged для уведомления об изменении свойств

        public event PropertyChangedEventHandler? PropertyChanged;
        // поле для хранения значения свойства Title
        private string? title;
        public string? ImagePath { get; set; } // путь к картинке или URL
        public string? Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
}
