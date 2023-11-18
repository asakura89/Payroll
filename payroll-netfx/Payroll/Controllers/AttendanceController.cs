using System.Web.Mvc;
using Payroll.Helpers;

namespace Payroll.Controllers {

    public class AttendanceController : Controller {
        readonly ControllerHelper helper;

        public AttendanceController() {
            helper = new ControllerHelper(this);
        }

        [HttpGet]
        public ActionResult Index() => this.HandleDefaultPipeline("attendance:Index");

        [HttpPost]
        public ActionResult ClockIn() => this.HandleDefaultPipeline("attendance:ClockIn");

        [HttpPost]
        public ActionResult ClockOut() => this.HandleDefaultPipeline("attendance:ClockOut");

        [HttpPost]
        public ActionResult SubmitCustom() => this.HandleDefaultPipeline("attendance:SubmitCustom");


    }
}