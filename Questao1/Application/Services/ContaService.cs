
using Domain.Entities;

namespace Application.Services;

public class ContaService
{
    public string ObterResumoConta(ContaBancaria conta)
    {
        return $"Conta {conta.Numero}, Titular: {conta.Titular}, Saldo: $ {conta.Saldo:F2}";
    }
}
