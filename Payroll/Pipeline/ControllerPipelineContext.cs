using System.Web.Mvc;

namespace Payroll.Pipeline {
    public class ControllerPipelineContext {
        public Controller Controller { get; set; }
        public ActionResult ActionResult { get; set; }
    }
}