using Cadastro_de_Funcionarios.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_de_Funcionarios.DataBase
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) // construtor injetando como parametro de entrada Dbcontext
        { 
        
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }

    }
}
