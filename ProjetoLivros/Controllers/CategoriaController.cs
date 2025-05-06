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
        public IActionResult ListarCategoria()
        {
            return Ok(_categoriaRepository.ListarTodos());
        }

        [HttpPost]

        public IActionResult CadastrarCategoria(Categoria categoria)
        {
            _categoriaRepository.Cadastrar(categoria);

            return Created();
        }
    }
}
