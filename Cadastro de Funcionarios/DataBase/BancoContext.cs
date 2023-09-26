using Cadastro_de_Funcionarios.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_de_Funcionarios.DataBase
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) // construtor inejtando como parametro de entrada Dbcontext
        { 
        
        }
        //configurando o Contexto para pegar a contatoModel e fazer a tabela Contatos no Db

        public DbSet<FuncionarioModel> Funcionarios { get; set; }

        

    }
}
