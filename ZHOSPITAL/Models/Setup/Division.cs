using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("Divisions")]
    public class Division
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string DivisionName { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }
    }
}
