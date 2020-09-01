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
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUser loggedInUser = System.Web.HttpContext.Current.GetOwinContext()
            .GetUserManager<ApplicationUserManager>()
            .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        // GET: Orders
        public ActionResult Index()
        {
            List<Order> myOrders = new List<Order>();
            foreach(Project p in loggedInUser.MyProjects)
            {
                foreach(Order o in db.orders.ToList())
                {
                    if (o.ProjectId.Equals(p.Id))
                    {
                        myOrders.Add(o);
                    }  
                }
            }
            // List<Order> orders = db.orders.ToList().Where(ordr => ordr.ProjectId)
            return View(myOrders);
        }

        // GET: Orders/Details/5
        /*
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }*/

        // GET: Orders/Create/5
        public ActionResult Create(int id)
        {
            ViewBag.ProjectId = id;
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecipientAdress,Quantity,ProjectId")] Order order)
        {
            if (ModelState.IsValid)
            {
                Project theProject = db.projects.Find(order.ProjectId);
                // povik order na proekt
                // nekako da se sejvne proektot
                bool rez = theProject.order(order.Quantity);
                if (rez)
                {
                    db.Entry(theProject).State = EntityState.Modified;

                    //order.User = loggedInUser;
                    order.UserId = loggedInUser.Id;
                    order.CreatorUsername = loggedInUser.UserName;
                    db.orders.Add(order);
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index","ProjectsAndEvents");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,OrderedOn,RecipientAdress,ProjectId")] Order order)
        public ActionResult Edit([Bind(Include = "Id,OrderedOn,RecipientAdress,ProjectId,Status")] Order order)
        {
            //if (ModelState.IsValid)
            //{
            order.UserId = loggedInUser.Id;
            order.CreatorUsername = loggedInUser.UserName;

            db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.orders.Find(id);
            db.orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
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
