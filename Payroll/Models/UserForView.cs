using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Payroll.Models {
    public class UserForView {
        public m_User User { get; private set; }
        public String OldPassword { get; set; }
        public String ConfirmOldPassword { get; set; }
        public String NewPassword { get; set; }
        public List<SelectListItem> UserCategoryDescList { get; private set; }

        public UserForView(m_User user) {
            User = user;
            OldPassword = ConfirmOldPassword = NewPassword = String.Empty;
            UserCategoryDescList = new List<SelectListItem>();

            var item = new SelectListItem { Text = String.Empty, Value = String.Empty };
            UserCategoryDescList.Add(item);

            item = new SelectListItem { Text = "Admin", Value = "1" };
            UserCategoryDescList.Add(item);

            item = new SelectListItem { Text = "Manager", Value = "2" };
            UserCategoryDescList.Add(item);
        }

        public UserForView() : this(new m_User()) { }
    }
}