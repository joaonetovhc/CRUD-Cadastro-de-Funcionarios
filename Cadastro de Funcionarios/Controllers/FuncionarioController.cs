
using Cadastro_de_Funcionarios.Models;
using Cadastro_de_Funcionarios.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_de_Funcionarios.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly InterfaceFuncionarioRepos _funcionarioRepos;
        public FuncionarioController(InterfaceFuncionarioRepos funcionarioRepos)
        {
            _funcionarioRepos = funcionarioRepos;
        }

        // criando os metodos das paginas de cadastro, edição e exclusão etc
        public IActionResult Cadastrar()
        {
            return View();
        }
       public IActionResult Editar(int id)
        {
            FuncionarioModel funcionario = _funcionarioRepos.EditId(id);
            return View(funcionario);
        }

        public IActionResult Apagar(int id)
        {
            FuncionarioModel funcionario = _funcionarioRepos.EditId(id);
            return View(funcionario);
        }

        public IActionResult Delete(int id) 
        {
            _funcionarioRepos.Delete(id);
            return RedirectToAction("Index","Home");
        }




        [HttpPost]
        public IActionResult Adicionar(FuncionarioModel funcionario)
        {
            _funcionarioRepos.Adicionar(funcionario);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Alterar(FuncionarioModel funcionario)
        {
            _funcionarioRepos.Atualizar(funcionario);
            return RedirectToAction("Index","Home");
        }

    }
}
