using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Authority
{
    [Table("CmnMenus")]
    public class CmnMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(15)]
        [Required]
        public string Type { get; set; }
      
        public int ParentID { get; set; }

        [StringLength(150)]
        [Display(Name = "Page Url")]
        public string Url { get; set; }

        [StringLength(50)]
        [Required]
        public string Module { get; set; }

        [Display(Name = "Serial No.")]
        public int SLNO { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        [StringLength(20)]
        public int UserID { get; set; }

        [Required]
        public int ShopID { get; set; }

    }
}
