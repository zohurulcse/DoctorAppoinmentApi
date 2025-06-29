using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.HRM
{
    [Table("PhEmployees")]
    [Index(nameof(ContactNo), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class PhEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]       
        public DateTime DateofBirth { get; set; }

        [StringLength(100)]
        [Required]       
        public string ContactNo { get; set; }

        [Required]
        [StringLength(30)]       
        public string FathersName { get; set; }

        [Required]
        [StringLength(30)]        
        public string MothersName { get; set; }

        [StringLength(500)]
        [Required]     
        public string PresentAddress { get; set; }

        [StringLength(500)]
        [Required]        
        public string PermanentAddress { get; set; }

        [StringLength(50)]       
        public string Email { get; set; }

        [StringLength(20)]       
        public string NationalId { get; set; }

        [StringLength(20)]       
        public string BirthCertificateNo { get; set; }
               
        public Int16 DepartmentID { get; set; }        
       
        public Int16 DesignationID { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name = "Joining Date")]
        public DateTime JoinDate { get; set; }

        public decimal Salary { get; set; }

        [StringLength(70)]
        public string Photo { get; set; }

        [StringLength(8)]
        [Required]
        public string Status { get; set; }        
        public Int16 BranchID { get; set; }

        [Required]
        public int ShopID { get; set; }

    }
}

