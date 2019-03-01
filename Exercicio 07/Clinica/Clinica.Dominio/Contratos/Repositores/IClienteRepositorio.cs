using Clinica.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Contratos.Repositores
{
    public interface IClienteRepositorio : IRepositorioBase<Entidades.Cliente>, IDisposable
    {
        void AgendarMassagem(Entidades.Dto.MassagemDto massagem);

        void ReagendarMassagem(Entidades.Dto.MassagemDto massagem);

        void CancelarMassagem(int codCliente);

        Cliente ConsultarPorNome(string nome);
    }
}
