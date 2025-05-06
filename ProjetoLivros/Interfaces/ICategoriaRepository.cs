using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categoria> ListarTodos();

        void Cadastrar(Categoria categoria);

        void Atualizar(int id, Categoria categoria);

        void Deletar(int id);
    }
}
