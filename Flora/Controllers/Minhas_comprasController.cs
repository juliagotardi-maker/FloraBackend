using Flora.DTOs;
using Flora.Models;
using Flora.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MinhasComprasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MinhasComprasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] CompraRequest request)
        {
            var usuario = await _context.Usuarios.FindAsync(request.id_usuario);

            if (usuario == null)
                return BadRequest("Usuário não encontrado.");

            if (request.itens == null || !request.itens.Any())
                return BadRequest("Nenhum item informado.");

            var compra = new MinhasCompras
            {
                id_usuario = request.id_usuario,
                status_compra = "Pendente",
                valor = 0
            };

            _context.MinhasCompras.Add(compra);
            await _context.SaveChangesAsync();

            decimal valorTotal = 0;

            foreach (var item in request.itens)
            {
                var produto = await _context.Produtos.FindAsync(item.produto_id);

                if (produto == null)
                    return BadRequest($"Produto {item.produto_id} não encontrado.");

                if (item.quantidade <= 0)
                    return BadRequest("Quantidade inválida.");

                if (produto.quantidade < item.quantidade)
                    return BadRequest($"Estoque insuficiente para {produto.nome}.");

                produto.quantidade -= item.quantidade;

                var itemCompra = new Itens
                {
                    IdMinhasCompras = compra.id_minhas_compras,
                    ProdutoId = item.produto_id,
                    Quantidade = item.quantidade
                };

                _context.Itens.Add(itemCompra);

                valorTotal += produto.preco * item.quantidade;
            }

            compra.valor = valorTotal;

            await _context.SaveChangesAsync();

            return Ok(compra);
        }

        [HttpGet]
        public async Task<ActionResult<List<MinhasCompras>>> Listar()
        {
            var compras = await _context.MinhasCompras
                .Include(c => c.Usuario)
                .ToListAsync();

            return Ok(compras);
        }

        [HttpGet("usuario/{id_usuario}")]
        public async Task<ActionResult<List<MinhasCompras>>> BuscarPorUsuario(int id_usuario)
        {
            var compras = await _context.MinhasCompras
                .Include(c => c.Usuario)
                .Where(c => c.id_usuario == id_usuario)
                .ToListAsync();

            return Ok(compras);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarStatus(int id, MinhasCompras compra)
        {
            var compraExistente = await _context.MinhasCompras.FindAsync(id);

            if (compraExistente == null)
                return NotFound("Compra não encontrada.");

            compraExistente.status_compra = compra.status_compra;

            await _context.SaveChangesAsync();

            return Ok(compraExistente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var compra = await _context.MinhasCompras.FindAsync(id);

            if (compra == null)
                return NotFound("Compra não encontrada.");

            _context.MinhasCompras.Remove(compra);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}