using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Contratos.Repositores
{
    public interface IMassagemRepositorio : IRepositorioBase<Entidades.Massagem>, IDisposable
    {
        List<Entidades.Massagem> RetornaMassagemsPorCliente(int codCliente);
    }
}
