using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
   [Table("SSProductClosePrice")]
   public class SSProductClosePrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [StringLength(20)]
        public string ProductCode { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        public decimal? CurrentStock { get; set; }

        public decimal? ProductLastPrice { get; set; }

        public decimal? LastCostPrice { get; set; }

        [StringLength(20)]
        public string ShopCode { get; set; }

        [StringLength(100)]
        public string ProductPhoto { get; set; }

        public int? ReOrderLevel { get; set; }

        [StringLength(10)]
        public string Status { get; set; }
    }
}
