using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Aula1AspNetMVC.Models;

namespace Aula1AspNetMVC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = new Cliente()
            {
                Nome = "ASP",
                Sobrenome = "NET",
                DataCadastro = DateTime.Now,
                Id = 1
            };

            return View(cliente);
        }

        //indicar uma view mesmo que a action fuja do padrão da rota
        //construtor da view aceita mais parametros
        public ActionResult Teste()
        {
            var cliente = new Cliente()
            {
                Nome = "ASP",
                Sobrenome = "NET",
                DataCadastro = DateTime.Now,
                Id = 1
            };

            //ViewBags podem receber qlqr nome, são dinamicas}
            // ViewBag.Cliente = cliente;

            //ViewData["Cliente"] = cliente;

            ViewData["Cliente"] = "Texto";

            return View("Index",cliente);
        }

        //action de lista
        public ActionResult Lista()
        {
            var listaClientes = new List<Cliente>()
            {
                new Cliente() { Nome = "João", Sobrenome = "Pedro", DataCadastro = DateTime.Now,Id = 1},
                new Cliente() { Nome = "Fulano", Sobrenome = "Beltrano", DataCadastro = DateTime.Now, Id = 2}
            };

            return View(listaClientes);
        }

        //action de pesquisa
        //parametro tem que ser chamado de id, pois está assim na rota
        public ActionResult Pesquisa(int? id) //Também poderia ser assim(int id = 0) //pode passar mais de um parametro (int id, string nome)
        {
            var listaClientes = new List<Cliente>()
            {
                new Cliente() { Nome = "João", Sobrenome = "Pedro", DataCadastro = DateTime.Now,Id = 1},
                new Cliente() { Nome = "Fulano", Sobrenome = "Beltrano", DataCadastro = DateTime.Now, Id = 2},
                new Cliente() { Nome = "Eduardo", Sobrenome = "Pires", DataCadastro = DateTime.Now,Id = 3},
                new Cliente() { Nome = "Aluno", Sobrenome = "Favorito", DataCadastro = DateTime.Now, Id = 4}
            };

            var cliente = listaClientes.Where(c => c.Id == id).ToList();

            if (!cliente.Any())
            {
                TempData["Erro"] = "Nenhum cliente selecionado";
                return RedirectToAction("ErroPesquisa");
            }

            return View("Lista",cliente);
        }

        public ActionResult ErroPesquisa()
        {
            return View("Error");
        }
    }
}