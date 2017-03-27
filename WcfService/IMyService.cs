using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DotNet;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyService" in both code and config file together.
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        List<Cinema> GetCinemas();
        [OperationContract]
        List<Movie> GetMovies();
        [OperationContract]
        List<Actor> GetActors();
        [OperationContract]
        List<Ticket> GetTickets();

        [OperationContract]
        Cinema AddCinema(Cinema cinema);
        [OperationContract]
        Movie AddMovie(Movie movie);
        [OperationContract]
        Actor AddActor(Actor actor);
        [OperationContract]
        Ticket AddTicket(Ticket ticket);

        [OperationContract]
        void DeleteCinema(Cinema cinema);
        [OperationContract]
        void DeleteMovie(Movie movie);
        [OperationContract]
        void DeleteActor(Actor actor);
        [OperationContract]
        void DeleteTicket(Ticket ticket);
    }
}
