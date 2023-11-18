using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Payroll.Models;

namespace Payroll.Controllers {
    public class DayOffController : Controller {
        readonly PayrollEntities db = new PayrollEntities();

        //
        // GET: /DayOff/

        public ActionResult Index() {
            IQueryable<d_DayOff> d_DayOff = db.d_DayOff.Include(t => t.m_User);
            return View(d_DayOff.ToList());
        }

        //
        // GET: /DayOff/Details/5

        public ActionResult Details(String id = null) {
            d_DayOff d_DayOff = db.d_DayOff.Find(id);
            if (d_DayOff == null) {
                return HttpNotFound();
            }
            return View(d_DayOff);
        }

        //
        // GET: /DayOff/Create

        public ActionResult Create() {
            ViewBag.Username = new SelectList(db.m_User, "Username", "Password");
            return View();
        }

        //
        // POST: /DayOff/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(d_DayOff d_DayOff) {
            if (ModelState.IsValid) {
                db.d_DayOff.Add(d_DayOff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.m_User, "Username", "Password", d_DayOff.Username);
            return View(d_DayOff);
        }

        //
        // GET: /DayOff/Edit/5

        public ActionResult Edit(String id = null) {
            d_DayOff d_DayOff = db.d_DayOff.Find(id);
            if (d_DayOff == null) {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.m_User, "Username", "Password", d_DayOff.Username);
            return View(d_DayOff);
        }

        //
        // POST: /DayOff/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(d_DayOff d_DayOff) {
            if (ModelState.IsValid) {
                db.Entry(d_DayOff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.m_User, "Username", "Password", d_DayOff.Username);
            return View(d_DayOff);
        }

        //
        // GET: /DayOff/Delete/5

        public ActionResult Delete(String id = null) {
            d_DayOff d_DayOff = db.d_DayOff.Find(id);
            if (d_DayOff == null) {
                return HttpNotFound();
            }
            return View(d_DayOff);
        }

        //
        // POST: /DayOff/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id) {
            d_DayOff d_DayOff = db.d_DayOff.Find(id);
            db.d_DayOff.Remove(d_DayOff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(Boolean disposing) {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}