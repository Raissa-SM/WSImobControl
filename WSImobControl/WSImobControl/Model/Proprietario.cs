using System.ComponentModel.DataAnnotations;

namespace WSImobControl.Model
{
    public class Proprietario
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength = 4,ErrorMessage = "NOme deve ter de 4 a 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
