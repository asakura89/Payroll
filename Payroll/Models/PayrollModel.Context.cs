﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PayrollEntities : DbContext
    {
        public PayrollEntities()
            : base("name=PayrollEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<d_AdditionalSalary> d_AdditionalSalary { get; set; }
        public DbSet<d_DayOff> d_DayOff { get; set; }
        public DbSet<d_Payment> d_Payment { get; set; }
        public DbSet<d_Salary> d_Salary { get; set; }
        public DbSet<m_Rate> m_Rate { get; set; }
        public DbSet<m_User> m_User { get; set; }
    }
}
