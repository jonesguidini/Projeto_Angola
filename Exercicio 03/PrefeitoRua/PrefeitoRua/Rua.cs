using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefeitoRua
{
    public class Rua
    {
        public Rua(string cep, string nome)
        {
            this.cep = cep;
            this.nome = nome;
        }

        public string cep { get; set; }

        public string nome { get; set; }
    }

}
