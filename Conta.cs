public class Conta
{
    public int Codigo { get; }
    public double Saldo { get; private set; }

    public Conta(int codigo)
    {
        Codigo = codigo;
        Saldo = 0.0;
    }

    private void ValidarValor(double valor)
    {
        if(valor <= 0.0) throw new ArgumentException("O valor deve ser maior que 0.0");
    }

    public void Sacar(double valor)
    {
        ValidarValor(valor);
        if(valor > Saldo)
        {
            throw new ArgumentException("Valor indisponível na conta!");
        }

        Saldo -= valor;
    }

    public void Depositar(double valor)
    {
        ValidarValor(valor);
        Saldo += valor;
    }

    public void Transferir(double valor, Conta conta)
    {
        Sacar(valor);
        conta.Depositar(valor);
    }
}