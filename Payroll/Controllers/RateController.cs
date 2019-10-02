using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Payroll.Helpers;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Controllers {
    public class RateController : Controller {
        readonly ControllerHelper helper;
        RateService service;

        public RateController() {
            helper = new ControllerHelper(this);
        }

        [HttpGet]
        public ActionResult Index() {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            List<m_Rate> rateList;
            using (service = new RateService())
                rateList = service.GetAllRates();

            return View(rateList.Select(rate => new RateForView(rate)));
        }

        [HttpGet]
        public ActionResult Create() {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            return View(new RateForView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form) {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            m_Rate rate = ConvertFormDataToRate(form);
            if (ModelState.IsValid) {
                using (service = new RateService())
                    service.CreateNewRate(rate);

                return RedirectToAction("Index");
            }

            return View(new RateForView(rate));
        }

        m_Rate ConvertFormDataToRate(FormCollection form) {
            var rate = new m_Rate {
                RateId = form["Rate.RateId"] ?? String.Empty,
                RateName = form["Rate.RateName"],
                RateType = form["Rate.RateType"],
                RateValue = Convert.ToDecimal(form["Rate.RateValue"])
            };

            return rate;
        }

        [HttpGet]
        public ActionResult Edit(String id = null) {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            m_Rate rate;
            using (service = new RateService())
                rate = service.GetById(id);

            return View(new RateForView(rate));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form) {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            m_Rate rate = ConvertFormDataToRate(form);
            if (ModelState.IsValid) {
                using (service = new RateService())
                    service.UpdateExistingRate(rate);

                return RedirectToAction("Index");
            }

            return View(new RateForView(rate));
        }

        [HttpGet]
        public ActionResult Delete(String id = null) {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            m_Rate rate;
            using (service = new RateService())
                rate = service.GetById(id);

            return View(new RateForView(rate));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id = null) {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            using (service = new RateService())
                service.DeleteExistingRate(id);

            return RedirectToAction("Index");
        }
    }
}