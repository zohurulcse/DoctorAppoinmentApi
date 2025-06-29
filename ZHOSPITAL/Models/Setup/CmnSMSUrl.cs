using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("CmnSMSUrl")]
    public class CmnSMSUrl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 ID { get; set; }

        [StringLength(200)]
        public string URL { get; set; }

        [StringLength(5)]
        public string CountryCode { get; set; }       
        public bool IsActive { get; set; }
        public int ShopID { get; set; }
    }
}
