//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdvtManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FEEDBACK
    {
        public long ID { get; set; }
        public long Discussion_id { get; set; }
        public string Details { get; set; }
        public bool Incorporated { get; set; }
    
        public virtual DISCUSSION DISCUSSION { get; set; }
    }
}
