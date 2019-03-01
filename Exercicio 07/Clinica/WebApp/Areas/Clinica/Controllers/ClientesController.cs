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
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
        private readonly IClienteServico _clienteServico;

        public ClientesController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet]
        [Route("api/clientes")]
        public IHttpActionResult RetornaTodosClientes()
        {
            return Ok(_clienteServico.RetornaTodos());
        }

        [HttpGet]
        [Route("api/clientes/{codCliente}")]
        public IHttpActionResult RetornaCliente(int codCliente)
        {
            return Ok(_clienteServico.RetornaPorId(codCliente));
        }

        [HttpPut]
        [Route("api/clientes/excluir/{codCliente}")]
        public IHttpActionResult ExcluirCliente(int codCliente)
        {
            var cliente = _clienteServico.RetornaPorId(codCliente);

            // exclui o cliente
            _clienteServico.Remover(cliente);

            return Ok();
        }

        [HttpPost]
        [Route("api/clientes/cadastrar")]
        public IHttpActionResult CadastrarClienteB(ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Cliente cliente = Mapper.Map<ClienteDto, Cliente>(clienteDto);

            _clienteServico.Cadastrar(cliente);
            _clienteServico.Salvar();

            // update ref id Dto
            clienteDto.CodCliente = cliente.CodCliente;

            // ao retornar um objeto utilizando HttpActionResult deve ser passar o Uri (url contendo o link do novo objeto criado + o novo objeto criado)
            var urlcargo = "clientes/visualizar/" + cliente.CodCliente.ToString();

            return Created(urlcargo, clienteDto);
        }

        [HttpPut]
        [Route("api/clientes/alterar/{codCliente}")]
        public void AlterarCliente(int codCliente, ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var ClienteDB = _clienteServico.RetornaPorId(codCliente);

            if (ClienteDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map(clienteDto, ClienteDB);

            _clienteServico.Atualizar(ClienteDB);
            _clienteServico.Salvar();
        }
    }
}
