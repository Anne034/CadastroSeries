using System;
using CadastroSeries.Models;
using CadastroSeries.Servicos;

namespace CadastroSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            SeriesServico servico = new SeriesServico();
            bool rodando = true;

            while (rodando)
            {
                string opcao = ObterOpcao();
                switch (opcao)
                {
                    case "1":
                        servico.Listar();
                        break;
                    case "2":
                        servico.Inserir();
                        break;
                    case "3":
                        servico.Atualizar();
                        break;
                    case "4":
                        servico.Excluir();
                        break;
                    case "5":
                        servico.Visualizar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        rodando = false;
                        Console.WriteLine("Obrigado por usar o programa!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente!");
                        break;
                }
            }

        }

        private static string ObterOpcao()
        {
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            Console.Write(">");
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}