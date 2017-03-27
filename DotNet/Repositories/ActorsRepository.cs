using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Repositories
{
    public class ActorsRepository
    {
        private readonly Model1Container context;

        public ActorsRepository()
        {
            this.context = new Model1Container();
        }

        public List<Actor> GetAll()
        {
            return context.Actors.Include("Movies").ToList();
        }

        public Actor Add(Actor actor)
        {
            var aux = actor.Movies;
            actor.Movies = new List<Movie>();
            foreach (var a in aux)
            {
                var act = context.Movies.SingleOrDefault(e => e.MovieId == a.MovieId);
                actor.Movies.Add(act);
            }
            context.Actors.Add(actor);
            context.SaveChanges();
            return actor;
        }

        public void Delete(Actor actor1)
        {
            var actor = context.Actors.SingleOrDefault(t => t.ActorId == actor1.ActorId);
            if (actor != null)
            {
                foreach (var movie in context.Movies)
                {
                    if (movie.Actors.Contains(actor))
                        movie.Actors.Remove(actor);
                }
                context.Database.ExecuteSqlCommand("DELETE FROM ActorMovie where Actors_ActorId=" + actor.ActorId.ToString());
                context.Actors.Remove(actor);
                context.SaveChanges();
            }
        }

        public void Update(Actor actorU)
        {
            var actor = context.Actors.SingleOrDefault(t => t.ActorId == actorU.ActorId);
            if (actor != null)
            {
                actor.FirstName = actorU.FirstName;
                actor.LastName = actorU.LastName;
                actor.BirthDate = actorU.BirthDate;

                actor.Movies.Clear();
                foreach (var a in actorU.Movies)
                {
                    var act = context.Movies.SingleOrDefault(e => e.MovieId == a.MovieId);
                    actor.Movies.Add(act);
                }

                foreach (var movie in context.Movies)
                {
                    if (movie.Actors.Contains(actor))
                        movie.Actors.Remove(actor);
                }

                context.Entry(actor).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
