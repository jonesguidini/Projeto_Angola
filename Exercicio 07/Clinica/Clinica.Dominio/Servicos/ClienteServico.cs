using Clinica.Dominio.Contratos;
using Clinica.Dominio.Contratos.Repositores;
using Clinica.Dominio.Contratos.Servicos;
using Clinica.Dominio.Entidades;
using Clinica.Dominio.Entidades.Dto;
using System.Collections.Generic;

namespace Clinica.Dominio.Servicos
{
    public class ClienteServico : ServicoBase<Entidades.Cliente>, IClienteServico
    {
        // UnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        /// IClienteRepositorio
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio, IUnitOfWork unitOfWork) : base(clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _unitOfWork = unitOfWork;
        }

        public void AgendarMassagem(MassagemDto massagem)
        {
            _clienteRepositorio.AgendarMassagem(massagem);
        }

        public void CancelarMassagem(int codCliente)
        {
            _clienteRepositorio.CancelarMassagem(codCliente);
        }

        public Cliente ConsultarPorNome(string nome)
        {
           return _clienteRepositorio.ConsultarPorNome(nome);
        }

        public void ReagendarMassagem(MassagemDto massagem)
        {
            _clienteRepositorio.ReagendarMassagem(massagem);
        }

        //public IEnumerable<Cliente> RetornaTodos()
        //{
        //    return _clienteRepositorio.RetornaTodos();
        //}

        public override void Salvar()
        {
            _unitOfWork.Commit();
        }
    }
}
