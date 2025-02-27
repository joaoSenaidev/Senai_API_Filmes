using System.Data.SqlTypes;
using API_Filmes_senai.Domains;

namespace API_Filmes_senai.Interfaces
{

    /// <summary>
    /// Interface para Genero: Contrato
    /// Toda classe que herdar(implementar) essa interface, 
    /// devera implementar todos os metodos definidos aqui dentro
    /// </summary>

    public interface IGeneroRepository
    {
        //CRUD : Metodos
        //C : Create : Cadastrar um novo objeto
        //R : Read : Listar todos os objetos
        //U : Uptade : Alterar um objeto 
        //D : Delete : Deleto ou excluo um objeto

        //Metodo = TipoDeRetorno NomeDoMetodo(Argumentos)

        void Cadastrar(Genero novoGenero);

        List<Genero> Listar();

        void Atualizar(Guid id, Genero genero);

        void Deletar(Guid id);

        Genero BuscarPorId(Guid id);
    }
}
