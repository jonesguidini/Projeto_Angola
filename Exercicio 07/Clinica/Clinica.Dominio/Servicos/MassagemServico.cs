using Clinica.Dominio.Contratos;
using Clinica.Dominio.Contratos.Repositores;
using Clinica.Dominio.Contratos.Servicos;
using Clinica.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Servicos
{
    public class MassagemServico : ServicoBase<Entidades.Massagem>, IMassagemServico
    {
        // UnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        /// IClienteRepositorio
        private readonly IMassagemRepositorio _massagemRepositorio;

        public MassagemServico(IMassagemRepositorio massagemRepositorio, IUnitOfWork unitOfWork) : base(massagemRepositorio)
        {
            _massagemRepositorio = massagemRepositorio;
            _unitOfWork = unitOfWork;
        }

        public List<Massagem> RetornaMassagemsPorCliente(int codCliente)
        {
            return _massagemRepositorio.RetornaMassagemsPorCliente(codCliente);
        }
    }
}
