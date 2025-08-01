using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var produtos = _context.Produtos.ToList();
            if (produtos == null || !produtos.Any())
            {
                return NotFound("Produtos não encontrados...");
            }

            return produtos;
        }
        [HttpGet("{id:guid}")]
        public ActionResult<Produto> Get(Guid id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado...");
            }
            return produto;
        }
        [HttpPost("{id:guid}")]
        public ActionResult Post(Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto inválido...");
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = produto.ProdutoId }, produto);
        }
        [HttpPut]
        public ActionResult Put(Guid id, Produto produto)
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

        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id)
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

    }

}