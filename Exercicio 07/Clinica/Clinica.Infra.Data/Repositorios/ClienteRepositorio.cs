using Clinica.Dominio.Contratos.Repositores;
using Clinica.Dominio.Entidades;
using Clinica.Dominio.Entidades.Dto;
using System.Collections.Generic;

namespace Clinica.Infra.Data.Repositorios
{
    public class ClienteRepositorio : RepositorioBase<Dominio.Entidades.Cliente>, IClienteRepositorio
    {

        /// <summary>
        /// Retorna MOCK de Lista de Todos clientes
        /// </summary>
        /// <returns></returns>
        public new List<Cliente> RetornaTodos()
        {
            return new List<Cliente>()
            {
                new Cliente()
                {
                    CodCliente = 1,
                    Nome = "Carlos",
                    Sobrenome = "Alberto de Nobrega",
                    CPF = "888.888.888-88",
                    Endereco = "Rua 8, casa 8, Cidade 8",
                    Celular = "(88) 88888-8888",
                    Telefone = "(88) 8888-8888"
                },

                new Cliente()
                {
                    CodCliente = 2,
                    Nome = "Fausto",
                    Sobrenome = "Silva",
                    CPF = "222.222.222-22",
                    Endereco = "Rua 2, casa 2, Cidade 2",
                    Celular = "(22) 22222-2222",
                    Telefone = "(22) 2222-2222"
                },

                new Cliente()
                {
                    CodCliente = 3,
                    Nome = "Ana",
                    Sobrenome = "Rickman",
                    CPF = "333.333.333-33",
                    Endereco = "Rua 3, casa 3, Cidade 3",
                    Celular = "(33) 33333-3333",
                    Telefone = "(33) 3333-3333"
                },

                new Cliente()
                {
                    CodCliente = 4,
                    Nome = "Claudio",
                    Sobrenome = "Duarte",
                    CPF = "444.444.444-44",
                    Endereco = "Rua 4, casa 4, Cidade 4",
                    Celular = "(44) 44444-4444",
                    Telefone = "(44) 4444-4444"
                },

                new Cliente()
                {
                    CodCliente = 5,
                    Nome = "Neymar",
                    Sobrenome = "Junior de Souza",
                    CPF = "555.555.555-55",
                    Endereco = "Rua 5, casa 5, Cidade 5",
                    Celular = "(55) 55555-5555",
                    Telefone = "(55) 5555-5555"
                },

                new Cliente()
                {
                    CodCliente = 6,
                    Nome = "Pedro",
                    Sobrenome = "Henrique de Almeida",
                    CPF = "666.666.666-66",
                    Endereco = "Rua 6, casa 6, Cidade 6",
                    Celular = "(66) 66666-6666",
                    Telefone = "(66) 6666-6666"
                },

                new Cliente()
                {
                    CodCliente = 7,
                    Nome = "Fernanda",
                    Sobrenome = "Montenegro",
                    CPF = "777.777.777-77",
                    Endereco = "Rua 7, casa 7, Cidade 7",
                    Celular = "(77) 77777-7777",
                    Telefone = "(77) 7777-7777"
                },

                new Cliente()
                {
                    CodCliente = 8,
                    Nome = "Fernando",
                    Sobrenome = "Victor Nobrega",
                    CPF = "888.888.888-88",
                    Endereco = "Rua 8, casa 8, Cidade 8",
                    Celular = "(88) 88888-8888",
                    Telefone = "(88) 8888-8888"
                },

                new Cliente()
                {
                    CodCliente = 9,
                    Nome = "Tulio",
                    Sobrenome = "Maravilha Jogador",
                    CPF = "999.999.999-99",
                    Endereco = "Rua 9, casa 9, Cidade 9",
                    Celular = "(99) 99999-9999",
                    Telefone = "(99) 9999-9999"
                },

                new Cliente()
                {
                    CodCliente = 10,
                    Nome = "Zagallo",
                    Sobrenome = "Filipão",
                    CPF = "000.000.000-00",
                    Endereco = "Rua 10, casa 10, Cidade 10",
                    Celular = "(00) 00000-0000",
                    Telefone = "(00) 0000-0000"
                },

                new Cliente()
                {
                    CodCliente = 11,
                    Nome = "Maria",
                    Sobrenome = "Leticia",
                    CPF = "101.101.101-00",
                    Endereco = "Rua 11, casa 11, Cidade 11",
                    Celular = "(11) 10101-1010",
                    Telefone = "(11) 1010-1010"
                },

            };
        }


        /// <summary>
        /// Retorna MOCK da busca por um Cliente específico
        /// </summary>
        /// <param name="codCliente"></param>
        /// <returns></returns>
        public new Cliente RetornaPorId(int codCliente)
        {
            return RetornaTodos().Find(x => x.CodCliente == codCliente);
        }

        public void AgendarMassagem(MassagemDto massagem)
        {
            // MOCK * Agendar Massagem
        }

        public void CancelarMassagem(int codCliente)
        {
            // MOCK * Cancelar Massagem
        }

        public void ReagendarMassagem(MassagemDto massagem)
        {
            // MOCK * Reagendar Massagem
        }

        public Cliente ConsultarPorNome(string nome)
        {
            return RetornaTodos().Find(x => x.Nome.Contains(nome));
        }
    }
}
