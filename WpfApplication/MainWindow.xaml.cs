using System.Windows;
using System.Windows.Input;
using WpfApplication.ServiceReference;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ContentControl.Content = new CinemasControl();
        }

        private void Cinemas_OnClick_Click(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new CinemasControl();
        }

        private void Movies_OnClick_OnClick_Click(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new MoviesControl();
        }

        private void Actors_OnClick_OnClick_Click(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new ActorsControl();
        }

        private void Tickets_OnClick_OnClick_Click(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new TicketsControl();
        }
    }
}
