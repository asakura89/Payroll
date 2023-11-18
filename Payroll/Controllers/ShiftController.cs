using System.Web.Mvc;
using Payroll.Helpers;

namespace Payroll.Controllers {
    public class ShiftController : Controller {
        readonly ControllerHelper helper;

        public ShiftController() {
            helper = new ControllerHelper(this);
        }

        [HttpGet]
        public ActionResult Index() => this.HandleDefaultPipeline("shift:Index");

        [HttpPost]
        public ActionResult Create() => this.HandleDefaultPipeline("shift:Create");

        [HttpPost]
        public ActionResult Edit() => this.HandleDefaultPipeline("shift:Edit");

        [HttpPost]
        public ActionResult Delete() => this.HandleDefaultPipeline("shift:Delete");


    }
}
