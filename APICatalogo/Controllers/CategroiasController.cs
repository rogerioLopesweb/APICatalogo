using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasProdutos()
        {
            var categorias = await _context.Categorias.Include(p=> p.Produtos).ToListAsync();
            if (categorias.Count == 0)
            {
                return NotFound("Categorias não encontradas...");
            }
            return Ok(categorias);
        }

        [HttpGet("lista")]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            var categorias = await _context.Categorias.AsNoTracking().ToListAsync();
            if (categorias.Count == 0)
            {
                return NotFound("Categorias não encontradas...");
            }
            return Ok(categorias);

        }


        [HttpGet("{id:Guid}", Name = "obterCategoria")]
        public async Task<ActionResult<Categoria>> Get(Guid id)
        {
            try
            {
                var categoria = await _context.Categorias.FirstOrDefaultAsync(p => p.CategoriaId == id);
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
        public async Task<ActionResult> Post(Categoria categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return BadRequest("Categoria inválida...");
                }
               await _context.Categorias.AddAsync(categoria);
               await _context.SaveChangesAsync();
               return CreatedAtRoute("obterCategoria", new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }

           
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var categoria = await _context.Categorias.FirstOrDefaultAsync(p => p.CategoriaId == id);
                if (categoria == null)
                {
                    return NotFound("Categoria não encontrada...");
                }
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return Ok("Categoria removida com sucesso...");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }
        }
    }
}
