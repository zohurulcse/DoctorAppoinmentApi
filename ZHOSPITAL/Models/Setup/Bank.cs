
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("Banks")]
    public class Bank
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(20)]
        public string RoutingNumber { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

    }
}
