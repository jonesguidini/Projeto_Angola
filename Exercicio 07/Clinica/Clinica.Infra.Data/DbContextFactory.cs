using Clinica.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Infra.Data
{
    public class DbContextFactory<TDbContext> : Disposable, IDbContextFactory where TDbContext : class
    {
        public DbContextFactory()
        {
        }

        public void Dispose()
        {
            //
        }
    }
}
