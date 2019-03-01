using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Controllers;

namespace WebApp.Areas.Clinica.Controllers
{
    public class MassagemController : CustomController
    {
        private readonly string _ControllerName;

        public MassagemController()
        {
            // define o nome da controller
            _ControllerName = "Massagem";
        }

        // GET: Clinica/Massagens
        public ActionResult Listar()
        {
            // Define viewbags: (1) título da página, (2) nome do controller, (3) Nome do controller formatado para visualização (sem acentos e caracteres especiais)
            base.DefineViewbagsTituloEBreadcrumb("Lista de Massagens", _ControllerName, "Massagens");

            // carrega viewbag mensagens status
            base.DefineViewbagsMensagensStatus();

            return View();
        }

        // GET: Clinica/Massagens/Details/5
        public ActionResult Visualizar(int id)
        {
            // Define viewbags: (1) título da página, (2) nome do controller, (3) Nome do controller formatado para visualização (sem acentos e caracteres especiais)
            base.DefineViewbagsTituloEBreadcrumb("Visualizar Massagem", _ControllerName, "Massagens");

            // carrega viewbag mensagens status
            base.DefineViewbagsMensagensStatus();

            ViewBag.CodMassagem = id;

            return View(id);
        }

        // GET: Clinica/Massagens/Details/5
        public ActionResult Reagendar(int id)
        {
            // Define viewbags: (1) título da página, (2) nome do controller, (3) Nome do controller formatado para visualização (sem acentos e caracteres especiais)
            base.DefineViewbagsTituloEBreadcrumb("Reagendar Massagem", _ControllerName, "Massagens");

            // carrega viewbag mensagens status
            base.DefineViewbagsMensagensStatus();

            ViewBag.CodMassagem = id;

            return View(id);
        }

        // GET: Clinica/Massagens/Create
        public ActionResult Agendar()
        {
            // Define viewbags: (1) título da página, (2) nome do controller, (3) Nome do controller formatado para visualização (sem acentos e caracteres especiais)
            base.DefineViewbagsTituloEBreadcrumb("Agendar Massagem", _ControllerName, "Massagens");

            // carrega viewbag mensagens status
            base.DefineViewbagsMensagensStatus();

            return View();
        }
    }
}