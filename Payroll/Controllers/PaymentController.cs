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
    public class PaymentController : Controller
    {
        private PayrollEntities db = new PayrollEntities();

        //
        // GET: /Payment/

        public ActionResult Index()
        {
            var t_payment = db.T_PAYMENT.Include(t => t.M_USER);
            return View(t_payment.ToList());
        }

        //
        // GET: /Payment/Details/5

        public ActionResult Details(string id = null)
        {
            T_PAYMENT t_payment = db.T_PAYMENT.Find(id);
            if (t_payment == null)
            {
                return HttpNotFound();
            }
            return View(t_payment);
        }

        //
        // GET: /Payment/Create

        public ActionResult Create()
        {
            ViewBag.USERNAME = new SelectList(db.M_USER, "USERNAME", "USERPASS");
            return View();
        }

        //
        // POST: /Payment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T_PAYMENT t_payment)
        {
            if (ModelState.IsValid)
            {
                db.T_PAYMENT.Add(t_payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USERNAME = new SelectList(db.M_USER, "USERNAME", "USERPASS", t_payment.USERNAME);
            return View(t_payment);
        }

        //
        // GET: /Payment/Edit/5

        public ActionResult Edit(string id = null)
        {
            T_PAYMENT t_payment = db.T_PAYMENT.Find(id);
            if (t_payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.USERNAME = new SelectList(db.M_USER, "USERNAME", "USERPASS", t_payment.USERNAME);
            return View(t_payment);
        }

        //
        // POST: /Payment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(T_PAYMENT t_payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USERNAME = new SelectList(db.M_USER, "USERNAME", "USERPASS", t_payment.USERNAME);
            return View(t_payment);
        }

        //
        // GET: /Payment/Delete/5

        public ActionResult Delete(string id = null)
        {
            T_PAYMENT t_payment = db.T_PAYMENT.Find(id);
            if (t_payment == null)
            {
                return HttpNotFound();
            }
            return View(t_payment);
        }

        //
        // POST: /Payment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            T_PAYMENT t_payment = db.T_PAYMENT.Find(id);
            db.T_PAYMENT.Remove(t_payment);
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