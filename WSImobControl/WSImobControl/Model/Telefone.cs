using System.ComponentModel.DataAnnotations;

namespace WSImobControl.Model
{
    public class Telefone
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Número é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Proprietário é obrigatório")]
        public Guid ProprietarioId { get; set; }

        public Proprietario Proprietario { get; set; }

    }
}