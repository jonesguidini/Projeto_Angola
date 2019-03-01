using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Entidades
{
    public class Cliente
    {
        public int CodClinica { get; set; }
        public int CodCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }

        public virtual Clinica Clinica { get; set; }
        public virtual IEnumerable<Massagem> Massagens{ get; set; }
    }
}
