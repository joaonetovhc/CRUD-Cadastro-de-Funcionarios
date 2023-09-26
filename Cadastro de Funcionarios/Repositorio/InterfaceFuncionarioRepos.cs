using Cadastro_de_Funcionarios.Models;

namespace Cadastro_de_Funcionarios.Repositorio
{
    public interface InterfaceFuncionarioRepos
    {
       
        List<FuncionarioModel> BuscarTodos();

        FuncionarioModel Adicionar(FuncionarioModel funcionario);

        FuncionarioModel EditId(int id);

        FuncionarioModel Atualizar(FuncionarioModel funcionario);

        bool Delete(int id);
    }
}
