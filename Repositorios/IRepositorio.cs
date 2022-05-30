namespace CadastroSeries.Repositorios
{
    public interface IRepositorio<T>
    {
        List<T> Listar();
        T RetornarPorId(int id);
        void Inserir(T model);
        void Excluir(int id);
        void Atualizar(int id, T model);        
    }
}