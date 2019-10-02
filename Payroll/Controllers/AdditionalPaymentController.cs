using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Payroll.Models;

namespace Payroll.Controllers {
    public class AdditionalPaymentController : Controller {
        readonly PayrollEntities db = new PayrollEntities();

        //
        // GET: /AdditionalPayment/

        public ActionResult Index() {
            IQueryable<d_AdditionalSalary> d_AdditionalSalary = db.d_AdditionalSalary.Include(t => t.m_Rate);
            return View(d_AdditionalSalary.ToList());
        }

        //
        // GET: /AdditionalPayment/Details/5

        public ActionResult Details(String id = null) {
            d_AdditionalSalary d_AdditionalSalary = db.d_AdditionalSalary.Find(id);
            if (d_AdditionalSalary == null) {
                return HttpNotFound();
            }
            return View(d_AdditionalSalary);
        }

        //
        // GET: /AdditionalPayment/Create

        public ActionResult Create() {
            ViewBag.RateId = new SelectList(db.m_Rate, "RateId", "RateName");
            return View();
        }

        //
        // POST: /AdditionalPayment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(d_AdditionalSalary d_AdditionalSalary) {
            if (ModelState.IsValid) {
                db.d_AdditionalSalary.Add(d_AdditionalSalary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RateId = new SelectList(db.m_Rate, "RateId", "RateName", d_AdditionalSalary.RateId);
            return View(d_AdditionalSalary);
        }

        //
        // GET: /AdditionalPayment/Edit/5

        public ActionResult Edit(String id = null) {
            d_AdditionalSalary d_AdditionalSalary = db.d_AdditionalSalary.Find(id);
            if (d_AdditionalSalary == null) {
                return HttpNotFound();
            }
            ViewBag.RateId = new SelectList(db.m_Rate, "RateId", "RateName", d_AdditionalSalary.RateId);
            return View(d_AdditionalSalary);
        }

        //
        // POST: /AdditionalPayment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(d_AdditionalSalary d_AdditionalSalary) {
            if (ModelState.IsValid) {
                db.Entry(d_AdditionalSalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RateId = new SelectList(db.m_Rate, "RateId", "RateName", d_AdditionalSalary.RateId);
            return View(d_AdditionalSalary);
        }

        //
        // GET: /AdditionalPayment/Delete/5

        public ActionResult Delete(String id = null) {
            d_AdditionalSalary d_AdditionalSalary = db.d_AdditionalSalary.Find(id);
            if (d_AdditionalSalary == null) {
                return HttpNotFound();
            }
            return View(d_AdditionalSalary);
        }

        //
        // POST: /AdditionalPayment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id) {
            d_AdditionalSalary d_AdditionalSalary = db.d_AdditionalSalary.Find(id);
            db.d_AdditionalSalary.Remove(d_AdditionalSalary);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(Boolean disposing) {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}