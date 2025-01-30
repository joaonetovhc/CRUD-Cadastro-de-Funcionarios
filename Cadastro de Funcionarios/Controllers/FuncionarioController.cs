
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
            try
            {
                //verificando se foi apagado para exibir a validação ou erro
                bool apagado = _funcionarioRepos.Delete(id);
                if (apagado) 
                {
                    TempData["MensagemSucesso"] = "Funcionário excluído com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível excluir esse funcionário.";
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível excluir esse funcionário. Detalhe: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public IActionResult Adicionar(FuncionarioModel funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _funcionarioRepos.Adicionar(funcionario);
                    TempData["MensagemSucesso"] = "Funcionário cadastrado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }
                return View("Cadastrar", funcionario); // caso nao seja valido, irá redirecionar para a view cadastrar 
            }
            catch (Exception ex) 
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar esse funcionário. Detalhe: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Alterar(FuncionarioModel funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _funcionarioRepos.Atualizar(funcionario);
                    TempData["MensagemSucesso"] = "Funcionário editado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }
                return View("Editar", funcionario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível editar esse funcionário. Detalhe: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
