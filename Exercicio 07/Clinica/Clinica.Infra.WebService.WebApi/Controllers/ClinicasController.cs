using Clinica.Dominio.Contratos.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Clinica.Infra.WebService.WebApi.Controllers
{
    public class ClinicasController : ApiController
    {
        private readonly IClinicaServico _clinicaServico;

        public ClinicasController(IClinicaServico clinicaServico)
        {
            _clinicaServico = clinicaServico;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/clinicas/{codClinica}")]
        public IHttpActionResult RetornaClinica(int codClinica)
        {
            return Ok(_clinicaServico.RetornaPorId(codClinica));
        }
    }
}
