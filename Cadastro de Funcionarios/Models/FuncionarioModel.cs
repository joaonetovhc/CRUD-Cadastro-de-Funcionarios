using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_Funcionarios.Models
{
    public class FuncionarioModel //Criação de atributos para o banco 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do funcionario")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a função do funcionario")]
        public string Funcao { get; set; }

        [Required(ErrorMessage = "Digite o salario do funcionario")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "Informe um contato do funcionario")]
        public string Contato { get; set;}
    }
    
}
