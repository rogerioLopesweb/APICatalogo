using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                var produtos = _context.Produtos.AsNoTracking().ToList();
                if (produtos == null || !produtos.Any())
                {
                    return NotFound("Produtos não encontrados...");
                }

                return produtos;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }

            
        }
        [HttpGet("{id:guid}")]
        public ActionResult<Produto> Get(Guid id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
                if (produto == null)
                {
                    return NotFound("Produto não encontrado...");
                }
                return produto;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }
        }
        [HttpPost("{id:guid}")]
        public ActionResult Post(Produto produto)
        {
            try
            {
                if (produto == null)
                {
                    return BadRequest("Produto inválido...");
                }
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = produto.ProdutoId }, produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }
        }
        [HttpPut]
        public ActionResult Put(Guid id, Produto produto)
        {
            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest("ID do produto não corresponde ao ID fornecido na URL.");
                }
                if (produto == null)
                {
                    return BadRequest("Produto inválido...");
                }
                var produtoExistente = _context.Produtos.FirstOrDefault(p => p.ProdutoId == produto.ProdutoId);
                if (produtoExistente == null)
                {
                    return NotFound("Produto não encontrado...");
                }
                _context.Entry(produtoExistente).CurrentValues.SetValues(produto);
                _context.SaveChanges();
                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }

        }

        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
                if (produto == null)
                {
                    return NotFound("Produto não encontrado...");
                }
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

    }

}