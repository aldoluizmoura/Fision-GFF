using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels.Acesso
{
    public class RegisterViewModel
    {
        [DisplayName("Usuário")]
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public string User { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não combinam.")]
        public string ConfirmPassword { get; set; }
    }
}
