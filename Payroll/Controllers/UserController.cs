using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Payroll.Helpers;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Controllers
{
    public class UserController : Controller
    {
        private ControllerHelper helper;
        private UserService service;

        public UserController()
        {
            helper = new ControllerHelper(this);
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            List<M_USER> userList;
            using (service = new UserService())
                userList = service.GetAllUsers();

            return View(userList.Select(user => new UserForView(user)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            return View(new UserForView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_USER user = ConvertFormDataToUser(form);
            if (ModelState.IsValid)
            {
                using (service = new UserService())
                    service.CreateNewUser(user);

                return RedirectToAction("Index");
            }

            return View(new UserForView(user));
        }

        private M_USER ConvertFormDataToUser(FormCollection form)
        {
            var user = new M_USER();
            user.USERNAME = form["User.USERNAME"] ?? String.Empty;
            user.USERPASS = form["User.USERPASS"];
            user.USER_CATEGORY = form["User.USER_CATEGORY"];

            return user;
        }

        [HttpGet]
        public ActionResult Edit(string id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_USER user;
            using (service = new UserService())
                user = service.GetByUsername(id);

            return View(new UserForView(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_USER user = ConvertFormDataToUser(form);
            if (ModelState.IsValid)
            {
                using (service = new UserService())
                    service.UpdateExistingUser(user);

                return RedirectToAction("Index");
            }

            return View(new UserForView(user));
        }

        [HttpPost]
        public ActionResult ChangePassword(FormCollection form)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_USER user = ConvertFormDataToUser(form);
            using (service = new UserService())
                service.ChangePassword(user);

            return View("Index");
        }

        [HttpGet]
        public ActionResult Delete(String id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            M_USER user;
            using (service = new UserService())
                user = service.GetByUsername(id);

            return View(new UserForView(user));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            using (service = new UserService())
                service.DeleteExistingUser(id);

            return RedirectToAction("Index");
        }
    }
}