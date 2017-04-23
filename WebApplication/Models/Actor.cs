using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
        }

        public Actor(DotNet.Actor a,bool flag)
        {
            ActorId = a.ActorId;
            FirstName = a.FirstName;
            LastName = a.LastName;
            BirthDate = a.BirthDate;
            this.Movies = new HashSet<Movie>();
            if (flag)
                foreach (var v in a.Movies)
                {
                    Movies.Add(new Movie(v,false));
                }
        }

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}