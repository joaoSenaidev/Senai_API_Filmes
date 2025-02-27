using API_Filmes_senai.Context;
using API_Filmes_senai.Domains;
using API_Filmes_senai.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace API_Filmes_senai.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly Filmes_Context _context;

        public FilmeRepository(Filmes_Context contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Guid id, Filme filme)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                if (filmeBuscado != null) 
                {
                    filmeBuscado.Titulo = filme.Titulo;
                    filmeBuscado.IdGenero = filme.IdGenero;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                return filmeBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Filme novoFilme)
        {
            try
            {
                _context.Filme.Add(novoFilme);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                if (filmeBuscado != null)
                {
                    _context.Filme.Remove(filmeBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> ListaPorGenero(Guid IdGenero)
        {
            try
            {
                List<Filme> ListaDeFilmes = _context.Filme.Include(g => g.Genero).Where(f => f.IdGenero == IdGenero).ToList();

                    return ListaDeFilmes;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filme.Include(g => g.Genero)
                    .Select(f => new Filme
                    {
                        IdFilme = f.IdFilme,
                        Titulo = f.Titulo,

                        Genero = new Genero
                        {
                            Nome = f.Genero!.Nome
                        }
                    })
                    
                    .ToList();

                return listaDeFilmes;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
