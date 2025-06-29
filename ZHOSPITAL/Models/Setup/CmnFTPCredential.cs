using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("CmnFTPCredential")]
    public class CmnFTPCredential
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 ID { get; set; }

        [StringLength(50)]
        public string HostIP { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
        public Int16 Port { get; set; }
        public bool IsActive { get; set; }
        public int ShopID { get; set; }
    }
}
