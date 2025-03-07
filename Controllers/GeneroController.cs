using API_Filmes_senai.Domains;
using API_Filmes_senai.Interfaces;
using API_Filmes_senai.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        /// <summary>
        /// Listar Gêneros
        /// </summary>
        /// <returns> Lista de Gêneros</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastrar um Gênero
        /// </summary>
        /// <param name="novoGenero">Gênero cadatrado</param>
        /// <returns>Novo Gênero</returns>
        [HttpPost]
        public IActionResult Post(Genero novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar um Gênero pelo seu id
        /// </summary>
        /// <param name="id">Id do Gênero Buscado</param>
        /// <returns>Gênero Buscado</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Genero generoBuscado = _generoRepository.BuscarPorId(id);

                return Ok(generoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Atualização de gêneros
        /// </summary>
        /// <param name="id">Id do Genero Atualizado</param>
        /// <param name="genero">Nome do Gênero que irá substituir</param>
        /// <returns>Gênero Atualizado</returns>
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Genero genero)
        {
            try
            {
                _generoRepository.Atualizar(id, genero);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deletar um Gênero
        /// </summary>
        /// <param name="id">Id do Gênero que ira ser Deletado</param>
        /// <returns>Linha vazia</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }








        }
    }
}
