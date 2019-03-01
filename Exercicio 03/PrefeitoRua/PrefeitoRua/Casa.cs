using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefeitoRua
{
    public class Casa
    {

        public Casa(Rua rua, int numero, int totalEleitores)
        {
            this.rua = rua;
            this.numero = numero;
            this.totalEleitores = totalEleitores;
        }

        public Rua rua { get; set; }
        public int numero { get; set; }
        public int totalEleitores { get; set; }
    }

}
