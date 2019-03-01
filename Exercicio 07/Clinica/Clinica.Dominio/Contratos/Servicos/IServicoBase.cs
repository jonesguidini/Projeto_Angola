using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Contratos.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        void Cadastrar(TEntity obj);

        TEntity RetornaPorId(int id);

        List<TEntity> RetornaTodos();

        void Remover(TEntity obj);

        void Atualizar(TEntity obj);

        void Salvar();

        void Dispose();
    }
}
