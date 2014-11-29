using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payroll.Models;

namespace Payroll.Controllers
{
    public class DayOffController : Controller
    {
        private PayrollEntities db = new PayrollEntities();

        //
        // GET: /DayOff/

        public ActionResult Index()
        {
            var t_dayoff = db.T_DAYOFF.Include(t => t.M_USER);
            return View(t_dayoff.ToList());
        }

        //
        // GET: /DayOff/Details/5

        public ActionResult Details(string id = null)
        {
            T_DAYOFF t_dayoff = db.T_DAYOFF.Find(id);
            if (t_dayoff == null)
            {
                return HttpNotFound();
            }
            return View(t_dayoff);
        }

        //
        // GET: /DayOff/Create

        public ActionResult Create()
        {
            ViewBag.USERNAME = new SelectList(db.M_USER, "USERNAME", "USERPASS");
            return View();
        }

        //
        // POST: /DayOff/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T_DAYOFF t_dayoff)
        {
            if (ModelState.IsValid)
            {
                db.T_DAYOFF.Add(t_dayoff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USERNAME = new SelectList(db.M_USER, "USERNAME", "USERPASS", t_dayoff.USERNAME);
            return View(t_dayoff);
        }

        //
        // GET: /DayOff/Edit/5

        public ActionResult Edit(string id = null)
        {
            T_DAYOFF t_dayoff = db.T_DAYOFF.Find(id);
            if (t_dayoff == null)
            {
                return HttpNotFound();
            }
            ViewBag.USERNAME = new SelectList(db.M_USER, "USERNAME", "USERPASS", t_dayoff.USERNAME);
            return View(t_dayoff);
        }

        //
        // POST: /DayOff/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(T_DAYOFF t_dayoff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_dayoff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USERNAME = new SelectList(db.M_USER, "USERNAME", "USERPASS", t_dayoff.USERNAME);
            return View(t_dayoff);
        }

        //
        // GET: /DayOff/Delete/5

        public ActionResult Delete(string id = null)
        {
            T_DAYOFF t_dayoff = db.T_DAYOFF.Find(id);
            if (t_dayoff == null)
            {
                return HttpNotFound();
            }
            return View(t_dayoff);
        }

        //
        // POST: /DayOff/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            T_DAYOFF t_dayoff = db.T_DAYOFF.Find(id);
            db.T_DAYOFF.Remove(t_dayoff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}