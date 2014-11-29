using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Payroll.Helpers;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Controllers
{
    public class SalaryController : Controller
    {
        private ControllerHelper helper;
        private SalaryService service;

        public SalaryController()
        {
            helper = new ControllerHelper(this);
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            List<M_EMP_SALARY> salaryList;
            using (service = new SalaryService())
                salaryList = service.GetAllSalaries();

            return View(salaryList.Select(salary => new SalaryForView(salary)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            return View(new SalaryForView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_EMP_SALARY salary = ConvertFormDataToSalary(form);
            if (ModelState.IsValid)
            {
                using (service = new SalaryService())
                    service.CreateNewSalary(salary);

                return RedirectToAction("Index");
            }

            return View(new SalaryForView(salary));
        }

        private M_EMP_SALARY ConvertFormDataToSalary(FormCollection form)
        {
            var salary = new M_EMP_SALARY();
            salary.SALARY_ID = form["Salary.SALARY_ID"] ?? String.Empty;
            salary.USERNAME = form["Salary.USERNAME"];
            salary.BASIC_SALARY = Convert.ToDecimal(form["Salary.BASIC_SALARY"]);

            return salary;
        }

        [HttpGet]
        public ActionResult Edit(String id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_EMP_SALARY salary;
            using (service = new SalaryService())
                salary = service.GetById(id);

            return View(new SalaryForView(salary));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_EMP_SALARY salary = ConvertFormDataToSalary(form);
            if (ModelState.IsValid)
            {
                using (service = new SalaryService())
                    service.UpdateExistingSalary(salary);

                return RedirectToAction("Index");
            }

            return View(new SalaryForView(salary));
        }

        [HttpGet]
        public ActionResult Delete(String id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_EMP_SALARY salary;
            using (service = new SalaryService())
                salary = service.GetById(id);

            return View(new SalaryForView(salary));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            using (service = new SalaryService())
                service.DeleteExistingSalary(id);

            return RedirectToAction("Index");
        }
    }
}