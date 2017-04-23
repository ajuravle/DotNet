using System.Collections.Generic;
using System.Linq;
using WebApplication.ServiceReference;
using WebApplication.Models;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class CinemasController : Controller
    {
        private MyServiceClient cl;
        public CinemasController()
        {
            cl = new MyServiceClient();
        }
        // GET: Cinemas
        public ActionResult Index()
        {
            List <Models.Cinema> list = new List<Models.Cinema>() {};
            foreach (var v in cl.GetCinemas())
            {
                list.Add(new Cinema(v));
            }
            return View(list);
        }

        // GET: Cinemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var cinema = GetById(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }

            return View(cinema);
        }

        // GET: Cinemas/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cinema c)
        {
            if (ModelState.IsValid)
            {
                DotNet.Cinema cinema = new DotNet.Cinema()
                {
                    Name = c.Name,
                    City = c.City,
                    Address = c.Address,
                    NrRooms = c.NrRooms
                };
                cl.AddCinema(cinema);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var cinema = GetById(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }

            return View(cinema);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,Cinema c)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                DotNet.Cinema cinema = new DotNet.Cinema()
                {
                    CinemaId = (int)id,
                    Name = c.Name,
                    City = c.City,
                    Address = c.Address,
                    NrRooms = c.NrRooms
                };
                cl.UpdateCinema(cinema);
            }
            return RedirectToAction("Index");
        }

        public  ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var cinema = GetById(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }

            return View(cinema);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DotNet.Cinema cinema = new DotNet.Cinema()
            {
                CinemaId = id
            };
            cl.DeleteCinema(cinema);
            return RedirectToAction("Index");
        }

        private Cinema GetById(int? id)
        {
            List<Models.Cinema> list = new List<Models.Cinema>() { };
            foreach (var v in cl.GetCinemas())
            {
                list.Add(new Cinema(v));
            }
            return list.SingleOrDefault(m => m.CinemaId == id);
        }
    }
}