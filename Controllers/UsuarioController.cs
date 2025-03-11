using API_Filmes_senai.Domains;
using API_Filmes_senai.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Cadastrar o Usuario
        /// </summary>
        /// <param name="usuario">Usuario cadastrado</param>
        /// <returns>Usuario</returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        //Buscar por id
        /// <summary>
        /// Endpoint para buscar Usuario pelo seu Id
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        /// <returns>Usuario Buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {

                return Ok(usuarioBuscado);
                }
                return null!;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
