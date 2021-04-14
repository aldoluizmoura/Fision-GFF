using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoFluxoFinanceiro.Aplicacao.ViewModels.Acesso
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DisplayName("Antiga senha")]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }


        [Required]
        [DisplayName("Nova senha")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

    }
}
