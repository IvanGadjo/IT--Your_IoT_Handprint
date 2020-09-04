using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Your_IoT_Handprint.Models;
using Your_IoT_Handprint.Models.Helpers;

namespace Your_IoT_Handprint.Controllers
{
    public class ProjectsAndEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUser loggedInUser = System.Web.HttpContext.Current.GetOwinContext()
            .GetUserManager<ApplicationUserManager>()
            .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        // GET: ProjectsAndEvents
        // All projects and events
        public ActionResult Index()
        {
            EventsAndProjects model = new EventsAndProjects();
            model.Projects = db.projects.ToList();
            model.Events = db.events.ToList();
            ViewBag.LoggedInUserId = loggedInUser.Id;
            return View(model);
        }

        // GET: ProjectsAndEventsByUser
        // Projects and events of the user
        public ActionResult ProjectsAndEventsByUser()
        {
            ApplicationUser loggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            EventsAndProjects model = new EventsAndProjects();
            model.Projects = db.projects.ToList().Where(pr => pr.UserId.Equals(loggedInUser.Id)).ToList();
            model.Events = db.events.ToList().Where(ev => ev.UserId.Equals(loggedInUser.Id)).ToList();
            return View(model);
        }






        // ----- UNUSED
        /*
        // GET: ProjectsAndEvents/ProjectDetails/5
        public ActionResult ProjectDetails(int id)
        {
            return View();
        }

        // ----- UNUSED
        // GET: ProjectsAndEvents/EventDetails/5
        public ActionResult EventDetails(int id)
        {
            return View();
        }


        // ----- UNUSED
        // GET: ProjectsAndEvents/CreateProject
        public ActionResult CreateProject()
        {
            // return View();
            return RedirectToAction("Create", "Projects");
        }

        // ----- UNUSED
        // POST: ProjectsAndEvents/CreateProject
        [HttpPost]
        public ActionResult CreateProject(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // ----- UNUSED
        // GET: ProjectsAndEvents/CreateEvent
        public ActionResult CreateEvent()
        {
            return View();
        }

        // ----- UNUSED
        // POST: ProjectsAndEvents/CreateEvent
        [HttpPost]
        public ActionResult CreateEvent(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





        // ----- UNUSED
        // GET: ProjectsAndEvents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // ----- UNUSED
        // POST: ProjectsAndEvents/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // ----- UNUSED
        // GET: ProjectsAndEvents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // ----- UNUSED
        // POST: ProjectsAndEvents/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
