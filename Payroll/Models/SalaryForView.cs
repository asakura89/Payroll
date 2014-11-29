using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Payroll.Services;

namespace Payroll.Models
{
    public class SalaryForView
    {
        public M_EMP_SALARY Salary { get; set; }

        public SelectList UserList { get; private set; }

        public SalaryForView(M_EMP_SALARY salary)
        {
            Salary = salary;
            
            var service = new UserService();
            UserList = new SelectList(service.GetAllUsers(), "USERNAME", "USERNAME", Salary.USERNAME);
        }

        public SalaryForView() : this(new M_EMP_SALARY()) { }
    }
}