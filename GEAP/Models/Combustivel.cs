
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEAP.Models
{
    [Table("VEI003_COMBUSTIVEL")]
    public class Combustivel
    {
        [Key]
        public byte IdeCombustivel { get; set; }
        public string NmeCombustivel { get; set; }
    }
}