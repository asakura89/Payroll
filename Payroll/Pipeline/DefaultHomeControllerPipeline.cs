using System;
using System.Web.Mvc;
using Payroll.Helpers;
using Ria;
using Shiro;

namespace Payroll.Pipeline {
    public class DefaultHomeControllerPipeline {
        public void BeforeExecutingController(PipelineContext pipelineContext) {
            var context = pipelineContext.Context as ControllerPipelineContext;
            LogExt.Info(context.Controller.GetFormattedCallerInfoString(), "Before executing Controller.");
        }

        public void AfterExecutingController(PipelineContext pipelineContext) {
            var context = pipelineContext.Context as ControllerPipelineContext;
            LogExt.Info(context.Controller.GetFormattedCallerInfoString(), "After executing Controller.");
        }

        public void HomeIndex(PipelineContext pipelineContext) {
            var context = pipelineContext.Context as ControllerPipelineContext;
            var helper = new ControllerHelper(context.Controller);
            if (helper.AuthorizedUser == null) {
                String loginUrl = context.Controller.Url.Action("Login", "Home");
                context.ActionResult = new RedirectResult(loginUrl);
                return;
            }

            String dashboardUrl = context.Controller.Url.Action("Dashboard", "Home");
            context.ActionResult = new RedirectResult(dashboardUrl);
        }

        public void HomeLogin(PipelineContext pipelineContext) {
            var context = pipelineContext.Context as ControllerPipelineContext;
            var helper = new ControllerHelper(context.Controller);
            if (helper.AuthorizedUser == null) {
                context.ActionResult = new ViewResult { ViewName = "~/Views/Home/Login.cshtml" };
                return;
            }

            String dashboardUrl = context.Controller.Url.Action("Dashboard", "Home");
            context.ActionResult = new RedirectResult(dashboardUrl);
        }
    }
}