using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Contratos.Servicos
{
    public interface IClienteServico : IServicoBase<Entidades.Cliente>
    {

        Entidades.Cliente ConsultarPorNome(string nome);

        void AgendarMassagem(Entidades.Dto.MassagemDto massagem);

        void ReagendarMassagem(Entidades.Dto.MassagemDto massagem);

        void CancelarMassagem(int codCliente);
    }
}
