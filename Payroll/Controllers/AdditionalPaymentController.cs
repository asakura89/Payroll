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
    public class AdditionalPaymentController : Controller
    {
        private PayrollEntities db = new PayrollEntities();

        //
        // GET: /AdditionalPayment/

        public ActionResult Index()
        {
            var t_additional_payment = db.T_ADDITIONAL_PAYMENT.Include(t => t.M_RATES);
            return View(t_additional_payment.ToList());
        }

        //
        // GET: /AdditionalPayment/Details/5

        public ActionResult Details(string id = null)
        {
            T_ADDITIONAL_PAYMENT t_additional_payment = db.T_ADDITIONAL_PAYMENT.Find(id);
            if (t_additional_payment == null)
            {
                return HttpNotFound();
            }
            return View(t_additional_payment);
        }

        //
        // GET: /AdditionalPayment/Create

        public ActionResult Create()
        {
            ViewBag.RATE_ID = new SelectList(db.M_RATES, "RATE_ID", "RATE_NAME");
            return View();
        }

        //
        // POST: /AdditionalPayment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T_ADDITIONAL_PAYMENT t_additional_payment)
        {
            if (ModelState.IsValid)
            {
                db.T_ADDITIONAL_PAYMENT.Add(t_additional_payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RATE_ID = new SelectList(db.M_RATES, "RATE_ID", "RATE_NAME", t_additional_payment.RATE_ID);
            return View(t_additional_payment);
        }

        //
        // GET: /AdditionalPayment/Edit/5

        public ActionResult Edit(string id = null)
        {
            T_ADDITIONAL_PAYMENT t_additional_payment = db.T_ADDITIONAL_PAYMENT.Find(id);
            if (t_additional_payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.RATE_ID = new SelectList(db.M_RATES, "RATE_ID", "RATE_NAME", t_additional_payment.RATE_ID);
            return View(t_additional_payment);
        }

        //
        // POST: /AdditionalPayment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(T_ADDITIONAL_PAYMENT t_additional_payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_additional_payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RATE_ID = new SelectList(db.M_RATES, "RATE_ID", "RATE_NAME", t_additional_payment.RATE_ID);
            return View(t_additional_payment);
        }

        //
        // GET: /AdditionalPayment/Delete/5

        public ActionResult Delete(string id = null)
        {
            T_ADDITIONAL_PAYMENT t_additional_payment = db.T_ADDITIONAL_PAYMENT.Find(id);
            if (t_additional_payment == null)
            {
                return HttpNotFound();
            }
            return View(t_additional_payment);
        }

        //
        // POST: /AdditionalPayment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            T_ADDITIONAL_PAYMENT t_additional_payment = db.T_ADDITIONAL_PAYMENT.Find(id);
            db.T_ADDITIONAL_PAYMENT.Remove(t_additional_payment);
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