using Clinica.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextFactory _databaseFactory;
        

        /// <param name="databaseFactory"></param>
        public UnitOfWork(IDbContextFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }

        /// <summary>
        /// Commit
        /// </summary>
        public void Commit()
        {
            
        }
    }
}
