using System.Windows;
using ToDoApp.viewModels;

namespace ToDoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public TodoViewModel TodoViewModel { get; set; } = new TodoViewModel();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TodoViewModel.Load();
        }
    }
}
