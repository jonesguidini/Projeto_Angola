using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.Entidades.Dto
{
    public class MassagemDto
    {
        public int CodCliente { get; set; }
        public int CodMassagem { get; set; }
        public DateTime DataHoraMassagem { get; set; }
        public int Duracao { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
