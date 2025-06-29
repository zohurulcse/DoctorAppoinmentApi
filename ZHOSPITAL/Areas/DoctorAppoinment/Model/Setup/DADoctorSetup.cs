using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Common
{
    [Table("DADoctorSetup")]
    public class DADoctorSetup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorID { get; set; }

        public int DepartmentID { get; set; }
        public int AssociateTypeID { get; set; }

        [StringLength(50)]
        public string DoctorName { get; set; }

        [StringLength(100)]
        public string DoctorTitle { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
        public bool IsImagePath { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageByte { get; set; }

        [StringLength(300)]
        public string DoctorAddress { get; set; }

        [StringLength(100)]
        public string Organigation { get; set; }

        public string DoctorDescription { get; set; }

        [NotMapped]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        [NotMapped]
        [StringLength(50)]
        public string AssociateName { get; set; }

        [NotMapped]       
        public string ScheduleDate { get; set; }

        [NotMapped]
        public string ScheduleTime { get; set; }
        [NotMapped]
        public string ID { get; set; }

        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpBy { get; set; }
        public DateTime UpdateDate { get; set; }

        [NotMapped]
        public virtual List<DATimeSlotSetup> DATimeSlotList { get; set; }

    }
}
