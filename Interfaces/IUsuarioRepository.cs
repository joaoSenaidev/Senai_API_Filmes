using API_Filmes_senai.Domains;

namespace API_Filmes_senai.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailSenha(string email, string senha);

    }
}
