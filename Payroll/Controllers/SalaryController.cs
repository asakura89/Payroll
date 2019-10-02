using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Payroll.Helpers;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Controllers {
    public class SalaryController : Controller {
        readonly ControllerHelper helper;
        SalaryService service;

        public SalaryController() {
            helper = new ControllerHelper(this);
        }

        [HttpGet]
        public ActionResult Index() {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            List<d_Salary> salaryList;
            using (service = new SalaryService())
                salaryList = service.GetAllSalaries();

            return View(salaryList.Select(salary => new SalaryForView(salary)));
        }

        [HttpGet]
        public ActionResult Create() {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            return View(new SalaryForView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form) {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            d_Salary salary = ConvertFormDataToSalary(form);
            if (ModelState.IsValid) {
                using (service = new SalaryService())
                    service.CreateNewSalary(salary);

                return RedirectToAction("Index");
            }

            return View(new SalaryForView(salary));
        }

        d_Salary ConvertFormDataToSalary(FormCollection form) {
            var salary = new d_Salary {
                SalaryId= form["Salary.SalaryId"] ?? String.Empty,
                Username = form["Salary.Username"],
                BasicSalary = Convert.ToDecimal(form["Salary.BasicSalary"])
            };

            return salary;
        }

        [HttpGet]
        public ActionResult Edit(String id = null) {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            d_Salary salary;
            using (service = new SalaryService())
                salary = service.GetById(id);

            return View(new SalaryForView(salary));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form) {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            d_Salary salary = ConvertFormDataToSalary(form);
            if (ModelState.IsValid) {
                using (service = new SalaryService())
                    service.UpdateExistingSalary(salary);

                return RedirectToAction("Index");
            }

            return View(new SalaryForView(salary));
        }

        [HttpGet]
        public ActionResult Delete(String id = null) {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            d_Salary salary;
            using (service = new SalaryService())
                salary = service.GetById(id);

            return View(new SalaryForView(salary));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id = null) {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            using (service = new SalaryService())
                service.DeleteExistingSalary(id);

            return RedirectToAction("Index");
        }
    }
}