using System;
using System.Collections.Generic;
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

            List<m_User> userList;
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

            m_User user = ConvertFormDataToUser(form);
            if (ModelState.IsValid)
            {
                using (service = new UserService())
                    service.CreateNewUser(user);

                return RedirectToAction("Index");
            }

            return View(new UserForView(user));
        }

        private m_User ConvertFormDataToUser(FormCollection form)
        {
            var user = new m_User();
            user.Username = form["User.Username"] ?? String.Empty;
            user.Password = form["User.Password"];
            user.Category = form["User.Category"];

            return user;
        }

        [HttpGet]
        public ActionResult Edit(string id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            m_User user;
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

            m_User user = ConvertFormDataToUser(form);
            if (ModelState.IsValid)
            {
                using (service = new UserService())
                    service.UpdateExistingUser(user);

                return RedirectToAction("Index");
            }

            return View(new UserForView(user));
        }

        [HttpPost]
        public ActionResult ChangePasswordView(String username)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            m_User user;
            try
            {
                using (service = new UserService())
                    user = service.GetByUsername(username);
            }
            catch (Exception ex)
            {
                return Json(new ViewMessageResult(0, ex.Message + "<br><br/>" + ex.StackTrace));
            }

            return Json(new ViewMessageResult(1, "Ok", helper.RenderPartialViewToString("_ChangePassword", new UserForView(user))));
        }

        [HttpPost]
        public ActionResult ChangePassword(FormCollection form)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            try
            {
                using (service = new UserService())
                    service.ChangePassword(form["User.USERNAME"], form["OldPassword"], form["ConfirmOldPassword"], form["NewPassword"]);
            }
            catch (InvalidOperationException ioex)
            {
                TempData.Add("ErrorMessage", ioex.Message);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData.Add("ErrorMessage", ex.Message + "<br><br/>" + ex.StackTrace);
                return RedirectToAction("Index");
            }

            TempData.Add("InfoMessage", "Password changed succesfully.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(String id = null)
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            m_User user;
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