using System.Collections.Generic;
using System.Linq;
using WebApplication.ServiceReference;
using WebApplication.Models;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class ActorsController : Controller
    {
        private MyServiceClient cl;
        public ActorsController()
        {
            cl = new MyServiceClient();
        }

        public ActionResult Index()
        {
            List <Models.Actor> list = new List<Models.Actor>() {};
            foreach (var v in cl.GetActors())
            {
                list.Add(new Actor(v,true));
            }
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var actor = GetById(id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            return View(actor);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor a)
        {
            if (ModelState.IsValid)
            {
                DotNet.Actor actor = new DotNet.Actor()
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthDate = a.BirthDate
                };
                cl.AddActor(actor);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var actor = GetById(id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            return View(actor);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,Actor a)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                DotNet.Actor actor = cl.GetActors().SingleOrDefault(mm => mm.ActorId == id);
                actor.FirstName = a.FirstName;
                actor.LastName = a.LastName;
                actor.BirthDate = a.BirthDate;
                
                cl.UpdateActor(actor);
            }
            return RedirectToAction("Index");
        }

        public  ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var actor = GetById(id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DotNet.Actor actor = new DotNet.Actor()
            {
                ActorId = id
            };
            cl.DeleteActor(actor);
            return RedirectToAction("Index");
        }

        private Actor GetById(int? id)
        {
            List<Models.Actor> list = new List<Models.Actor>() { };
            foreach (var v in cl.GetActors())
            {
                list.Add(new Actor(v,true));
            }
            return list.SingleOrDefault(m => m.ActorId == id);
        }
    }
}