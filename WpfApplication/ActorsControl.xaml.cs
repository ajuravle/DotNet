using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DotNet;
using WpfApplication.ServiceReference;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for ActorsControl.xaml
    /// </summary>
    public partial class ActorsControl : UserControl
    {
        private MyServiceClient cl;
        public ActorsControl()
        {
            InitializeComponent();
            cl = new MyServiceClient();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                System.Windows.Data.CollectionViewSource actorViewSource =
                    (System.Windows.Data.CollectionViewSource)this.Resources["actorViewSource"];
                actorViewSource.Source = cl.GetActors();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Actor actor = new Actor();
                actor.FirstName = FirstName.Text;
                actor.LastName = LastName.Text;
                actor.BirthDate = DateTime.Parse(BirthDate.Text);
                cl.AddActor(actor);
                System.Windows.Data.CollectionViewSource actorViewSource =
                    (System.Windows.Data.CollectionViewSource)this.Resources["actorViewSource"];
                actorViewSource.Source = cl.GetActors();
                Message.Content = "Actor created";
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
                Actor actor = cl.GetActors().SingleOrDefault(t => t.ActorId == Int16.Parse(ActorId.Text));
                if (actor == null)
                    Message.Content = "Actor with this ID doesn't exist";
                else
                {
                    actor.FirstName = FirstName.Text;
                    actor.LastName = LastName.Text;
                    actor.BirthDate = DateTime.Parse(BirthDate.Text);
                    cl.UpdateActor(actor);
                    System.Windows.Data.CollectionViewSource actorViewSource =
                    (System.Windows.Data.CollectionViewSource)this.Resources["actorViewSource"];
                    actorViewSource.Source = cl.GetActors();
                    Message.Content = "Actor updated";
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
                if (cl.GetActors().SingleOrDefault(t => t.ActorId == Int16.Parse(ActorId.Text)) == null)
                    Message.Content = "Movie with this ID doesn't exist";
                else
                {
                    Actor actor = new Actor() { ActorId = Int16.Parse(ActorId.Text) };
                    cl.DeleteActor(actor);
                    System.Windows.Data.CollectionViewSource actorViewSource =
                     (System.Windows.Data.CollectionViewSource)this.Resources["actorViewSource"];
                    actorViewSource.Source = cl.GetActors();
                    Message.Content = "Actor deleted";
                }
            }
            catch (Exception)
            {

                Message.Content = "Invalid ID";
            }
        }

        private void AddMovie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var movie = cl.GetMovies().SingleOrDefault(t => t.MovieId == Int16.Parse(MovieId.Text));
                var actor = cl.GetActors().SingleOrDefault(t => t.ActorId == Int16.Parse(ActorId.Text));
                if (movie == null)
                    Message.Content = "Movie with this ID doesn't exist";
                else if (actor == null)
                    Message.Content = "Actor with this ID doesn't exist";
                else
                {
                    cl.AddMovieToActor(actor, movie);
                    System.Windows.Data.CollectionViewSource actorViewSource =
                     (System.Windows.Data.CollectionViewSource)this.Resources["actorViewSource"];
                    actorViewSource.Source = cl.GetActors();
                    Message.Content = "Actor updated";
                }
            }
            catch (Exception)
            {

                Message.Content = "Invalid ID";
            }
        }

        private void RemoveMovie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var actor = cl.GetActors().SingleOrDefault(t => t.ActorId == Int16.Parse(ActorId.Text));
                if (actor == null)
                    Message.Content = "Actor with this ID doesn't exist";
                else
                {
                    var movie = actor.Movies.SingleOrDefault(t => t.MovieId == Int16.Parse(MovieId.Text));
                    if (movie == null)
                        Message.Content = "Movie with this ID doesn't exist";
                    else
                    {
                        cl.RemoveMovieFromActor(actor, movie);
                       System.Windows.Data.CollectionViewSource actorViewSource =
                        (System.Windows.Data.CollectionViewSource)this.Resources["actorViewSource"];
                        actorViewSource.Source = cl.GetActors();
                        Message.Content = "Actor updated";
                    }
                }
            }
            catch (Exception)
            {
                Message.Content = "Invalid ID";
            }
        }
    }
}
