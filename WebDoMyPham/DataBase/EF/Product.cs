namespace WebDoMyPham.DataBase.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [Key]
        [DisplayName("Mã SP")]
        public int ProductID { get; set; }

        [StringLength(100)]
        [DisplayName("Tên Sản Phẩm")]
        public string ProductName { get; set; }

        [DisplayName("Tên Loại")]
        public int? CategoryID { get; set; }

        [DisplayName("Ảnh Đại Diện")]
        [StringLength(500)]
        public string Image { get; set; }

        [DisplayName("Đơn Giá")]
        public decimal? Price { get; set; }

        [DisplayName("Đơn Vị")]
        [StringLength(20)]
        public string Measure { get; set; }

        [DisplayName("Mô Tả")]
        [StringLength(500)]
        public string Description { get; set; }

        [DisplayName("Nội Dung")]
        public string Content { get; set; }

        [DisplayName("Số Lượng")]
        public int? Quantity { get; set; }

        [DisplayName("Trạng Thái")]
        public bool Status { get; set; }

        [DisplayName("Hiện Thị Trang Chủ")]
        public bool ShowHome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailBill> DetailBills { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
