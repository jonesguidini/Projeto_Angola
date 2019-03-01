using Clinica.Dominio.Contratos.Repositores;
using Clinica.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Infra.Data.Repositorios
{
    public class MassagemRepositorio : RepositorioBase<Dominio.Entidades.Massagem>, IMassagemRepositorio
    {

        private readonly IClienteRepositorio _clienteRepositorio;

        public MassagemRepositorio(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        
        public new List<Massagem> RetornaTodos()
        {
            var dataRef = DateTime.Now;

            return new List<Massagem>
            {
                new Massagem
                {
                    CodCliente = 2, // <-
                    CodMassagem = 1,
                    DataHoraMassagem = new DateTime(2019, dataRef.Month, dataRef.AddDays(2).Day, 15, 30, 00),
                    Duracao = 60,
                    Cliente = _clienteRepositorio.RetornaPorId(2) // para fins de MOCK definir aqui o mesmo id do CodCliente
                },
                new Massagem
                {
                    CodCliente = 1, // <-
                    CodMassagem = 2,
                    DataHoraMassagem = new DateTime(2019, dataRef.Month, dataRef.AddDays(3).Day, 16, 00, 00),
                    Duracao = 30,
                    Cliente = _clienteRepositorio.RetornaPorId(1) // para fins de MOCK definir aqui o mesmo id do CodCliente
                },
                new Massagem
                {
                    CodCliente = 2, // <-
                    CodMassagem = 3,
                    DataHoraMassagem = new DateTime(2019, dataRef.Month, dataRef.AddDays(1).Day, 15, 30, 00),
                    Duracao = 60,
                    Cliente = _clienteRepositorio.RetornaPorId(2) // para fins de MOCK definir aqui o mesmo id do CodCliente
                },
                new Massagem
                {
                    CodCliente = 4, // <-
                    CodMassagem = 4,
                    DataHoraMassagem = new DateTime(2019, dataRef.Month, dataRef.AddDays(0).Day, 09, 00, 00),
                    Duracao = 30,
                    Cliente = _clienteRepositorio.RetornaPorId(4) // para fins de MOCK definir aqui o mesmo id do CodCliente
                },
                new Massagem
                {
                    CodCliente = 5, // <-
                    CodMassagem = 5,
                    DataHoraMassagem = new DateTime(2019, dataRef.Month, dataRef.AddDays(4).Day, 11, 30, 00),
                    Duracao = 60,
                    Cliente = _clienteRepositorio.RetornaPorId(5) // para fins de MOCK definir aqui o mesmo id do CodCliente
                },
                new Massagem
                {
                    CodCliente = 7, // <-
                    CodMassagem = 6,
                    DataHoraMassagem = new DateTime(2019, dataRef.Month, dataRef.AddDays(1).Day, 14, 00, 00),
                    Duracao = 60,
                    Cliente = _clienteRepositorio.RetornaPorId(7) // para fins de MOCK definir aqui o mesmo id do CodCliente
                },
                new Massagem
                {
                    CodCliente = 9, // <-
                    CodMassagem = 7,
                    DataHoraMassagem = new DateTime(2019, dataRef.Month, dataRef.AddDays(2).Day, 15, 00, 00),
                    Duracao = 60,
                    Cliente = _clienteRepositorio.RetornaPorId(9) // para fins de MOCK definir aqui o mesmo id do CodCliente
                },
                new Massagem
                {
                    CodCliente = 10, // <-
                    CodMassagem = 8,
                    DataHoraMassagem = new DateTime(2019, dataRef.Month, dataRef.AddDays(3).Day, 08, 30, 00),
                    Duracao = 30,
                    Cliente = _clienteRepositorio.RetornaPorId(10) // para fins de MOCK definir aqui o mesmo id do CodCliente
                },
                new Massagem
                {
                    CodCliente = 1, // <-
                    CodMassagem = 9,
                    DataHoraMassagem = new DateTime(2019, dataRef.Month, dataRef.AddDays(1).Day, 15, 30, 00),
                    Duracao = 60,
                    Cliente = _clienteRepositorio.RetornaPorId(1) // para fins de MOCK definir aqui o mesmo id do CodCliente
                },
                new Massagem
                {
                    CodCliente = 6, // <-
                    CodMassagem = 10,
                    DataHoraMassagem = new DateTime(2019, dataRef.Month, dataRef.AddDays(0).Day, 15, 30, 00),
                    Duracao = 30,
                    Cliente = _clienteRepositorio.RetornaPorId(6) // para fins de MOCK definir aqui o mesmo id do CodCliente
                },
            };
        }


        public new Massagem RetornaPorId(int codMassagem)
        {
            return RetornaTodos().Find(x => x.CodMassagem == codMassagem);
        }


        public List<Massagem> RetornaMassagemsPorCliente(int codCliente)
        {
            return RetornaTodos().FindAll(x => x.CodCliente == codCliente);
        }
    }
}
