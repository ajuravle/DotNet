using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Movie
    {

        public Movie()
        {
            this.Actors = new HashSet<Actor>();
        }

        public Movie(DotNet.Movie m, bool flag)
        {
            MovieId = m.MovieId;
            Title = m.Title;
            Genre = m.Genre;
            AgeRestriction = m.AgeRestriction;
            this.Actors = new HashSet<Actor>();
            if(flag)
                foreach (var v in m.Actors)
                {
                    Actors.Add(new Actor(v,false));
                }
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public short AgeRestriction { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}