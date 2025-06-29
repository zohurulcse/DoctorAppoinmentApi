using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("Thanas")]
    public class Thana
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string ThanaName { get; set; }

        [StringLength(15)]
        public int DistrictID { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }
    }
}
