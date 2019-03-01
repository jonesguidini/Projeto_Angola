using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMercado
{
    class Program
    {
        static void Main(string[] args)
        {

            Item novoItem = new Item();

            try
            {
                Console.WriteLine("CADASTRO DE PRODUTO");
                Console.WriteLine("Informe o nome do Item:");
                novoItem.Produto = Console.ReadLine().ToString();

                Console.WriteLine("Informe o custo de aquisição:");
                novoItem.CustoAquisicao = Convert.ToDouble(Console.ReadLine().ToString());

                Console.WriteLine("Informe o volume ocupado:");
                novoItem.VolumeOcupado = Convert.ToDouble(Console.ReadLine().ToString());

                Console.WriteLine("Necessita de refrigeração? (V = verdadeiro ou F = falso");
                novoItem.NecessidadeRefrigeracao = Console.ReadLine().ToString().ToUpper() == "V" ? true : false;

                Console.WriteLine("Têm risco de validade para expirar? (V = verdadeiro ou F = falso");
                novoItem.RiscoValidadeExpirar = Console.ReadLine().ToString().ToUpper() == "V" ? true : false;

                Console.WriteLine("Informe validade em dias:");
                novoItem.Validade = Convert.ToInt16(Console.ReadLine().ToString());

                // variável custo é um double definido previamente 
                // variável validade é um int definido previamente 
                double precoFinal = HiperMercado.DT.formulaMagica(novoItem.Custo, novoItem.Validade);

                Console.WriteLine(string.Format("O custo final do produto '{0}' é de R$ {1} "
                , novoItem.Produto
                , precoFinal
                ));

                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Houve algum problema no processo de cadastro do item/produto e não poderemos continuar. Mais detalhes do erro: " + ex.Message);
                Console.ReadKey();
            }
            
        }
    }

   

    
}
