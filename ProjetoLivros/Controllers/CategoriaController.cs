using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;
using ProjetoLivros.Repositories;

namespace ProjetoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var categoria = _categoriaRepository.ListarTodos();
            return Ok(categoria);
        }

        [HttpPost]

        public IActionResult CadastrarCategoria(Categoria categoria)
        {
            _categoriaRepository.Cadastrar(categoria);

            return Created();
        }

        [HttpPut("{id}")]

        public IActionResult Editar(int id, Categoria categoria)
        {
            try
            {
                _categoriaRepository.Atualizar(id, categoria);
                return Ok(categoria);
            }
            catch(Exception ex)
            {
                return NotFound("Categoria não encontrado");
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _categoriaRepository.Deletar(id);

                return NoContent();
            }
            catch(Exception)
            {
                return NotFound("Categoria não encontrado");
            }
        }
    }
}
