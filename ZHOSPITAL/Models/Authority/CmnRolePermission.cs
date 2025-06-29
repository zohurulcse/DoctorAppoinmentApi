using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Authority
{
    [Table("CmnRolePermissions")]
    public class CmnRolePermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MenuID { get; set; }

        [StringLength(50)]
        public string ApiUrl { get; set; }

        [StringLength(5)]
        public string ApiMethod { get; set; }
        public bool IsAdd { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsView { get; set; }
        public bool IsDelete { get; set; }
        public int RoleID { get; set; }
        public int ShopID { get; set; }
        public int UserID { get; set; }

        [StringLength(8)]
        public string Status { get; set; }
    }
}
