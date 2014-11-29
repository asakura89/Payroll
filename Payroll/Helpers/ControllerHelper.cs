using System.Web.Mvc;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Helpers
{
    public class ControllerHelper
    {
        private Controller currentController;
        public M_USER AuthorizedUser
        {
            get { return currentController.Session[LoginService.LoggedUser] as M_USER; }
            set { currentController.Session[LoginService.LoggedUser] = value; }
        }

        public ControllerHelper(Controller currentController)
        {
            this.currentController = currentController;
        }
    }
}