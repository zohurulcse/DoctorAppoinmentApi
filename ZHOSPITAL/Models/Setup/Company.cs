using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("Companys")]
    [Index(nameof(ContactNo), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]       
        public string CustomCode { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(15)]
        [Required]
        public string ContactNo { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [StringLength(150)]
        [Required]
        public string Address { get; set; }

        [StringLength(70)]
        public string Logo { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }
    }
}
