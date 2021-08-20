using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEAP.Models
{
    public class Relatorio
    {
        public int IdeVendedor { get; set; }
        public string NmeVendedor { get; set; }
        public int QuantidadeVeiculos { get; set; }
        public int QuantidadeValeCombustivel { get; set; }
        public decimal TotalVenda { get; set; }
        public decimal TotalComissao { get; set; }
    }
}