using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Your_IoT_Handprint.Models;

namespace Your_IoT_Handprint.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // Vaka se zema logiran user: 
        private ApplicationUser loggedInUser = System.Web.HttpContext.Current
            .GetOwinContext().GetUserManager<ApplicationUserManager>()
            .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ProjectsController()
        {
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.db));
        }


        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/ProjectDetailsByUser/5
        public ActionResult ProjectDetailsByUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }



        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AvgRating,ImageUrl,Description,GithubRepoUrl,ForSale,Quantity,UserId")] Project project)
        {
            if (ModelState.IsValid)
            {
                // Vaka se zema logiran user: 
                //ApplicationUser loggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                project.CreatorUsername = loggedInUser.UserName;
                project.UserId = loggedInUser.Id;

                project.AllRatingsString = "";


                db.projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("ProjectsAndEventsByUser", "ProjectsAndEvents");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", project.UserId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", project.UserId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AvgRating,ImageUrl,Description,GithubRepoUrl,ForSale,Quantity,UserId")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.CreatorUsername = loggedInUser.UserName;
                project.UserId = loggedInUser.Id;

                project.AllRatingsString = "";

                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProjectsAndEventsByUser", "ProjectsAndEvents");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", project.UserId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.projects.Find(id);
            db.projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("ProjectsAndEventsByUser", "ProjectsAndEvents");
        }


        // POST: Projects/RateProject/5
        [HttpPost]
        public ActionResult RateProject(int id, int rating)
        {
            Project project = db.projects.Find(id);
            
            //project.AllRatings.Add(rating);
            project.addNewRating(rating);

            db.Entry(project).State = EntityState.Modified;
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
