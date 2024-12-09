using System.ComponentModel.DataAnnotations;

namespace EW_NOR_2024.Models
{
    public class RegistoUtilizador
    {
        [Key]
        public int RegistoId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage ="O nome nome tem de ter máximo de 200 chars")]
        public string Nome { get; set; }

        [Required]
        [RegularExpression("(Ordinário|Especial|Super)", ErrorMessage ="Apenas pode usar os valores Ordinário, Especial ou Super")]
        public string Regime { get; set; } = "Ordinário";

        public bool Valido {  get; set; } = false;
    }
}
