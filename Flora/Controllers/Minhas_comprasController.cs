using Flora.Models;
using Flora.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<MinhasCompras>> Cadastrar(MinhasCompras compra)
        {
            _context.MinhasCompras.Add(compra);
            await _context.SaveChangesAsync();

            return Ok(compra);
        }

        [HttpGet]
        public async Task<ActionResult<List<MinhasCompras>>> Listar()
        {
            return await _context.MinhasCompras.ToListAsync();
        }

        [HttpGet("usuario/{id_usuario}")]
        public async Task<ActionResult<List<MinhasCompras>>> BuscarPorUsuario(int id_usuario)
        {
            var compras = await _context.MinhasCompras
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