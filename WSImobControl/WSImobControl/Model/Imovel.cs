using System.ComponentModel.DataAnnotations;

namespace WSImobControl.Model
{
    public class Imovel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(200,MinimumLength = 10,ErrorMessage = "Título deve ter entre 10 e 200 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public Status Status { get; set; }

    }
}
