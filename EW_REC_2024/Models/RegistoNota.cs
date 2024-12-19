using System.ComponentModel.DataAnnotations;

namespace EW_REC_2024.Models
{
    public class RegistoNota
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Campo obrigatório")] // valor único verifica-se no controller
        [Display(Name = "Número")]
        public int NumAluno { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0,20, ErrorMessage = "Nota tem de ter valor entre 0 e 20")]
        public int Nota { get; set; }

        [Display(Name ="Utilizador")]
        public string? ALxxxxx { get; set; } 
    }
}
