using System.Collections.Generic;
using DotNet;

namespace WebApplication.Models
{
    public class Ticket
    {
        private DotNet.Cinema v;

        public Ticket()
        {
            Cinema = new Cinema();
            Movie = new Movie();
        }

        public Ticket(DotNet.Ticket t)
        {
            TicketId = t.TicketId;
            Cinema = new Cinema(t.Cinema);
            Movie = new Movie(t.Movie,false);
            DateTime = t.DateTime;
            Price = t.Price;

        }

        public int TicketId { get; set; }
        public System.DateTime DateTime { get; set; }
        public short Price { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}