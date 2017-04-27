using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Repositories
{
    public class MoviesRepository
    {
        private readonly Model1Container context;

        public MoviesRepository()
        {
            this.context = new Model1Container();
        }

        public List<Movie> GetAll()
        {
            return context.Movies.Include("Actors").ToList();
        }

        public Movie Add(Movie movie)
        {
            var aux = movie.Actors;
            movie.Actors = new List<Actor>();
            foreach (var a in aux)
            {
                var act = context.Actors.SingleOrDefault(e => e.ActorId == a.ActorId);
                movie.Actors.Add(act);
            }

            context.Movies.Add(movie);
            context.SaveChanges();
            return movie;
        }

        public void Delete(Movie movie1)
        {
            var movie = context.Movies.SingleOrDefault(t => t.MovieId == movie1.MovieId);
            if (movie != null)
            {
                foreach (var actor in context.Actors)
                {
                    if (actor.Movies.Contains(movie))
                        actor.Movies.Remove(movie);
                }
                context.Database.ExecuteSqlCommand("DELETE FROM ActorMovie where Movies_MovieId="+movie.MovieId.ToString());
                context.Movies.Remove(movie);
                context.SaveChanges();
            }
        }

        public Movie Update(Movie movieU)
        {
            var movie = context.Movies.SingleOrDefault(t => t.MovieId == movieU.MovieId);
            if (movie != null)
            {
                movie.Title = movieU.Title;
                movie.Genre = movieU.Genre;
                movie.Duration = movieU.Duration;
                movie.AgeRestriction = movieU.AgeRestriction;
                movie.Actors = new List<Actor>();
                context.Database.ExecuteSqlCommand("DELETE FROM ActorMovie where Movies_MovieId=" + movie.MovieId.ToString());
                foreach (var a in movieU.Actors)
                {
                    var act = context.Actors.SingleOrDefault(e => e.ActorId == a.ActorId);
                    movie.Actors.Add(act);
                }

                foreach (var actor in context.Actors)
                {
                    if (actor.Movies.Contains(movie))
                        actor.Movies.Remove(movie);
                }

                context.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return movie;
        }

        public Movie AddActor(Movie m, Actor a)
        {
            var movie = context.Movies.SingleOrDefault(t => t.MovieId == m.MovieId);
            var actor = context.Actors.SingleOrDefault(t => t.ActorId == a.ActorId);
            if (movie!=null && actor != null)
            {
                movie.Actors.Add(actor);
                context.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return movie;
        }

        public Movie RemoveActor(Movie m, Actor a)
        {
            var movie = context.Movies.SingleOrDefault(t => t.MovieId == m.MovieId);
            var actor = movie.Actors.SingleOrDefault(t => t.ActorId == a.ActorId);
            if (movie != null && actor != null)
            {
                movie.Actors.Remove(actor);
                context.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return movie;
        }
    }
}
