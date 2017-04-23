
namespace WebApplication.Models
{
    public class Cinema
    {
        public Cinema()
        {
        }

        public Cinema(DotNet.Cinema c)
        {
            CinemaId = c.CinemaId;
            NrRooms = c.NrRooms;
            City = c.City;
            Address = c.Address;
            Name = c.Name;
        }
        public int CinemaId { get; set; }
        public short NrRooms { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
