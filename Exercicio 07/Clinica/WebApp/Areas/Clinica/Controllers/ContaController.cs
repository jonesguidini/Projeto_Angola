using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Controllers;

namespace WebApp.Areas.Clinica.Controllers
{
    public class ContaController : CustomController
    {
        private readonly string _ControllerName;

        public ContaController()
        {
            // define o nome da controller
            _ControllerName = "Conta";
        }

        public ActionResult Listar()
        {
            return RedirectToAction("Info");
        }

            public ActionResult Info()
        {
            // Define viewbags: (1) título da página, (2) nome do controller, (3) Nome do controller formatado para visualização (sem acentos e caracteres especiais)
            base.DefineViewbagsTituloEBreadcrumb("Informações da Clinica", _ControllerName, "Clínica");

            // carrega viewbag mensagens status
            base.DefineViewbagsMensagensStatus();

            return View();
        }

    }
}