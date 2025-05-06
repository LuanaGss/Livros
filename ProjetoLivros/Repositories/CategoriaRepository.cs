using ProjetoLivros.Context;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly LivrosContext _context;

        public CategoriaRepository(LivrosContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Categoria categoria)
        {
            Categoria categoriaEncontrada = _context.Categorias.Find(id);

            if(categoriaEncontrada == null)
            {
                throw new Exception();
            }

            categoriaEncontrada.NomeCategoria = categoria.NomeCategoria;

            _context.SaveChanges();

        }

        public void Cadastrar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Categoria categoriaEncontrada = _context.Categorias.Find(id);

            if(categoriaEncontrada == null)
            {
                throw new Exception();
            }

            _context.Categorias.Remove(categoriaEncontrada);

            _context.SaveChanges();
        }

        public List<Categoria> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
