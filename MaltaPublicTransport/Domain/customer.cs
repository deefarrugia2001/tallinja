//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {
        public System.Guid customer_id { get; set; }
        public int customer_number { get; set; }
    
        public virtual customers_balance customers_balance { get; set; }
    }
}
