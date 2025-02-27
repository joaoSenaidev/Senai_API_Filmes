using API_Filmes_senai.Domains;

namespace API_Filmes_senai.Interfaces
{
    public interface IFilmeRepository
    {
        void Cadastrar(Filme novoFilme);

        List<Filme> Listar();

        void Atualizar(Guid id, Filme filme);

        void Deletar(Guid id);
        Filme BuscarPorId(Guid id);

        //Listar os filmes pelos os genero - filtro
        List<Filme> ListaPorGenero(Guid IdGenero);
    }
}
