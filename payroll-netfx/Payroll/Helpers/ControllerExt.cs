using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Payroll.Pipeline;
using Ria;

namespace Payroll.Helpers {
    public static class ControllerExt {
        public static ActionResult HandleDefaultPipeline(this Controller controller, String pipelineName) {
            var executor = GlobalContext.ServiceRegistry.GetService<IPipelineExecutor>();
            PipelineContext result = executor.Execute(pipelineName, new Dictionary<String, Object> {
                ["Controller"] = controller,
                ["ActionResult"] = null
            });

            var cancelledHandler = GlobalContext.ServiceRegistry.GetService<ICancelledPipelineHandler>();
            cancelledHandler.Handle(result);

            var resultHandler = GlobalContext.ServiceRegistry.GetService<IPipelineResultHandler>();
            resultHandler.Handle(result);

            return result.Data["ActionResult"] as ActionResult;
        }
    }
}