//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace library_system.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class author_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public author_details()
        {
            this.master_book_information = new HashSet<master_book_information>();
        }
    
        public int id { get; set; }
        public string author_name { get; set; }
        public Nullable<int> register_number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<master_book_information> master_book_information { get; set; }
    }
}