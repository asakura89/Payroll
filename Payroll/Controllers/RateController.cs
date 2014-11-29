using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Payroll.Helpers;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Controllers
{
    public class RateController : Controller
    {
        private ControllerHelper helper;
        private RateService service;

        public RateController()
        {
            helper = new ControllerHelper(this);
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            List<M_RATES> rateList;
            using (service = new RateService())
                rateList = service.GetAllRates();

            return View(rateList.Select(rate => new RateForView(rate)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            return View(new RateForView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_RATES rate = ConvertFormDataToRate(form);
            if (ModelState.IsValid)
            {
                using (service = new RateService())
                    service.CreateNewRate(rate);

                return RedirectToAction("Index");
            }

            return View(new RateForView(rate));
        }

        private M_RATES ConvertFormDataToRate(FormCollection form)
        {
            var rate = new M_RATES();
            rate.RATE_ID = form["Rate.RATE_ID"] ?? String.Empty;
            rate.RATE_NAME = form["Rate.RATE_NAME"];
            rate.RATE_TYPE = form["Rate.RATE_TYPE"];
            rate.RATE_VALUE = Convert.ToDecimal(form["Rate.RATE_VALUE"]);

            return rate;
        }

        [HttpGet]
        public ActionResult Edit(String id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_RATES rate;
            using (service = new RateService())
                rate = service.GetById(id);

            return View(new RateForView(rate));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_RATES rate = ConvertFormDataToRate(form);
            if (ModelState.IsValid)
            {
                using (service = new RateService())
                    service.UpdateExistingRate(rate);

                return RedirectToAction("Index");
            }

            return View(new RateForView(rate));
        }

        [HttpGet]
        public ActionResult Delete(String id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_RATES rate;
            using (service = new RateService())
                rate = service.GetById(id);

            return View(new RateForView(rate));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            using (service = new RateService())
                service.DeleteExistingRate(id);

            return RedirectToAction("Index");
        }
    }
}