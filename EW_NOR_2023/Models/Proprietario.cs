using System.ComponentModel.DataAnnotations;

namespace EW_NOR_2023.Models
{
    public class Proprietario
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 5, ErrorMessage = "Tem de ter o tamanho certo")]
        public string Nome { get; set; }

        public string Nacionalidade { get; set; }

        public virtual IEnumerable<Veiculo> Veiculos { get; set; }
    }
}
