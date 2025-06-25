
namespace Domain.Entities;

public class ContaBancaria
{
    public int Numero { get; }
    public string Titular { get; private set; }
    public double Saldo { get; private set; }

    private const double TaxaSaque = 3.50;

    public ContaBancaria(int numero, string titular, double depositoInicial = 0)
    {
        Numero = numero;
        Titular = titular;
        Saldo = depositoInicial;
    }

    public void Deposito(double valor) => Saldo += valor;

    public void Saque(double valor) => Saldo -= valor + TaxaSaque;

    public void AlterarTitular(string novoTitular) => Titular = novoTitular;
}
