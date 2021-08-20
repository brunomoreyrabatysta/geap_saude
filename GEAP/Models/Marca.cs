using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEAP.Models
{
    [Table("VEI001_MARCA")]
    public class Marca
    {
        [Key]
        public int IdeMarca { get; set; }
        public string NmeMarca { get; set; }
    }
}