﻿using AplicacaoDeTransferenciaBancaria.Classes;
using AplicacaoDeTransferenciaBancaria.Enum;
using System;
using System.Collections.Generic;

namespace AplicacaoDeTransferenciaBancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

		static void Main(string[] args)
        {
            //Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "User teste");
            string opcaoSelecionada = MenuOpcoes();

            while (opcaoSelecionada != "X")
            {
                switch (opcaoSelecionada)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoSelecionada = MenuOpcoes();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();

        }

        private static string MenuOpcoes()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor !");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoSelecionada = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoSelecionada;
        }

        private static void InserirConta()
        {

            Console.WriteLine();

            Console.WriteLine("Inserir nova conta: ");

            Console.WriteLine();

            Console.WriteLine("Insira o tipo da conta sendo 1 - Pessoa Fisica e 2 - Pessoa Juridica: ");
            int tipoContaNova = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Insira o saldo da conta: ");
            double saldoContaNova = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Insita o credito da conta: ");
            double creditoContaNova = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Insira o nome da conta: ");
            string nomeContaNova = Console.ReadLine();
            Console.WriteLine();

            Conta novaConta = new Conta((TipoConta)tipoContaNova, saldoContaNova, creditoContaNova, nomeContaNova);

            listaContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine();
            Console.WriteLine("Listar contas: ");

            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada !");
                return;
            }

            for (var i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.WriteLine("#{0} - {1}", i, conta.ToString());
            }
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            
            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[numeroConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.WriteLine();
            Console.WriteLine("Insira o numero da conta de origem: ");
            int numeroContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor que deseja transferir: ");
            double valor = double.Parse(Console.ReadLine());

            Console.WriteLine("Insira o numero da conta para a qual deseja realizar a transferencia: ");
            int numeroContaDestino = int.Parse(Console.ReadLine());

            listaContas[numeroContaOrigem].Transferir(valor, listaContas[numeroContaDestino]);
        }

        public static void Depositar()
        {
            Console.WriteLine("Insira o numero da conta na qual deseja realizar o depósito: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor que deseja depositar: ");
            double valor = double.Parse(Console.ReadLine());

            listaContas[numeroConta].Depositar(valor);
        }
    }
}
