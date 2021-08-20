using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEAP.Models
{
    [Table("VEI004_MODELO_VERSAO")]
    public class ModeloVersao
    {
        [Key]
        public int IdeModeloVersao { get; set; }
        public int IdeModelo { get; set; }
        public Modelo Modelo { get; set; }
        public byte IdeCombustivel { get; set; }
        public Int16 NroAno { get; set; }
        public decimal VlrPrecoTabelado { get; set; }
    }
}