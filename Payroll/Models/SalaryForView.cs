using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Payroll.Services;

namespace Payroll.Models
{
    public class SalaryForView
    {
        public d_Salary Salary { get; set; }

        public SelectList UserList { get; private set; }

        public SalaryForView(d_Salary salary)
        {
            Salary = salary;
            
            var service = new UserService();
            UserList = new SelectList(service.GetAllUsers(), "Username", "Username", Salary.Username);
        }

        public SalaryForView() : this(new d_Salary()) { }
    }
}