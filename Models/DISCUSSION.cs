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
    
    public partial class DISCUSSION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISCUSSION()
        {
            this.FEEDBACKs = new HashSet<FEEDBACK>();
        }
    
        public long ID { get; set; }
        public string Advertisement_Code { get; set; }
        public System.DateTime MeetingDate { get; set; }
        public string Details { get; set; }
    
        public virtual ADVERTISEMENT ADVERTISEMENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEEDBACK> FEEDBACKs { get; set; }
    }
}
