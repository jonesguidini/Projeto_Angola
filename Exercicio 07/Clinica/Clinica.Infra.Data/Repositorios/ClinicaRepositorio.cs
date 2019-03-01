using Clinica.Dominio.Contratos;
using Clinica.Dominio.Contratos.Repositores;
using Clinica.Dominio.Entidades;
using Clinica.Dominio.Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Infra.Data.Repositorios
{
    public class ClinicaRepositorio : RepositorioBase<Dominio.Entidades.Clinica>, IClinicaRepositorio
    {

        public new Dominio.Entidades.Clinica RetornaPorId(int codClinica)
        {
            return new Dominio.Entidades.Clinica()
            {
                CodClinica = 1,
                CNPJ = "111.111.111/0001-11",
                Endereco = "Rua 01, Casa 01, Quadra 01, Brasilia-DF",
                RazaoSocial = "Razão Social Clinica 01",
                Telefone = "(61) 11111-1111"
            };
        }

    }
}
