//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Payroll.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class m_User
    {
        public m_User()
        {
            this.d_AdditionalSalary = new HashSet<d_AdditionalSalary>();
            this.d_DayOff = new HashSet<d_DayOff>();
            this.d_Payment = new HashSet<d_Payment>();
            this.d_Salary = new HashSet<d_Salary>();
        }
    
        public string Username { get; set; }
        public string Password { get; set; }
        public string Category { get; set; }
    
        public virtual ICollection<d_AdditionalSalary> d_AdditionalSalary { get; set; }
        public virtual ICollection<d_DayOff> d_DayOff { get; set; }
        public virtual ICollection<d_Payment> d_Payment { get; set; }
        public virtual ICollection<d_Salary> d_Salary { get; set; }
    }
}