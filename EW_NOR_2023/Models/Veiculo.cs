using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EW_NOR_2023.Models
{
    public class Veiculo
    {
        [Key]
        public string Matricula { get; set; }
        
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int ProprietarioId { get; set; }

        public Proprietario? Proprietario { get; set; }
    }
}
