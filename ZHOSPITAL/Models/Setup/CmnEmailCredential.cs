using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("CmnEmailCredential")]
    public class CmnEmailCredential
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 ID { get; set; }

        [StringLength(50)]
        public string MailFrom { get; set; }

        [StringLength(50)]
        public string MailCC { get; set; }

        [StringLength(50)]
        public string MailBCC { get; set; }

        [StringLength(50)]
        public string MailSubject { get; set; }
        
        public string MessageDetails { get; set; }

        [StringLength(50)]
        public string SmtpHost { get; set; }

        [StringLength(50)]
        public string SmtpCredentials { get; set; }

        public Int16 SmtpPort { get; set; }

        [DefaultValue(1)]
        public bool IsActive { get; set; }

        [StringLength(50)]
        public string Passwords { get; set; }

        [DefaultValue(0)]
        public bool EnableSsl { get; set; }

        [DefaultValue(0)]
        public bool IsDefaultCredentials { get; set; }

        [DefaultValue(0)]
        public bool IsSecurityProtocol { get; set; }

        public int ShopID { get; set; }
    }
}
