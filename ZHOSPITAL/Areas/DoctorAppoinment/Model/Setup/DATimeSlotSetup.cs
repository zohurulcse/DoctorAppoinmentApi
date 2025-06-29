using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Common
{
    [Table("DATimeSlotSetup")]
    public class DATimeSlotSetup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 TimeSlotID { get; set; }

        public int DoctorID { get; set; }

        [StringLength(20)]
        public string ScheduleDate { get; set; }

        [StringLength(10)]
        public string ScheduleTime { get; set; }      

        [StringLength(100)]
        public string Remarks { get; set; }
     
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
