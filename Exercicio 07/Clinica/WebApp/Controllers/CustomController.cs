using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class CustomController : Controller
    {
        public CustomController()
        {

            ViewBag.NomeUsuarioLogado = "kkk";

            var versao = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ViewBag.VersaoApp = versao.Substring(4, 3);
        }

        /// <summary>
        /// Define viewbags do tipo e a mensagem de retorno (Toast message)
        /// </summary>
        public void DefineViewbagsMensagensStatus()
        {
            // seta a viewBag para apresentar mensagem caso aja alguma
            ViewBag.tipoMsg = TempData["tipoMsg"] ?? null;
            ViewBag.mensagem = TempData["mensagem"] ?? null;
        }

        /// <summary>
        /// Define viewbags do título da página, link base e link label do controller 
        /// </summary>
        /// <param name="tituloPagina"></param>
        /// <param name="LinkBaseController"></param>
        /// <param name="LinkBaseControllerLabel"></param>
        public void DefineViewbagsTituloEBreadcrumb(string tituloPagina, string LinkBaseController, string LinkBaseControllerLabel, string LinkBaseActionLabel = "Listar", string LinkBaseId = null)
        {
            ViewBag.Title = tituloPagina;
            ViewBag.LinkBaseController = LinkBaseController;
            ViewBag.LinkBaseControllerLabel = LinkBaseControllerLabel;
            ViewBag.LinkBaseActionLabel = LinkBaseActionLabel;
            ViewBag.LinkBaseId = LinkBaseId;
        }


        /// <summary>
        /// Define mensagem de erro ou sucesso para algum redirecionamento
        /// </summary>
        /// <param name="tipoMsg"></param>
        /// <param name="mensagem"></param>
        [HttpPost]
        public JsonResult AtribuiMensagemStatus(string tipoMsg, string mensagem)
        {
            TempData["tipoMsg"] = tipoMsg;
            TempData["mensagem"] = mensagem;

            var urlPadrao = Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~");

            return Json(urlPadrao, JsonRequestBehavior.AllowGet);
        }

        // define mensagem para os controllers
        public void AtribuiMensagemStatusControllers(string tipoMsg, string mensagem)
        {
            TempData["tipoMsg"] = tipoMsg;
            TempData["mensagem"] = mensagem;
        }

        public string RetornaBadgeSituacaoSessao(byte situacao)
        {
            var badge = "";

            switch (situacao)
            {
                case 1: //criada
                    badge = "badge badge-info";
                    break;
                case 2: // chamada aberta
                    badge = "badge badge-warning";
                    break;
                case 3: // chamada encerrada
                    badge = "badge badge-chamada-encerrada";
                    break;
                case 4: // iniciada
                    badge = "badge badge-primary";
                    break;
                case 5: // concluida
                    badge = "badge badge-dark";
                    break;
            }

            return badge;
        }

        public string retornaNomeStatusTipo(string nomeStatus, string tipo)
        {
            //remove ultimo caracter do status
            nomeStatus = nomeStatus.Substring(0, nomeStatus.Length - 1);
            nomeStatus = tipo == "(a)" ? nomeStatus + "a" : nomeStatus + "o";
            return nomeStatus;
        }
    }
}