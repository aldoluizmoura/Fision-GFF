using FluentValidation;

namespace GestaoFluxoFinanceiro.Negocio.Models.Validations
{
    public class ContratoFinanceiroProfissionalValidation : AbstractValidator<ContratoFinanceiroProfissional>
    {
        public ContratoFinanceiroProfissionalValidation()
        {
            RuleFor(c => c.ValorUnitario)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.MargemLucro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}