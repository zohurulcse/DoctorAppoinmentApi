using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("Branchs")]
    [Index(nameof(MobileNumber), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }       

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Contact No")]
        public string MobileNumber { get; set; }

        [StringLength(50)]       
        public string Email { get; set; }

        [StringLength(150)]
        [Required]
        public string Address { get; set; }

        [StringLength(70)]
        public string Logo { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Shop")]
        public string ShopID { get; set; }
    }
}
