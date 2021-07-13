using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Arvy;
using Payroll.Pipeline;
using Ria;
using Shiro;

namespace Payroll.Helpers {
    public static class ControllerExt {
        public static ActionResult HandleDefaultPipeline(this Controller controller, String pipelineName) {
            var pipelineContext = new PipelineContext { Context = new ControllerPipelineContext { Controller = controller } };
            IList<ActionResponseViewModel> result = GlobalContext.PipelineExecutor.Execute(pipelineName, pipelineContext);
            if (pipelineContext.Cancelled) {
                LogExt.Info(controller.GetFormattedCallerInfoString(), "Pipeline is cancelled.");
            }

            if (result.Any()) {
                IEnumerable<String> infos = result
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Info)
                    .Select(resultItem => resultItem.Message);

                foreach (String info in infos)
                    LogExt.Info(controller.GetFormattedCallerInfoString(), info);

                IEnumerable<String> warns = result
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Warning)
                    .Select(resultItem => resultItem.Message);

                foreach (String warn in warns)
                    LogExt.Warn(controller.GetFormattedCallerInfoString(), warn);

                IEnumerable<String> errors = result
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Error)
                    .Select(resultItem => resultItem.Message);

                foreach (String error in errors)
                    LogExt.Error(controller.GetFormattedCallerInfoString(), error);

                return new HttpStatusCodeResult(500);
            }

            var context = pipelineContext.Context as ControllerPipelineContext;
            return context.ActionResult;
        }
    }
}