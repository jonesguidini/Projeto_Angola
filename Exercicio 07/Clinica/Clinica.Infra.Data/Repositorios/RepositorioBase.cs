using Clinica.Dominio.Contratos;
using Clinica.Dominio.Contratos.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Infra.Data.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        // *Conforme especificado no exercicio, o tratamento dos dados aqui é simulado via MOCK de dados.

        public void Atualizar(TEntity obj)
        {
            // MOCK * Atualizar registro
        }

        public void Cadastrar(TEntity obj)
        {
            // MOCK * Cadastrar regristro
        }

        public void Dispose()
        {
            /// Dispose
        }

        public List<TEntity> RetornaTodos()
        {
            // MOCK * Retornar todos registros
            List<TEntity> lista = new List<TEntity>();
            return lista;

        }

        public TEntity RetornaPorId(int id)
        {
            // MOCK * Retornar registro null 
            return null;
        }

        public void Remover(TEntity obj)
        {
            // MOCK * Remover registro
        }
    }
}
