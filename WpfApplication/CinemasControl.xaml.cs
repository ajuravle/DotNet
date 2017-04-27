using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DotNet;
using WpfApplication.ServiceReference;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for CinemasControl.xaml
    /// </summary>
    public partial class CinemasControl : UserControl
    {
        private MyServiceClient cl;

        public CinemasControl()
        {
            InitializeComponent();
            cl = new MyServiceClient();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                System.Windows.Data.CollectionViewSource cinemaViewSource =
                    (System.Windows.Data.CollectionViewSource) this.Resources["cinemaViewSource"];
                cinemaViewSource.Source = cl.GetCinemas();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cinema cinema = new Cinema();
                cinema.Name = Name.Text;
                cinema.Address = Address.Text;
                cinema.City = City.Text;
                cinema.NrRooms = Int16.Parse(NrRooms.Text);
                cl.AddCinema(cinema);
                cinemaDataGrid.ItemsSource = cl.GetCinemas();
                Message.Content = "Cinema created";
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
                Cinema cinema = cl.GetCinemas().SingleOrDefault(t => t.CinemaId == Int16.Parse(CinemaID.Text));
                if (cinema == null)
                    Message.Content = "Cinema with this ID doesn't exist";
                else
                {
                    cinema.Name = Name.Text;
                    cinema.Address = Address.Text;
                    cinema.City = City.Text;
                    cinema.NrRooms = Int16.Parse(NrRooms.Text);
                    cl.UpdateCinema(cinema);
                    cinemaDataGrid.ItemsSource = cl.GetCinemas();
                    Message.Content = "Cinema updated";
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
                if (cl.GetCinemas().SingleOrDefault(t => t.CinemaId == Int16.Parse(CinemaID.Text)) == null)
                    Message.Content = "Cinema with this ID doesn't exist";
                else { 
                    Cinema cinema = new Cinema() { CinemaId = Int16.Parse(CinemaID.Text) };
                    cl.DeleteCinema(cinema);
                    cinemaDataGrid.ItemsSource = cl.GetCinemas();
                    Message.Content = "Cinema deleted";
                }
            }
            catch (Exception)
            {

                Message.Content = "Invalid ID";
            }      
        }
    }
}
