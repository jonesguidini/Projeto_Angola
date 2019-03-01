using Clinica.Dominio.Contratos;
using Clinica.Dominio.Contratos.Repositores;
using Clinica.Dominio.Contratos.Servicos;
using Clinica.Dominio.Entidades;
using Clinica.Dominio.Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Servicos
{
    public class ClinicaServico : ServicoBase<Entidades.Clinica>, IClinicaServico
    {
        // UnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        /// IClienteRepositorio
        private readonly IClinicaRepositorio _clinicaRepositorio;

        public ClinicaServico(IClinicaRepositorio clinicaRepositorio, IUnitOfWork unitOfWork) : base(clinicaRepositorio)
        {
            _clinicaRepositorio = clinicaRepositorio;
            _unitOfWork = unitOfWork;
        }

        public override void Salvar()
        {
            _unitOfWork.Commit();
        }
    }
}
