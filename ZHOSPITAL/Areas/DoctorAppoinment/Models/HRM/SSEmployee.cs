using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.VarietiesStore.Models.HRM
{
    [Table("SSEmployees")]
    [Index(nameof(ContactNo), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class SSEmployee
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name = "Date of Birth")]
        public DateTime DateofBirth { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Contact No")]
        //[Remote("IsContactNoExist", "Employee", AdditionalFields = "Code", ErrorMessage = "Contact No already exists !")]
        public string ContactNo { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Father's Name")]
        public string FathersName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Mother's Name")]
        public string MothersName { get; set; }

        [StringLength(500)]
        [Required]
        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [StringLength(500)]
        [Required]
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }

        [StringLength(50)]
        //[Remote("IsEmailExist", "Employee", AdditionalFields = "Code", ErrorMessage = "Email already exists !")]
        public string Email { get; set; }

        [StringLength(20)]
        //[Remote("IsNIdExist", "Employee", AdditionalFields = "Code", ErrorMessage = "The NID is already exist !")]
        [Display(Name = "NID")]
        public string NationalId { get; set; }

        [StringLength(20)]
        //[Remote("IsBirthCertificateExist", "Employee", AdditionalFields = "Code", ErrorMessage = "The Birth Certificate is already exist !")]
        [Display(Name = "Birth Certificate")]
        public string BirthCertificateNo { get; set; }

        [StringLength(15)]
        [Required]
        public string DepartmentCode { get; set; }
        [ForeignKey("DepartmentCode")]
        public virtual VSDepartment Department { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Department")]
        public string DesignationCode { get; set; }
        [ForeignKey("DesignationCode")]
        [Display(Name = "Designation")]
        public virtual VSDesignation Designation { get; set; }

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

        [StringLength(15)]
        [Required]
        public string BranchCode { get; set; }
        [ForeignKey("BranchCode")]
        public virtual Branch Branch { get; set; }
    }
}

