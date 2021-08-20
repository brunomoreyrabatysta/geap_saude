using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEAP.Models
{
    [Table("VEI002_MODELO")]
    public class Modelo
    {
        [Key]
        public int IdeModelo { get; set; }
        public int IdeMarca { get; set; }
        public Marca Marca { get; set; }
        public string CodModelo { get; set; }
        public string NmeModelo { get; set; }
    }
}