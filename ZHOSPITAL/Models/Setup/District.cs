using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("Districts")]
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string DistrictName { get; set; }

        [StringLength(15)]
        public int DivisionID { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }
    }
}
