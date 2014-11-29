using System;
using Payroll.Helpers;
using Payroll.Models;
using System.Web.Mvc;
using Payroll.Services;

namespace Payroll.Controllers
{
    public class HomeController : Controller
    {
        private ControllerHelper helper;

        public HomeController()
        {
            helper = new ControllerHelper(this);
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            return Redirect(Url.Action("Dashboard", "Home"));
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (helper.AuthorizedUser == null)
                return View();

            return Redirect(Url.Action("Dashboard", "Home"));
        }

        [HttpPost]
        public ActionResult Login(M_USER user)
        {
            LoginService loginSvc = new LoginService();
            Boolean isUserValid = loginSvc.IsUserValid(user.USERNAME, user.USERPASS);
            if (isUserValid)
            {
                UserService userSvc = new UserService();
                helper.AuthorizedUser = userSvc.GetByUsername(user.USERNAME);
                return Redirect(Url.Action("Dashboard", "Home"));
            }

            return Redirect(Url.Action("Login", "Home"));
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            if (helper.AuthorizedUser == null)
                return Redirect(Url.Action("Login", "Home"));

            return View(helper.AuthorizedUser);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            helper.AuthorizedUser = null;

            return Redirect(Url.Action("Login", "Home"));
        }
    }
}
