using System;
using System.Web.Mvc;
using Payroll.Helpers;
using Ria;
using Shiro;

namespace Payroll.Pipeline {
    public class DefaultHomeControllerPipeline {
        public void BeforeExecutingController(PipelineContext pipelineContext) {
            var controller = pipelineContext.Data["Controller"] as Controller;
            LogExt.Info(controller.GetFormattedCallerInfoString(), "Before executing Controller.");
        }

        public void AfterExecutingController(PipelineContext pipelineContext) {
            var controller = pipelineContext.Data["Controller"] as Controller;
            LogExt.Info(controller.GetFormattedCallerInfoString(), "After executing Controller.");
        }

        public void HomeIndex(PipelineContext pipelineContext) {
            var controller = pipelineContext.Data["Controller"] as Controller;
            var helper = new ControllerHelper(controller);
            if (helper.AuthorizedUser == null) {
                String loginUrl = controller.Url.Action("Login", "Home");
                pipelineContext.Data["ActionResult"] = new RedirectResult(loginUrl);
                return;
            }

            String dashboardUrl = controller.Url.Action("Dashboard", "Home");
            pipelineContext.Data["ActionResult"] = new RedirectResult(dashboardUrl);
        }

        public void HomeLogin(PipelineContext pipelineContext) {
            var controller = pipelineContext.Data["Controller"] as Controller;
            var helper = new ControllerHelper(controller);
            if (helper.AuthorizedUser == null) {
                pipelineContext.Data["ActionResult"] = new ViewResult { ViewName = "~/Views/Home/Login.cshtml" };
                return;
            }

            String dashboardUrl = controller.Url.Action("Dashboard", "Home");
            pipelineContext.Data["ActionResult"] = new RedirectResult(dashboardUrl);
        }
    }
}