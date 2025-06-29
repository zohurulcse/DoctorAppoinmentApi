using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Common
{
    [Table("DAAssociateType")]
    public class DAAssociateType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 AssociateTypeID { get; set; }

        [StringLength(50)]
        public string AssociateType { get; set; }

        [StringLength(100)]
        public string AssociateDescription { get; set; }

    }
}
