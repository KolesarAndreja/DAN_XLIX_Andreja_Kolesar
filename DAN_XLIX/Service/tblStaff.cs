//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAN_XLIX.Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblStaff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblStaff()
        {
            this.tblAbsences = new HashSet<tblAbsence>();
        }
    
        public int staffId { get; set; }
        public string citizenship { get; set; }
        public Nullable<decimal> salary { get; set; }
        public int floorNumber { get; set; }
        public Nullable<int> engegamentId { get; set; }
        public Nullable<int> genderId { get; set; }
        public Nullable<int> userId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAbsence> tblAbsences { get; set; }
        public virtual tblEngagement tblEngagement { get; set; }
        public virtual tblGender tblGender { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
