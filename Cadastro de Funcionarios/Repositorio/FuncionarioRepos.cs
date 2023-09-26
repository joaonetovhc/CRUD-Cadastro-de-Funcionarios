using Cadastro_de_Funcionarios.DataBase;
using Cadastro_de_Funcionarios.Migrations;
using Cadastro_de_Funcionarios.Models;

namespace Cadastro_de_Funcionarios.Repositorio
{
    public class FuncionarioRepos : InterfaceFuncionarioRepos
    {
        
        private readonly BancoContext _bancoContext; // pra acessar os metodos
        public FuncionarioRepos(BancoContext bancoContext)  //injetando o contexto
        { 
            _bancoContext = bancoContext;
        }

        // busca os dados do DB 
        public List<FuncionarioModel> BuscarTodos()
        {
            return _bancoContext.Funcionarios.ToList();
        }

        //onde vai gravar no DB
        public FuncionarioModel Adicionar(FuncionarioModel funcionario) 
        {
            _bancoContext.Funcionarios.Add(funcionario);
            _bancoContext.SaveChanges();
            return funcionario;
        }

        public FuncionarioModel EditId(int id)
        {
            return _bancoContext.Funcionarios.FirstOrDefault(x => x.Id == id);
        }

        // faz a edição do contato e atualiza os dados
        public FuncionarioModel Atualizar(FuncionarioModel funcionario)
        {
            FuncionarioModel funcionarioDB = EditId(funcionario.Id);
            if (funcionarioDB == null) throw new Exception("Erro na alteração");

            funcionarioDB.Nome = funcionario.Nome;
            funcionarioDB.Funcao = funcionario.Funcao;
            funcionarioDB.Salario = funcionario.Salario;
            funcionarioDB.Contato = funcionario.Contato;
            _bancoContext.Funcionarios.Update(funcionarioDB);
            _bancoContext.SaveChanges();

            return funcionarioDB;
        }

        public bool Delete(int id)
        {
            FuncionarioModel funcionarioDB = EditId(id);
            if (funcionarioDB == null) throw new Exception("Erro ao Apagar");

            _bancoContext.Funcionarios.Remove(funcionarioDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
