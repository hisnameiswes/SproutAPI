using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SproutNet.Models
{
    public class Fruit
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Type { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string SubType { get; set; }

    }
}
