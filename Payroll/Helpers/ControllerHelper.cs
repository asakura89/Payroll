using System;
using System.IO;
using System.Web.Mvc;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Helpers {
    public class ControllerHelper {
        readonly Controller currentController;
        public m_User AuthorizedUser {
            get { return currentController.Session[LoginService.LoggedUser] as m_User; }
            set { currentController.Session[LoginService.LoggedUser] = value; }
        }

        public ControllerHelper(Controller currentController) {
            this.currentController = currentController;
        }

        public String RenderPartialViewToString(String viewName, Object model) {
            ControllerContext ctx = currentController.ControllerContext;
            ViewDataDictionary viewData = currentController.ViewData;
            TempDataDictionary tempData = currentController.TempData;

            if (String.IsNullOrEmpty(viewName))
                viewName = ctx.RouteData.GetRequiredString("action");

            viewData.Model = model;

            using (var sw = new StringWriter()) {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ctx, viewName);
                var viewContext = new ViewContext(ctx, viewResult.View, viewData, tempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}