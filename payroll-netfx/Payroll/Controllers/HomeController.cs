using System;
using System.Web.Mvc;
using Payroll.Helpers;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Controllers {
    public class HomeController : Controller {
        readonly ControllerHelper helper;

        public HomeController() {
            helper = new ControllerHelper(this);
        }

        [HttpGet]
        public ActionResult Index() => this.HandleDefaultPipeline("home:Index");

        [HttpGet]
        public ActionResult Login() => this.HandleDefaultPipeline("home:Login");

        [HttpPost]
        public ActionResult Login(m_User user) {
            var loginSvc = new LoginService();
            Boolean isUserValid = loginSvc.IsUserValid(user.Username, user.Password);
            if (isUserValid) {
                var userSvc = new UserService();
                helper.AuthorizedUser = userSvc.GetByUsername(user.Username);
                return Redirect(Url.Action("Dashboard", "Home"));
            }

            return Redirect(Url.Action("Login", "Home"));
        }

        [HttpGet]
        public ActionResult Dashboard() {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            return View(helper.AuthorizedUser);
        }

        [HttpGet]
        public ActionResult Logout() {
            helper.AuthorizedUser = null;

            return Redirect(Url.Action("Login", "Home"));
        }
    }
}
