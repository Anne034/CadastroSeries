using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroSeries.Models;
using CadastroSeries.Repositorios;

namespace CadastroSeries.Servicos
{
    public class SeriesServico
    {
        private IRepositorio<Serie> _repositorio;

        public SeriesServico()
        {
            _repositorio = new SeriesRepositorios();
        }

        public void Listar()
        {
            foreach (var serie in _repositorio.Listar())
            {
                Console.WriteLine(serie);
                Console.WriteLine("------------------------------");
            }
        }

        public void Inserir()
        {
            Serie serie = new Serie();
            Console.WriteLine("Por favor, digite o título da série:");
            Console.Write(">");
            serie.Titulo = Console.ReadLine();

            Console.WriteLine("Por favor, digite a descrição da série:");
            Console.Write(">");
            serie.Descricao = Console.ReadLine();

            Console.WriteLine("Por favor, selecione o genero da série:");
            for (int i = 1; i < 14; i++)
            {
                Console.WriteLine($"{i} - {(Generos)i}");
            }
            Console.Write(">");
            serie.Genero = (Generos)int.Parse(Console.ReadLine());

            Console.WriteLine("Por favor, digite o ano da série:");
            Console.Write(">");
            serie.Ano = int.Parse(Console.ReadLine());

            _repositorio.Inserir(serie);
        }

        public void Atualizar()
        {
            foreach (var item in _repositorio.Listar())
            {
                Console.WriteLine($"{item.Id} - {item.Titulo}");
            }

            Console.WriteLine("Selecione uma das séries acima para editar:");
            Console.Write(">");
            var id = int.Parse(Console.ReadLine());

            Serie serie = new Serie();
            Console.WriteLine("Por favor, digite o novo título da série: (Deixe em branco caso nao queria editar)");
            Console.Write(">");
            serie.Titulo = Console.ReadLine();

            Console.WriteLine("Por favor, digite a nova descrição da série: (Deixe em branco caso nao queria editar)");
            Console.Write(">");
            serie.Descricao = Console.ReadLine();

            Console.WriteLine("Por favor, selecione o novo genero da série: (Deixe em branco caso nao queria editar)");
            for (int i = 1; i < 14; i++)
            {
                Console.WriteLine($"{i} - {(Generos)i}");
            }
            Console.Write(">");
            string generoString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(generoString))
            {
                serie.Genero = Generos.Nenhum;
            }
            else
            {
                serie.Genero = (Generos)int.Parse(generoString);
            }

            Console.WriteLine("Por favor, digite o novo ano da série: (Deixe em branco caso nao queria editar)");
            Console.Write(">");
            string anoString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(anoString))
            {
                serie.Ano = -1;
            }
            else
            {
                serie.Ano = int.Parse(anoString);
            }

            _repositorio.Atualizar(id, serie);
        }

        public void Excluir()
        {
            foreach (var item in _repositorio.Listar())
            {
                Console.WriteLine($"{item.Id} - {item.Titulo}");
            }

            Console.WriteLine("Selecione uma das séries acima para excluir:");
            Console.Write(">");
            var id = int.Parse(Console.ReadLine());

            _repositorio.Excluir(id);
        }

        public void Visualizar()
        {
            foreach (var item in _repositorio.Listar())
            {
                Console.WriteLine($"{item.Id} - {item.Titulo}");
            }

            Console.WriteLine("Selecione uma das séries acima para visualizar:");
            Console.Write(">");
            var id = int.Parse(Console.ReadLine());
            var serie = _repositorio.RetornarPorId(id);
            if (serie != null)
                Console.WriteLine(serie.ToString());
            else
                Console.WriteLine("Serie escolhida não existe!");
        }
    }
}