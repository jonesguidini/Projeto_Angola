using Clinica.Dominio.Contratos.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Controllers;

namespace WebApp.Areas.Clinica.Controllers
{
    public class ClienteController : CustomController
    {
        private readonly string _ControllerName;

        public ClienteController()
        {
            // define o nome da controller
            _ControllerName = "Cliente";
        }

        // GET: Clinica/Clientes
        public ActionResult Listar()
        {
            // Define viewbags: (1) título da página, (2) nome do controller, (3) Nome do controller formatado para visualização (sem acentos e caracteres especiais)
            base.DefineViewbagsTituloEBreadcrumb("Lista de Clientes", _ControllerName, "Clientes");

            // carrega viewbag mensagens status
            base.DefineViewbagsMensagensStatus();

            return View();
        }

        // GET: Clinica/Clientes/Details/5
        public ActionResult Visualizar(int id)
        {
            // Define viewbags: (1) título da página, (2) nome do controller, (3) Nome do controller formatado para visualização (sem acentos e caracteres especiais)
            base.DefineViewbagsTituloEBreadcrumb("Visualizar Cliente", _ControllerName, "Clientes");

            // carrega viewbag mensagens status
            base.DefineViewbagsMensagensStatus();

            ViewBag.CodCliente = id;

            return View(id);
        }

        // GET: Clinica/Clientes/Create
        public ActionResult Cadastrar()
        {
            // Define viewbags: (1) título da página, (2) nome do controller, (3) Nome do controller formatado para visualização (sem acentos e caracteres especiais)
            base.DefineViewbagsTituloEBreadcrumb("Cadastrar Cliente", _ControllerName, "Clientes");

            // carrega viewbag mensagens status
            base.DefineViewbagsMensagensStatus();

            return View();
        }


        // GET: Clinica/Clientes/Edit/5
        public ActionResult Alterar(int id)
        {
            // Define viewbags: (1) título da página, (2) nome do controller, (3) Nome do controller formatado para visualização (sem acentos e caracteres especiais)
            base.DefineViewbagsTituloEBreadcrumb("Alterar Cliente", _ControllerName, "Clientes");

            // carrega viewbag mensagens status
            base.DefineViewbagsMensagensStatus();

            ViewBag.CodCliente = id;

            return View(id);
        }

       
    }
}
