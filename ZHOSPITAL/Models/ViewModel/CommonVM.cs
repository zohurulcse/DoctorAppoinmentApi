using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.ViewModel
{
    public class CommonVM
    {
        [StringLength(20)]
        public string RegistrationCode { get; set; }

        [StringLength(50)]
        public string RegistrationName { get; set; }

        [StringLength(50)]
        public string RegistrationTypeName { get; set; }
        public DateTime? RegistrationDate { get; set; }

        [StringLength(20)]
        public string OperatorCode { get; set; }

        [StringLength(50)]
        public string OperatorName { get; set; }

        [StringLength(20)]
        public string ShopCode { get; set; }

        [StringLength(50)]
        public string ShopName { get; set; }

        [StringLength(20)]
        public string CustomerCode { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string ShopKeeperName { get; set; }

        [StringLength(20)]
        public string RoleName { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        [StringLength(100)]
        public string ContactNo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string PresendAddress { get; set; }

        [StringLength(500)]
        public string PermanantAddress { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }
        public string Photo { get; set; }

        [StringLength(20)]
        public string DivisionCode { get; set; }

        [StringLength(50)]
        public string DivisionName { get; set; }

        [StringLength(20)]
        public string DistrictCode { get; set; }

        [StringLength(50)]
        public string DistrictName { get; set; }

        [StringLength(20)]
        public string ThanaCode { get; set; }

        [StringLength(50)]
        public string ThanaName { get; set; }

        [StringLength(20)]
        public string BazarCode { get; set; }

        [StringLength(50)]
        public string BazarName { get; set; }
    }
}
