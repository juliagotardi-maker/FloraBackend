using Flora.Models;
using Flora.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Login(Login login)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.email == login.email);

            if (usuario == null)
            {
                return Unauthorized("Usuário não encontrado.");
            }

            if (usuario.senha != login.senha)
            {
                return Unauthorized("Senha incorreta.");
            }

            return Ok(new
            {
                mensagem = "Login realizado com sucesso!",
                id = usuario.id_usuario,
                nome = usuario.nome,
                email = usuario.email
            });
        }
    }
}