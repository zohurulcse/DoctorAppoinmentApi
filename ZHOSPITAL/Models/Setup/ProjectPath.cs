using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Models.Setup
{
    [Table("ProjectPaths")]
    public class ProjectPath
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        public string Path { get; set; }

    }
}
