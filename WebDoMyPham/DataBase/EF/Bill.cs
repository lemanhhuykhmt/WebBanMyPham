namespace WebDoMyPham.DataBase.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            DetailBills = new HashSet<DetailBill>();
        }

        public int BillID { get; set; }

        public int? CustomerID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string Receiver { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailBill> DetailBills { get; set; }
    }
}
