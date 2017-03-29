using System;
using System.Collections.Generic;
using DotNet;
using DotNet.Repositories;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
        public List<Actor> GetActors()
        {
            var repo = new ActorsRepository();
            return repo.GetAll();
        }

        public List<Cinema> GetCinemas()
        {
            var repo = new CinemasRepository();
            return repo.GetAll();
        }

        public List<Movie> GetMovies()
        {
            var repo = new MoviesRepository();
            return repo.GetAll();
        }

        public List<Ticket> GetTickets()
        {
            var repo = new TicketsRepository();
            return repo.GetAll();
        }

        public Cinema AddCinema(Cinema cinema)
        {
            var repo = new CinemasRepository();
            return repo.Add(cinema);
        }

        public Movie AddMovie(Movie movie)
        {
            var repo = new MoviesRepository();
            return repo.Add(movie);
        }

        public Actor AddActor(Actor actor)
        {
            var repo = new ActorsRepository();
            return repo.Add(actor);
        }

        public Ticket AddTicket(Ticket ticket)
        {
            var repo = new TicketsRepository();
            return repo.Add(ticket);
        }

        public void DeleteCinema(Cinema cinema)
        {
            var repo = new CinemasRepository();
            repo.Delete(cinema);
        }

        public void DeleteMovie(Movie movie)
        {
            var repo = new MoviesRepository();
            repo.Delete(movie);
        }

        public void DeleteActor(Actor actor)
        {
            var repo = new ActorsRepository();
            repo.Delete(actor);
        }

        public void DeleteTicket(Ticket ticket)
        {
            var repo = new TicketsRepository();
            repo.Delete(ticket);
        }

        public Cinema UpdateCinema(Cinema cinema)
        {
            var repo = new CinemasRepository();
            return repo.Update(cinema);
        }

        public Movie UpdateMovie(Movie movie)
        {
            var repo = new MoviesRepository();
            return repo.Update(movie);
        }

        public Actor UpdateActor(Actor actor)
        {
            var repo = new ActorsRepository();
            return repo.Update(actor);
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            var repo = new TicketsRepository();
            return repo.Update(ticket);
        }
    }
}
