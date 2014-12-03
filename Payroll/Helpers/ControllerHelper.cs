using System;
using System.IO;
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

        public String RenderPartialViewToString(String viewName, Object model)
        {
            ControllerContext ctx = currentController.ControllerContext;
            ViewDataDictionary viewData = currentController.ViewData;
            TempDataDictionary tempData = currentController.TempData;

            if (string.IsNullOrEmpty(viewName))
                viewName = ctx.RouteData.GetRequiredString("action");

            viewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ctx, viewName);
                var viewContext = new ViewContext(ctx, viewResult.View, viewData, tempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}