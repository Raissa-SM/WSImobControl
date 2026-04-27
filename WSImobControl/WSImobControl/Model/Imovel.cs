using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSImobControl.Model
{
    public class Imovel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [StringLength(200, MinimumLength = 10
                     , ErrorMessage = "Título deve ter de 10 a 200 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        public Status Status { get; set; }

        public Guid? ProprietarioId { get; set; }

        public Proprietario Proprietario { get; set; }
    }
}