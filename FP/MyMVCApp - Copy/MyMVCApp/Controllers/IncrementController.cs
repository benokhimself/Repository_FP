using MyMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApp.Controllers
{
    public class IncrementController : Controller
    {

        // GET: increment
        EmpDBContext db = new EmpDBContext();
        public ActionResult Index()
        {
            var increment = from e in db.Increment
                            orderby e.ID
                            select e;
                             
            return View(increment);
        }

        // GET: increment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: increment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: increment/Create
        [HttpPost]
        public ActionResult Create(Increment emp)
        {
            try
            {
                // TODO: Add insert logic here
                db.Increment.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: increment/Edit/5


        public ActionResult Edit(int id)
        {
            
            var increment = db.Increment.Single(m => m.ID == id);
            return View(increment);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,counter")] Increment increment)
        {
 
            // TODO: Add update logic here 
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(increment).State = System.Data.Entity.EntityState.Modified;
                     
                    db.Entry(increment).Entity.counter = db.Entry(increment).Entity.counter + 1;
                    db.SaveChanges();
                    return RedirectToAction("Edit");
                }
                return View(increment);
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Increment increment = db.Increment.Find(id);
            if (increment == null)
            {
                return HttpNotFound();
            }
            return View(increment);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Increment increment = db.Increment.Find(id);
            db.Increment.Remove(increment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
