using Flora.Models;
using Flora.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return Ok(produto);
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Listar()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> BuscarPorId(int id)
        {
            var produto = await _context.Produtos
                .FirstOrDefaultAsync(p => p.id_produto == id);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, Produto produto)
        {
            var produtoExistente = await _context.Produtos
                .FirstOrDefaultAsync(p => p.id_produto == id);

            if (produtoExistente == null)
                return NotFound("Produto não encontrado.");

            produtoExistente.nome = produto.nome;
            produtoExistente.descricao = produto.descricao;
            produtoExistente.preco = produto.preco;
            produtoExistente.quantidade = produto.quantidade;

            await _context.SaveChangesAsync();

            return Ok(produtoExistente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var produto = await _context.Produtos
                .FirstOrDefaultAsync(p => p.id_produto == id);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
