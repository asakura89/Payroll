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
    
    public partial class T_ADDITIONAL_PAYMENT
    {
        public string ADDITIONAL_ID { get; set; }
        public string PAYMENT_ID { get; set; }
        public string RATE_ID { get; set; }
        public string NOTE { get; set; }
        public Nullable<bool> IS_APPROVED { get; set; }
    
        public virtual M_RATES M_RATES { get; set; }
    }
}
