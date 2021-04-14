using FluentValidation;

namespace GestaoFluxoFinanceiro.Negocio.Models.Validations
{
    public class ContratoFinanceiroAlunoValidation : AbstractValidator<ContratoFinanceiroAluno>
    {
        public ContratoFinanceiroAlunoValidation()
        {
            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}