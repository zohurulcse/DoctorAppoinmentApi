using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Common
{
    [Table("DADoctorAppoinment")]
    public class DADoctorAppoinment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordID { get; set; }

        public int DoctorID { get; set; }   
        public string AppoinmentDate { get; set; }
        public string AppoinmentTime { get; set; }     
        public int UserID { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string PatientName { get; set; }

        [StringLength(10)]
        public string AgeType { get; set; }
        public int Age { get; set; }

        [StringLength(15)]
        public string Gender { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
