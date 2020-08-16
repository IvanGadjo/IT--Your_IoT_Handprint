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

        // GET: ProjectsAndEvents
        public ActionResult Index()
        {
            EventsAndProjects model = new EventsAndProjects();
            model.Projects = db.projects.ToList();
            model.Events = db.events.ToList();
            return View(model);
        }

        // GET: ProjectsAndEvents/ProjectDetails/5
        public ActionResult ProjectDetails(int id)
        {
            return View();
        }

        // GET: ProjectsAndEvents/EventDetails/5
        public ActionResult EventDetails(int id)
        {
            return View();
        }





        // GET: ProjectsAndEvents/CreateProject
        public ActionResult CreateProject()
        {
            // return View();
            return RedirectToAction("Create", "Projects");
        }

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

        // GET: ProjectsAndEvents/CreateEvent
        public ActionResult CreateEvent()
        {
            return View();
        }

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






        // GET: ProjectsAndEvents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

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

        // GET: ProjectsAndEvents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

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
    }
}
