using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Repositories
{
    public class TicketsRepository
    {
        private readonly Model1Container context;

        public TicketsRepository()
        {
            this.context = new Model1Container();
        }

        public List<Ticket> GetAll()
        {
            return context.Tickets.Include("Cinema").Include("Movie").ToList();
        }

        public Ticket Add(Ticket ticket)
        {
            var cinema = context.Cinemas.SingleOrDefault(e => e.CinemaId == ticket.Cinema.CinemaId);
            var movie = context.Movies.SingleOrDefault(e => e.MovieId == ticket.Movie.MovieId);
            ticket.Cinema = cinema;
            ticket.Movie = movie;
            context.Tickets.Add(ticket);
            context.SaveChanges();
            return ticket;
        }

        public void Delete(Ticket ticket1)
        {
            var ticket = context.Tickets.SingleOrDefault(t => t.TicketId == ticket1.TicketId);
            if (ticket != null)
            {
                context.Tickets.Remove(ticket);
                context.SaveChanges();
            }
        }

        public void Update(Ticket ticketU)
        {
            var ticket = context.Tickets.SingleOrDefault(t => t.TicketId == ticketU.TicketId);
            if (ticket != null)
            {
                ticket.Cinema = context.Cinemas.SingleOrDefault(e => e.CinemaId == ticketU.Cinema.CinemaId);
                ticket.Movie = context.Movies.SingleOrDefault(e => e.MovieId == ticketU.Movie.MovieId);
                ticket.Price = ticketU.Price;
                ticket.DateTime = ticketU.DateTime;

                context.Entry(ticket).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
