using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Entidades
{
    public class Clinica
    {
        public int CodClinica { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public virtual IEnumerable<Cliente> Clientes { get; set; }
    }
}
