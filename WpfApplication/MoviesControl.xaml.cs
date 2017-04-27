using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DotNet;
using WpfApplication.ServiceReference;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MoviesControl.xaml
    /// </summary>
    public partial class MoviesControl : UserControl
    {
        private MyServiceClient cl;
        public MoviesControl()
        {
            InitializeComponent();
            cl = new MyServiceClient();
        }


        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                System.Windows.Data.CollectionViewSource movieViewSource =
                    (System.Windows.Data.CollectionViewSource)this.Resources["movieViewSource"];
                movieViewSource.Source = cl.GetMovies();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Movie movie = new Movie();
                movie.Title = Title.Text;
                movie.Duration = Int16.Parse(Duration.Text);
                movie.Genre = Genre.Text;
                movie.AgeRestriction = Int16.Parse(AgeRestr.Text);
                cl.AddMovie(movie);
                System.Windows.Data.CollectionViewSource movieViewSource =
                    (System.Windows.Data.CollectionViewSource)this.Resources["movieViewSource"];
                movieViewSource.Source = cl.GetMovies();
                Message.Content = "Movie created";
            }
            catch (Exception)
            {

                Message.Content = "Invalid inputs";
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Movie movie = cl.GetMovies().SingleOrDefault(t => t.MovieId == Int16.Parse(MovieId.Text));
                if (movie == null)
                    Message.Content = "Movie with this ID doesn't exist";
                else
                {
                    movie.Title = Title.Text;
                    movie.Duration = Int16.Parse(Duration.Text);
                    movie.Genre = Genre.Text;
                    movie.AgeRestriction = Int16.Parse(AgeRestr.Text);
                    cl.UpdateMovie(movie);
                    System.Windows.Data.CollectionViewSource movieViewSource =
                    (System.Windows.Data.CollectionViewSource)this.Resources["movieViewSource"];
                    movieViewSource.Source = cl.GetMovies();
                    Message.Content = "Movie updated";
                }
            }
            catch (Exception)
            {

                Message.Content = "Invalid inputs";
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cl.GetMovies().SingleOrDefault(t => t.MovieId == Int16.Parse(MovieId.Text)) == null)
                    Message.Content = "Movie with this ID doesn't exist";
                else
                {
                    Movie movie = new Movie() { MovieId = Int16.Parse(MovieId.Text) };
                    cl.DeleteMovie(movie);
                    System.Windows.Data.CollectionViewSource movieViewSource =
                   (System.Windows.Data.CollectionViewSource)this.Resources["movieViewSource"];
                    movieViewSource.Source = cl.GetMovies();
                    Message.Content = "Movie deleted";
                }
            }
            catch (Exception)
            {

                Message.Content = "Invalid ID";
            }
        }
    }
}
