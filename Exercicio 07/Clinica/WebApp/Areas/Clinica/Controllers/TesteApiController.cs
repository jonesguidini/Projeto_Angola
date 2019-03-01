using AutoMapper;
using Clinica.Dominio.Contratos.Servicos;
using Clinica.Dominio.Entidades;
using Clinica.Dominio.Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Areas.Clinica.Controllers
{
    public class TesteApiController : ApiController
    {

        private readonly IMassagemServico _massagemServico;
        private readonly IClienteServico _clienteServico;

        public TesteApiController(IMassagemServico massagemServico, IClienteServico clienteServico)
        {
            _massagemServico = massagemServico;
            _clienteServico = clienteServico;
        }

        [HttpGet]
        [Route("api/massagens")]
        public IHttpActionResult RetornaTodasMassagens()
        {
            return Ok(_massagemServico.RetornaTodos());
        }

        [HttpGet]
        [Route("api/massagens/{codMassagem}")]
        public IHttpActionResult RetornaMassagem(int codMassagem)
        {
            return Ok(_massagemServico.RetornaPorId(codMassagem));
        }

        [HttpPut]
        [Route("api/massagens/cancelar/{codMassagem}")]
        public IHttpActionResult CancelarMassagem(int codMassagem)
        {
            var massagem = _massagemServico.RetornaPorId(codMassagem);
            _massagemServico.Remover(massagem);
            return Ok();
        }

        [HttpGet]
        [Route("api/massagens/cliente/{codCliente}")]
        public IHttpActionResult RetornarPorCliente(int codCliente)
        {
            return Ok(_massagemServico.RetornaMassagemsPorCliente(codCliente));
        }


        [Route("api/massagens/retornaListaClientes")]
        [HttpGet]
        public IHttpActionResult RetornaListaClientes()
        {
            var listaClientes = new Dictionary<int, string>();

            foreach (var Cliente in _clienteServico.RetornaTodos())
            {
                listaClientes.Add(Cliente.CodCliente, Cliente.Nome + " " + Cliente.Sobrenome);
            }

            return Ok(listaClientes);
        }


        
        [Route("api/massagens/agendar")]
        [HttpPost]
        public IHttpActionResult AgendarMassagem(List<MassagemDto> massagens)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            List<Massagem> massagensLista = Mapper.Map<List<MassagemDto>, List<Massagem>>(massagens);

            massagensLista.ForEach(massagem =>
            {
                _massagemServico.Cadastrar(massagem);
                _massagemServico.Salvar();
            });

            return Created("Clinica/Massagem/Listar", new MassagemDto());
        }

        [Route("api/massagens/reagendar/{codMassagem}")]
        [HttpPut]
        public IHttpActionResult ReagendarMassagem(int codMassagem, MassagemDto massagem)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Massagem _massagem = Mapper.Map<MassagemDto, Massagem>(massagem);

            _massagemServico.Atualizar(_massagem);
            _massagemServico.Salvar();

            return Created("Clinica/Massagem/Listar", new MassagemDto());
        }


        [Route("api/massagens/horariospossiveis")]
        [HttpGet]
        public IHttpActionResult RetornaPossibilidadesHorarios()
        {

            var listaHorarios = new Dictionary<string, string>();

            DateTime tempoBase = DateTime.Today;

            for (DateTime _tempo = tempoBase.AddHours(08); _tempo <= tempoBase.AddHours(17); _tempo = _tempo.AddMinutes(30)) //from 16h to 18h hours
            {
                listaHorarios.Add(_tempo.ToShortTimeString(), _tempo.ToShortTimeString());
            }

            return Ok(listaHorarios);
        }

        // VALIDAÇÕES REGRAS DE AGENDAMENTO
        [Route("api/massagens/validaDataCancelamento/{codMassagem}")]
        [HttpGet]
        public IHttpActionResult validaDataCancelamento(int codMassagem)
        {
            var massagem = _massagemServico.RetornaPorId(codMassagem);

            var chegaDataVencendo = (massagem.DataHoraMassagem.Date - DateTime.Now).TotalDays > 1;

            return Ok(chegaDataVencendo);
        }

        [Route("api/massagens/validaTempoMassagemCliente/{codCliente}/{tempoMassagem}")]
        [HttpGet]
        public IHttpActionResult validaTempoMassagemCliente(int codCliente, int tempoMassagem)
        {
            var somaTempoMassagemRegistradas = _massagemServico.RetornaTodos().Where(x => x.CodCliente == codCliente).Sum(x => x.Duracao);

            return Ok((somaTempoMassagemRegistradas + tempoMassagem) > 90);
        }
    }
}
