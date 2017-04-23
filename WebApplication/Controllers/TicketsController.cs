using System.Collections.Generic;
using System.Linq;
using WebApplication.ServiceReference;
using System.Web.Mvc;
using DotNet;
using Ticket = WebApplication.Models.Ticket;

namespace WebApplication.Controllers
{
    public class TicketsController : Controller
    {
        private MyServiceClient cl;
        public TicketsController()
        {
            cl = new MyServiceClient();
        }
 
        public ActionResult Index()
        {
            List <Models.Ticket> list = new List<Models.Ticket>() {};
            foreach (var v in cl.GetTickets())
            {
                list.Add(new Ticket(v));
            }
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var ticket = GetById(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            return View(ticket);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket t)
        {
            if (ModelState.IsValid)
            {
                DotNet.Ticket ticket = new DotNet.Ticket()
                {
                    Price = t.Price,
                    DateTime = t.DateTime,
                    Cinema = new Cinema(),
                    Movie = new Movie()
                };
                ticket.Cinema.CinemaId = t.Cinema.CinemaId;
                ticket.Movie.MovieId = t.Movie.MovieId;
                cl.AddTicket(ticket);
            }
            return RedirectToAction("Index");
        }
        

        public  ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var ticket = GetById(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            return View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DotNet.Ticket ticket = new DotNet.Ticket()
            {
                TicketId = id
            };
            cl.DeleteTicket(ticket);
            return RedirectToAction("Index");
        }

        private Ticket GetById(int? id)
        {
            List<Models.Ticket> list = new List<Models.Ticket>() { };
            foreach (var v in cl.GetTickets())
            {
                list.Add(new Ticket(v));
            }
            return list.SingleOrDefault(m => m.TicketId == id);
        }
    }
}