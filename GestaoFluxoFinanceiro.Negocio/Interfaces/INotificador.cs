using GestaoFluxoFinanceiro.Negocio.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFluxoFinanceiro.Negocio.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
