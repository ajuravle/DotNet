using System.Collections.Generic;
using System.Linq;
using WebApplication.ServiceReference;
using WebApplication.Models;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class MoviesController : Controller
    {
        private MyServiceClient cl;
        public MoviesController()
        {
            cl = new MyServiceClient();
        }

        public ActionResult Index()
        {
            List <Models.Movie> list = new List<Models.Movie>() {};
            foreach (var v in cl.GetMovies())
            {
                list.Add(new Movie(v,true));
            }
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var movie = GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                DotNet.Movie movie = new DotNet.Movie()
                {
                    Title = m.Title,
                    Genre = m.Genre,
                    AgeRestriction = m.AgeRestriction
                };
                cl.AddMovie(movie);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var movie = GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,Movie m)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                DotNet.Movie movie = cl.GetMovies().SingleOrDefault(mm => mm.MovieId == id);
                movie.Title = m.Title;
                movie.Genre = m.Genre;
                movie.AgeRestriction = m.AgeRestriction;
                
                cl.UpdateMovie(movie);
            }
            return RedirectToAction("Index");
        }

        public  ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var movie = GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DotNet.Movie movie = new DotNet.Movie()
            {
                MovieId = id
            };
            cl.DeleteMovie(movie);
            return RedirectToAction("Index");
        }

        private Movie GetById(int? id)
        {
            List<Models.Movie> list = new List<Models.Movie>() { };
            foreach (var v in cl.GetMovies())
            {
                list.Add(new Movie(v,true));
            }
            return list.SingleOrDefault(m => m.MovieId == id);
        }
    }
}