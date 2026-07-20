using Maui_lessons;
using System.Collections.ObjectModel;
using System.ComponentModel;

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


        private void OnStartClicked(object sender, EventArgs e)
        {
            // пример изменения свойства — Binding сразу обновит UI
            Items[0].Title = "Item 1 (Updated)";
        }








    }


    public class Carousel : INotifyPropertyChanged
    {
        // реализация интерфейса INotifyPropertyChanged для уведомления об изменении свойств
        
        public event PropertyChangedEventHandler? PropertyChanged;
        // поле для хранения значения свойства Title
        private string? title;

        // свойство Title с уведомлением об изменении
        //public string? Title { get; set; }

        public string? Title
        {

            get { return title; }



            set
            {

                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title)); // уведомляем Binding

                }


            }

        }


        protected void OnPropertyChanged(string propertyName)
        {
            //Подписчиком обычно является система Binding в MAUI
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }


}






//🔎 Механика
//При создании объектов (new Carousel { Title = "Item 1" }) → сеттер сохраняет значение в поле title.
//Это одноразовая запись при инициализации.

//При листании карусели → используется только геттер (get { return title; }), чтобы прочитать уже сохранённое значение.
//Сеттер тут не трогается.



//✅ Итог
//Источник данных: Items в MainPage.

//Объекты данных: Carousel с Title.

//Исполняемый класс: MainPage.xaml + кнопка.

//Механизм обновления: изменение Title → событие PropertyChanged → Binding обновляет UI.









//📌 Общая схема
//У нас есть три ключевых уровня:

// 1 Исполняемый класс(View)

//MainPage: ContentPage — это страница в MAUI, где есть XAML и кнопка.

//Здесь задаётся BindingContext = this;, то есть сама страница становится источником данных для привязки.


// 2 Класс‑источник данных (ViewModel / DataContext)

//В твоём случае это свойство Items внутри MainPage.

//Оно содержит коллекцию объектов Carousel.

//Именно Items используется как источник данных для CarouselView в XAML.



// 3  Класс‑объект (Model)

//Carousel — отдельный класс, который реализует INotifyPropertyChanged.

//У него есть свойство Title.

//Когда Title меняется, вызывается OnPropertyChanged(nameof(Title)), и система Binding обновляет UI.