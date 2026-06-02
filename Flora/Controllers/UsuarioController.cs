using Flora.Models;
using Flora.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario_flora>> Cadastrar(Usuario_flora usuario)
        {
            if (usuario.senha != usuario.confirmar_senha)
            {
                return BadRequest("As senhas não coincidem.");
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario_flora>>> Listar()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
    
}