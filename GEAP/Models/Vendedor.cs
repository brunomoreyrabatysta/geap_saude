using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEAP.Models
{
    [Table("VND001_VENDEDOR")]
    public class Vendedor
    {
        [Key]
        public int IdeVendedor { get; set; }
        public string NmeVendedor { get; set; }
    }
}