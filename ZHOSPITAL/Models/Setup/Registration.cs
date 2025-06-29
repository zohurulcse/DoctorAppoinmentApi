using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("Registrations")]
    public class Registration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]      
        public string CustomCode { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        [Required]
        public string Contact { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        [Required]
        public string PresendAddress { get; set; }

        [StringLength(500)]
        [Required]
        public string PermanantAddress { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        public Int16 DivisionID { get; set; }

        public Int16 DistrictID { get; set; }

        public Int16 ThanaID { get; set; }

        public Int16 BazarID { get; set; }
        
        [Required]
        public int UserID { get; set; }
        public int RegistrationTypeID { get; set; }

        [StringLength(50)]
        public string RegistrationType { get; set; }

        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? DateofBirth { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }
      
        public int BazarOperatorID { get; set; }

        [Required]
        public int ShopID { get; set; }
       
        public string ShopTypeID { get; set; }

        [StringLength(50)]
        public string ShopName { get; set; }
      
        public int CustomerID { get; set; }
        
        public int DeliveryManID { get; set; }

    }
}
