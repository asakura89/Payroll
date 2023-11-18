using System.Linq;
using System.Web.Mvc;
using Payroll.Services;

namespace Payroll.Models {
    public class SalaryForView {
        public d_Salary Salary { get; private set; }

        public SelectList UserList { get; private set; }

        public SalaryForView(d_Salary salary) {
            Salary = salary;

            var service = new UserService();
            UserList = new SelectList(service.GetAllUsers().Where(user => user.Category != "1"), "Username", "Username", Salary.Username);
        }

        public SalaryForView() : this(new d_Salary()) { }
    }
}