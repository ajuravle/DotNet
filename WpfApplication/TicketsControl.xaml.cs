using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DotNet;
using WpfApplication.ServiceReference;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for TicketsControl.xaml
    /// </summary>
    public partial class TicketsControl : UserControl
    {
        private MyServiceClient cl;
        public TicketsControl()
        {
            InitializeComponent();
            cl = new MyServiceClient();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                System.Windows.Data.CollectionViewSource ticketViewSource =
                    (System.Windows.Data.CollectionViewSource)this.Resources["ticketViewSource"];
                ticketViewSource.Source = cl.GetTickets();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cl.GetCinemas().SingleOrDefault(t => t.CinemaId == Int16.Parse(Cinema.Text)) == null)
                    Message.Content = "Cinema with this ID doesn't exist";
                else if(cl.GetMovies().SingleOrDefault(t => t.MovieId == Int16.Parse(Movie.Text)) == null)
                    Message.Content = "Movie with this ID doesn't exist";
                else{
                    Ticket ticket = new Ticket();
                    ticket.Cinema = new Cinema() {CinemaId = Int16.Parse(Cinema.Text)};
                    ticket.Movie = new Movie() {MovieId = Int16.Parse(Movie.Text)};
                    ticket.Price = Int16.Parse(Price.Text);
                    ticket.DateTime = DateTime.Parse(Time.Text);
                    cl.AddTicket(ticket);
                    System.Windows.Data.CollectionViewSource ticketViewSource =
                        (System.Windows.Data.CollectionViewSource) this.Resources["ticketViewSource"];
                    ticketViewSource.Source = cl.GetTickets();
                    Message.Content = "Ticket created";
                }
            }
            catch (Exception)
            {

                Message.Content = "Invalid inputs";
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try { 
                if (cl.GetTickets().SingleOrDefault(t => t.TicketId == Int16.Parse(TicketId.Text)) == null)
                    Message.Content = "Ticket with this ID doesn't exist";
                else
                {
                    Ticket ticket = new Ticket() { TicketId = Int16.Parse(TicketId.Text) };
                    cl.DeleteTicket(ticket);
                    System.Windows.Data.CollectionViewSource ticketViewSource =
                            (System.Windows.Data.CollectionViewSource)this.Resources["ticketViewSource"];
                    ticketViewSource.Source = cl.GetTickets();
                    Message.Content = "Ticket deleted";
                }
            }
            catch (Exception)
            {

                Message.Content = "Invalid ID";
            }
}
    }
}
