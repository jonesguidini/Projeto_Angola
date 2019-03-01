using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefeitoRua
{
    class Program
    {
        static void Main(string[] args)
        {
            // mock de registro de ruas
            Rua rua1 = new Rua("11111-111","Rua Andrades Lopes");
            Rua rua2 = new Rua("22222-222", "Rua Coronel Castilho");
            Rua rua3 = new Rua("33333-333", "Rua Primaveras");

            // mock de registro de casas
            List<Casa> listaCasas = new List<Casa>() { 
                new Casa(rua1, 10, 3), // Rua, Numero Casa, Total de Eleitores
                new Casa(rua1, 3, 3), // Rua, Numero Casa, Total de Eleitores
                new Casa(rua2, 7, 7), // Rua, Numero Casa, Total de Eleitores
                new Casa(rua3, 1, 2), // Rua, Numero Casa, Total de Eleitores
                new Casa(rua3, 2, 3), // Rua, Numero Casa, Total de Eleitores
            };

            var ruas = RetornaRuas(listaCasas);

            Console.WriteLine("LISTA DE RUAS - QTD de VOTOS");
            foreach (var rua in ruas)
            {
                Console.WriteLine(string.Format("Rua '{0}' contém {1} votos.", rua.Key, rua.Value));
            }

            Console.ReadKey();
        }

        public static Dictionary<string, int> RetornaRuas(List<Casa> casas)
        {
            Dictionary<string, int> ruas = new Dictionary<string, int>();

            // percorre todas casas
            casas.ForEach(casa =>
            {
                //se não houver registro de rua
                if (!ruas.ContainsKey(casa.rua.nome))
                {
                    //... cria novo indice no dicionario com o valor total da casas
                    ruas.Add(casa.rua.nome, casa.totalEleitores);
                }
                else //se houver registro de rua
                {
                    //identifica a rua
                    var rua = ruas.Where(x => x.Key == casa.rua.nome).FirstOrDefault().Key;
                    //atualiza o total de eleitores da rua
                    ruas[rua] += casa.totalEleitores;
                }
            });

            // retorna lista de ruas ordenada pela quantidade de votos por casa
            return ruas.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

    }
}
