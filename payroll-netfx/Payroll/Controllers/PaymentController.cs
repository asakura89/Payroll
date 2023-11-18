using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Payroll.Models;

namespace Payroll.Controllers {
    public class PaymentController : Controller {
        readonly PayrollEntities db = new PayrollEntities();

        //
        // GET: /Payment/

        public ActionResult Index() {
            IQueryable<d_Payment> d_Payment = db.d_Payment.Include(t => t.m_User);
            return View(d_Payment.ToList());
        }

        //
        // GET: /Payment/Details/5

        public ActionResult Details(String id = null) {
            d_Payment d_Payment = db.d_Payment.Find(id);
            if (d_Payment == null) {
                return HttpNotFound();
            }
            return View(d_Payment);
        }

        //
        // GET: /Payment/Create

        public ActionResult Create() {
            ViewBag.Username = new SelectList(db.m_User, "Username", "Password");
            return View();
        }

        //
        // POST: /Payment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(d_Payment d_Payment) {
            if (ModelState.IsValid) {
                db.d_Payment.Add(d_Payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.m_User, "Username", "Password", d_Payment.Username);
            return View(d_Payment);
        }

        //
        // GET: /Payment/Edit/5

        public ActionResult Edit(String id = null) {
            d_Payment d_Payment = db.d_Payment.Find(id);
            if (d_Payment == null) {
                return HttpNotFound();
            }
            ViewBag.USERNAME = new SelectList(db.m_User, "Username", "Password", d_Payment.Username);
            return View(d_Payment);
        }

        //
        // POST: /Payment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(d_Payment d_Payment) {
            if (ModelState.IsValid) {
                db.Entry(d_Payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USERNAME = new SelectList(db.m_User, "Username", "Password", d_Payment.Username);
            return View(d_Payment);
        }

        //
        // GET: /Payment/Delete/5

        public ActionResult Delete(String id = null) {
            d_Payment d_Payment = db.d_Payment.Find(id);
            if (d_Payment == null) {
                return HttpNotFound();
            }
            return View(d_Payment);
        }

        //
        // POST: /Payment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id) {
            d_Payment d_Payment = db.d_Payment.Find(id);
            db.d_Payment.Remove(d_Payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(Boolean disposing) {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}