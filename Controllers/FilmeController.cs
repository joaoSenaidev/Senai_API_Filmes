using API_Filmes_senai.Domains;
using API_Filmes_senai.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeController(IFilmeRepository filmeRepository)
        {

            _filmeRepository = filmeRepository;
        }

        /// <summary>
        /// Lista Filmes
        /// </summary>
        /// <returns>Listar os Filmes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Filme> listaDeFilmes = _filmeRepository.Listar();

                return Ok(listaDeFilmes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastrar os Filmes
        /// </summary>
        /// <param name="novoFilme">Filme cadastrado</param>
        /// <returns>Novo Filme</returns>
        [HttpPost]
        public IActionResult Post(Filme novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para Buscar filme por Id
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <returns>Filme Buscado</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Filme filmeBuscado = _filmeRepository.BuscarPorId(id);
                return Ok(filmeBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Atualizar Filmes
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <param name="filme">Titulo do Filme</param>
        /// <returns>Filme Atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Filme filme)
        {
            try
            {
                _filmeRepository.Atualizar(id, filme);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deletar um Filme
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <returns>Linha vazia</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Lista Filme pelo gênero
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <returns>Filme pelo seu gênero</returns>
        [HttpGet("ListarPorGenero/{id}")]
        public IActionResult GetByGenero(Guid id)
        {
            try
            {
                List<Filme> ListarPorGenero = _filmeRepository.ListaPorGenero(id);

                return Ok(ListarPorGenero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

    }
}


