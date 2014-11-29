using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Payroll.Models
{
    public class RateForView
    {
        public M_RATES Rate { get; set; }
        public List<SelectListItem> RateTypeDescList { get; private set; }

        public RateForView(M_RATES rate)
        {
            Rate = rate;
            RateTypeDescList = new List<SelectListItem>();

            var item = new SelectListItem { Text = String.Empty, Value = String.Empty };
            RateTypeDescList.Add(item);

            item = new SelectListItem { Text = "Normal", Value = "1" };
            RateTypeDescList.Add(item);

            item = new SelectListItem { Text = "Percentage", Value = "2" };
            RateTypeDescList.Add(item);
        }

        public RateForView() : this(new M_RATES()) { }
    }
}