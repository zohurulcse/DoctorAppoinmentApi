using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup
{
    [Table("PhProducts")]
    public class PhProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [StringLength(500)]
        [Required]
        public string Name { get; set; }
       
        [Required]
        public Int16 CategoryID { get; set; }

        [StringLength(20)]
        [NotMapped]
        public string CategoryName { get; set; }

        public Int16 SubCategoryID { get; set; }

        [StringLength(20)]
        [NotMapped]
        public string SubCategoryName { get; set; }

        public Int16 BrandID { get; set; }

        [StringLength(20)]
        [NotMapped]
        public string BrandName { get; set; }

        public Int16 StyleID { get; set; }

        [StringLength(20)]
        [NotMapped]
        public string StyleName { get; set; }

        public Int16 SizeID { get; set; }

        [StringLength(10)]
        [NotMapped]
        public string SizeName { get; set; }
        public Int16 ColorID { get; set; }

        [StringLength(20)]
        [NotMapped]
        public string ColorName { get; set; }
        public Int16 UnitID { get; set; }

        [StringLength(10)]
        [NotMapped]
        public string UnitName { get; set; }

        [StringLength(70)]
        public string Photo { get; set; }

        public byte[] PhotoByte { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }
      
        public int? ReOrderLevel { get; set; }

        [Display(Name = "Current Stock")]
        [DefaultValue(0)]
        public decimal? CurrentStock { get; set; }

        [Display(Name = "Cost Price")]
        [DefaultValue(0.00)]
        public decimal? CostPrice { get; set; }

        [Display(Name = "Sale Price")]
        [DefaultValue(0.00)]
        public decimal? SalePrice { get; set; }

        [Display(Name = "VAT")]
        [DefaultValue(0.00)]
        public decimal VAT { get; set; }

        [Display(Name = "TAX")]
        [DefaultValue(0.00)]
        public decimal TAX { get; set; }
          
        public int SupplierID { get; set; }              
        public Int16 ShopTypeID { get; set; }
       
        public Int16 DivisionID { get; set; }
        
        public Int16 DistrictID { get; set; }       
        public Int16 ThanaCode { get; set; }       
        public Int16 BazarID { get; set; }

        [StringLength(29)]
        public string SKU { get; set; }

        public bool? IsOnline { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }
      
        [Required]        
        public int ShopID { get; set; }

        [Required]
        public int InBy { get; set; }

        [StringLength(50)]
        public string InPC { get; set; }
        public int UpBy { get; set; }

        [StringLength(50)]
        public string UpPC { get; set; }

        [NotMapped]
        public IFormFile profileFile { get; set; }

    }
}
