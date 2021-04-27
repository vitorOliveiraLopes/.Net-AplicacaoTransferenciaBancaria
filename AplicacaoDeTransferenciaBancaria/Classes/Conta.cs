using AplicacaoDeTransferenciaBancaria.Enum;
using System;

namespace AplicacaoDeTransferenciaBancaria.Classes
{
    public class Conta
    {
		// Atributos
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private string Nome { get; set; }
		public string[] ChavesPix { get; set; }

		//Construtor
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome, string[] chavesPix)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
			this.ChavesPix = chavesPix;
		}

		//Métodos
		public bool Sacar(double valorSaque)
		{
			// Validação de saldo suficiente
			if (this.Saldo - valorSaque < (this.Credito * -1))
			{
				Console.WriteLine("Saldo insuficiente!");
				return false;
			}
			this.Saldo -= valorSaque;

			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

			return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia))
			{
				contaDestino.Depositar(valorTransferencia);
			}
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += "TipoConta: " + this.TipoConta + " | ";
			retorno += "Nome: " + this.Nome + " | ";
			retorno += "Saldo: " + this.Saldo + " | ";
			retorno += "Crédito: " + this.Credito + " | ";
			retorno += "Chaves PIX: ";

            foreach (var data in ChavesPix)
            {
				retorno += data + " | ";
            }

            return retorno;
		}
	}
}
