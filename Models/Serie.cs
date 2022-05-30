using System.Text;

namespace CadastroSeries.Models
{
    public class Serie : EntidadeBase
    {
        public Generos Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }

        public Serie()
        {
            
        }

        public Serie(Generos genero, string titulo, string descricao, int ano)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
        }

        public override string ToString()
        {            
            string resultado = $"Gênero: {Genero} {Environment.NewLine}";
            resultado +=       $"Titulo: {Titulo} {Environment.NewLine}";
            resultado +=       $"Descrição: {Descricao} {Environment.NewLine}";
            resultado +=       $"Ano de Início: {Ano}";
            return resultado;
        }
    }
}