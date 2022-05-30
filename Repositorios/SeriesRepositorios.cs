using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroSeries.Models;

namespace CadastroSeries.Repositorios
{
    public class SeriesRepositorios : IRepositorio<Serie>
    {
        private List<Serie> _series = new List<Serie>();
        private int _idAuto = 1;

        public SeriesRepositorios()
        {
            Inserir(new Serie(Generos.Acao, "Indiana Jones", "Serie de ação", 1998));
            Inserir(new Serie(Generos.Comedia, "Adam Sandler Serie#8787", "Filme de Comedia", 1996));
        }

        public void Atualizar(int id, Serie model)
        {
            var serie = _series.FirstOrDefault(q => q.Id == id);
            serie.Ano = model.Ano < 0 ? serie.Ano : model.Ano;
            serie.Descricao = string.IsNullOrWhiteSpace(model.Descricao) ? serie.Descricao : model.Descricao;
            serie.Genero = model.Genero == Generos.Nenhum ? serie.Genero : model.Genero;
            serie.Titulo = string.IsNullOrWhiteSpace(model.Titulo) ? serie.Titulo : model.Titulo;
        }

        public void Excluir(int id)
        {
            var serieParaRemover = _series.FirstOrDefault(q => q.Id == id);
            if (serieParaRemover != null)
                _series.Remove(serieParaRemover);
        }

        public void Inserir(Serie model)
        {
            model.Id = _idAuto++;
            _series.Add(model);
        }

        public List<Serie> Listar()
        {
            return new List<Serie>(_series);
        }

        public Serie RetornarPorId(int id)
        {
            return _series.FirstOrDefault(q => q.Id == id);
        }
    }
}