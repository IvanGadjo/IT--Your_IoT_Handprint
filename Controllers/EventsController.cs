using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Your_IoT_Handprint.Models;

namespace Your_IoT_Handprint.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUser loggedInUser = System.Web.HttpContext.Current
            .GetOwinContext().GetUserManager<ApplicationUserManager>()
            .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());


        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/EventDetailsByUser/5
        public ActionResult EventDetailsByUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }




        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatorUsername,AvgRating,ImageUrl,Location,Description,EventLinkUrl,Date,UserId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                // Vaka se zema logiran user: 
                ApplicationUser loggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                @event.CreatorUsername = loggedInUser.UserName;
                @event.UserId = loggedInUser.Id;

                @event.AllRatingsString = "";

                db.events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("ProjectsAndEventsByUser", "ProjectsAndEvents");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", @event.UserId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", @event.UserId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatorUsername,AvgRating,ImageUrl,Location,Description,EventLinkUrl,Date,UserId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.CreatorUsername = loggedInUser.UserName;
                @event.UserId = loggedInUser.Id;

                @event.AllRatingsString = "";

                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProjectsAndEventsByUser", "ProjectsAndEvents");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", @event.UserId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.events.Find(id);
            db.events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("ProjectsAndEventsByUser", "ProjectsAndEvents");
        }


        // POST: Events/RateProject/5
        [HttpPost]
        public ActionResult RateEvent(int id, int rating)
        {
            Event ev = db.events.Find(id);

            //project.AllRatings.Add(rating);
            ev.addNewRating(rating);

            db.Entry(ev).State = EntityState.Modified;
            //db.projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index", "ProjectsAndEvents");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
