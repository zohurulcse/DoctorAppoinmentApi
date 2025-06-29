using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Authority
{
    [Table("CmnPermission")]
    public class CmnPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 ID { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(10)]
        public string Type { get; set; } 
        public int ParentID { get; set; }

        [StringLength(50)]
        public string UrlType { get; set; }

        [StringLength(50)]
        public string ApiUrl { get; set; }

        [StringLength(5)]
        public string ApiMethod { get; set; }

        [StringLength(50)]
        public string AnuglarUrl { get; set; }  

        public int ModuleID { get; set; }  
        public bool IsAdd { get; set; }  
        public bool IsUpdate { get; set; }  
        public bool IsView { get; set; }
        public bool IsDelete { get; set; }
        public int SLNo { get; set; }
        public int RoleID { get; set; }
        public int ShopID { get; set; }
        public int UserID { get; set; }

        [StringLength(8)]
        public string Status { get; set; }

    }
}
