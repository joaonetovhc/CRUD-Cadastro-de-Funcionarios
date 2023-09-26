using Cadastro_de_Funcionarios.Models;
using Cadastro_de_Funcionarios.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cadastro_de_Funcionarios.Controllers
{
    public class HomeController : Controller
    {


        private readonly InterfaceFuncionarioRepos _funcionarioRepos;
        public HomeController(InterfaceFuncionarioRepos funcionarioRepos)
        {
            _funcionarioRepos = funcionarioRepos;
        }

        // vai exibir os cadastrados na index
        public IActionResult Index()
        {
            List<FuncionarioModel> funcionario = _funcionarioRepos.BuscarTodos();
            return View(funcionario);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}