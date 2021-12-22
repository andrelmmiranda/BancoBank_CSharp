using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {

        static List<Conta> listaDeContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar o nosso serviço.");
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(listaDeContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            
            for(int i = 0; i < listaDeContas.Count; i++)
            {
                Conta conta = listaDeContas[i];
                Console.WriteLine("#{0} - {1}", i , conta);
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(nome: entradaNome, tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito);

            listaDeContas.Add(novaConta);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaDeContas[indiceContaOrigem].Transferir(valorTransferencia, listaDeContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaDeContas[indiceConta].Sacar(valorSaque);
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaDeContas[indiceConta].Depositar(valorDeposito);
        }


    private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Banco Bank ao seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }

    }
}
