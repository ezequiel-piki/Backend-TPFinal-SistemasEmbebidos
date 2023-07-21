using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPFinalSistemasEmbebidos_BenitezEzequiel.Entidades;

namespace TPFinalSistemasEmbebidos_BenitezEzequiel.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("FiltrarPorDni")]
        public async Task<IEnumerable<Usuario>> FiltrarPorDni(int dni)
        {
            return await _context.Usuarios.Where(
                u => u.Dni.ToString().StartsWith(dni.ToString())
                ).ToListAsync();
        }

        [HttpPost("crear")]
        public async Task<ActionResult> Post (Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("editar")]
        public async Task <IActionResult> Editar([FromBody] Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task <IActionResult> Eliminar (int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpGet]
        [Route("paginacion/{pagina:int}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetPaginacion(int pagina = 1)
        {
            var cantidadRegistrosPorPagina = 5;
            var usuarios = await _context.Usuarios
                .Skip((pagina-1)*cantidadRegistrosPorPagina)
                .Take(cantidadRegistrosPorPagina)
                .ToListAsync();
            return usuarios;
        }
    }
}
