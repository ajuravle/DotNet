using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Repositories
{
    public class CinemasRepository
    {
        private readonly Model1Container context;

        public CinemasRepository()
        {
            this.context = new Model1Container();
        }

        public List<Cinema> GetAll()
        {
            return context.Cinemas.ToList();
        }

        public Cinema Add(Cinema cinema)
        {
            context.Cinemas.Add(cinema);
            context.SaveChanges();
            return cinema;
        }

        public void Delete(Cinema cinema)
        {
            var aux = context.Cinemas.SingleOrDefault(t => t.CinemaId == cinema.CinemaId);
            if (aux != null)
            {
                context.Cinemas.Remove(aux);
                context.SaveChanges();
            }
        }

        public void Update(Cinema cinemaU)
        {
            var cinema = context.Cinemas.SingleOrDefault(t => t.CinemaId == cinemaU.CinemaId);
            if (cinema != null)
            {
                cinema.Name = cinemaU.Name;
                cinema.NrRooms = cinemaU.NrRooms;
                cinema.City = cinemaU.City;
                cinema.Address = cinemaU.Address;
                context.Entry(cinema).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
