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
    
    public partial class REQUEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REQUEST()
        {
            this.CAMPAIGNs = new HashSet<CAMPAIGN>();
        }
    
        public long Id { get; set; }
        public string Description { get; set; }
        public string Industry_code { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }
        public decimal Budget { get; set; }
        public string Company_Code { get; set; }
        public string Age_code { get; set; }
        public string Region_Code { get; set; }
    
        public virtual AGE_TYPE AGE_TYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAMPAIGN> CAMPAIGNs { get; set; }
        public virtual COMPANY COMPANY { get; set; }
        public virtual INDUSTRY_TYPE INDUSTRY_TYPE { get; set; }
        public virtual REGION_TYPE REGION_TYPE { get; set; }
    }
}
