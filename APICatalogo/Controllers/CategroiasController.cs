using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategroiasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategroiasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            var categorias = _context.Categorias.Include(p=> p.Produtos).ToList();
            if (categorias.Count == 0)
            {
                return NotFound("Categorias não encontradas...");
            }
            return Ok(categorias);
        }

        [HttpGet("lista")]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _context.Categorias.AsNoTracking().ToList();
            if (categorias.Count == 0)
            {
                return NotFound("Categorias não encontradas...");
            }
            return Ok(categorias);

        }


        [HttpGet("{id:Guid}", Name = "obterCategoria")]
        public ActionResult<Categoria> Get(Guid id)
        {
            try
            {
                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
                if (categoria == null)
                {
                    return NotFound("Categorias não encontradas...");
                }
                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }
            
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return BadRequest("Categoria inválida...");
                }
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return CreatedAtRoute("obterCategoria", new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }

           
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
                if (categoria == null)
                {
                    return NotFound("Categoria não encontrada...");
                }
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
                return Ok("Categoria removida com sucesso...");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }
        }
    }
}
