using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("RegistrationTypes")]
    public class RegistrationType
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string RegistrationTypeName { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

    }
}
