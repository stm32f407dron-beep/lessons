using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Maui_lessons
{
    public partial class MainPage : ContentPage
    {
        // свойство ObservableCollection позволяет автоматически обновлять интерфейс при изменении коллекции
        //  и Items становится источником данных для CarouselView(xaml).
        public List<Carousel> Items { get; set; } 
        

        public MainPage()
        {
            InitializeComponent();

            // установка контекста данных для привязки
            Items = new List<Carousel> 
            { 
                new Carousel { Title = "Item 1" },
                new Carousel { Title = "Item 2" },
                new Carousel { Title = "Item 3" },

            };

            // установка контекста данных для привязки
            // контекстом является сама страница MainPage.
            // Это значит: все {Binding ...} в XAML будут искать свойство(Items)  объекта MainPage. 
            BindingContext = this;
        }

       
    }


    public class Carousel : INotifyPropertyChanged
    {
        // реализация интерфейса INotifyPropertyChanged для уведомления об изменении свойств
        
        public event PropertyChangedEventHandler? PropertyChanged;
        // поле для хранения значения свойства Title
        private string? title;

        // свойство Title с уведомлением об изменении
        public string? Title { get; set; }

        //public string? Title 
        //{
           
        //    get { return title;}



        //    set
        //    {

        //        if (title != value)
        //        {
        //            title = value;
        //            OnPropertyChanged(nameof(Title)); // уведомляем Binding

        //        }


        //    }

        //}


        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}


    }


}


//🔎 Механика
//При создании объектов (new Carousel { Title = "Item 1" }) → сеттер сохраняет значение в поле title.
//Это одноразовая запись при инициализации.

//При листании карусели → используется только геттер (get { return title; }), чтобы прочитать уже сохранённое значение.
//Сеттер тут не трогается.