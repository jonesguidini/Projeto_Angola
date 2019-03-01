using Clinica.Dominio.Contratos.Repositores;
using Clinica.Dominio.Contratos.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Servicos
{
    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {

        private readonly IRepositorioBase<TEntity> _repositorio;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Atualizar(TEntity obj)
        {
            _repositorio.Atualizar(obj);
        }

        public void Cadastrar(TEntity obj)
        {
            _repositorio.Cadastrar(obj);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public List<TEntity> RetornaTodos()
        {
            return _repositorio.RetornaTodos();
        }

        public TEntity RetornaPorId(int id)
        {
            return _repositorio.RetornaPorId(id);
        }

        public void Remover(TEntity obj)
        {
            _repositorio.Remover(obj);
        }

        public virtual void Salvar()
        {
            // Para ser implementado dentro de cada Service
        }
    }
}
