using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEAP.Models
{
    [Table("VND002_VENDA")]
    public class Venda
    {
        [Key] 
        public int IdeVenda { get; set; }
        public int IdeVendedor { get; set; }
        public Vendedor Vendedor { get; set; }
        public int IdeModeloVersao { get; set; }
        public ModeloVersao ModeloVersao { get; set; }
        public decimal VlrPrecoVenda { get; set; }
        public bool StaValeCombustivel { get; set; }
    }
}