using Clinica.Dominio.Entidades;
using Clinica.Dominio.Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Contratos.Repositores
{
    public interface IClinicaRepositorio : IRepositorioBase<Entidades.Clinica>, IDisposable
    {

    }
}
