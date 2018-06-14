namespace WebDoMyPham.DataBase.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            DetailBills = new HashSet<DetailBill>();
        }

        public int ProductID { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        public decimal? Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string Content { get; set; }

        public int? Quantity { get; set; }

        public bool? Status { get; set; }

        public bool? ShowHome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailBill> DetailBills { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
