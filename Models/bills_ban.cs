//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTS_api.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class bills_ban
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bills_ban()
        {
            this.bill_detail_ban = new HashSet<bill_detail_ban>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_kh { get; set; }
        public Nullable<System.DateTime> date_order { get; set; }
        public Nullable<double> tong_tien { get; set; }
        public string payment { get; set; }
        public string status { get; set; }
        public string note { get; set; }
        [JsonIgnore]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill_detail_ban> bill_detail_ban { get; set; }
        [JsonIgnore]
        public virtual khach_hang khach_hang { get; set; }
    }
}