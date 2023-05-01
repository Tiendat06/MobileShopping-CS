using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webMVC.Models;

namespace webMVC.Controllers
{
    public class DependentsController : Controller
    {
        private DevConn db = new DevConn();

        // GET: Dependents
        public ActionResult Index()
        {
            var dependents = db.Dependents.Include(d => d.Employee);
            return View(dependents.ToList());
        }

        // GET: Dependents/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dependent dependent = db.Dependents.Find(id);
            if (dependent == null)
            {
                return HttpNotFound();
            }
            return View(dependent);
        }

        // GET: Dependents/Create
        public ActionResult Create()
        {
            ViewBag.ESSN = new SelectList(db.Employees, "SSN", "FName");
            return View();
        }

        // POST: Dependents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ESSN,Dependent_Name,Sex,BDate,Relationship")] Dependent dependent)
        {
            if (ModelState.IsValid)
            {
                db.Dependents.Add(dependent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ESSN = new SelectList(db.Employees, "SSN", "FName", dependent.ESSN);
            return View(dependent);
        }

        // GET: Dependents/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dependent dependent = db.Dependents.Find(id);
            if (dependent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ESSN = new SelectList(db.Employees, "SSN", "FName", dependent.ESSN);
            return View(dependent);
        }

        // POST: Dependents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ESSN,Dependent_Name,Sex,BDate,Relationship")] Dependent dependent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dependent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ESSN = new SelectList(db.Employees, "SSN", "FName", dependent.ESSN);
            return View(dependent);
        }

        // GET: Dependents/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dependent dependent = db.Dependents.Find(id);
            if (dependent == null)
            {
                return HttpNotFound();
            }
            return View(dependent);
        }

        // POST: Dependents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dependent dependent = db.Dependents.Find(id);
            db.Dependents.Remove(dependent);
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
