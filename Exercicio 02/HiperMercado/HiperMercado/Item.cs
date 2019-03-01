using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMercado
{
    public class Item
    {

        //construtor vazio
        public Item()
        {

        }

        // construtor com parametros
        public Item(string produto,
            double custoAquisicao,
            double volumeOcupado,
            bool necessidadeRefrigeracao,
            bool riscoValidadeExpirar,
            int validade)
        {
            Produto = produto;
            CustoAquisicao = custoAquisicao;
            VolumeOcupado = volumeOcupado;
            NecessidadeRefrigeracao = necessidadeRefrigeracao;
            RiscoValidadeExpirar = riscoValidadeExpirar;
            Validade = validade;
        }

        public string Produto { get; set; }
        public double CustoAquisicao { get; set; }
        public double VolumeOcupado { get; set; }
        public bool NecessidadeRefrigeracao { get; set; }
        public bool RiscoValidadeExpirar { get; set; }
        public int Validade { get; set; }
        public double Custo
        {
            get
            {
                // VOLUME OCUPADO (em centimentos)
                // se o volume ocupado for menor do que 100cm² então acrescenta 15% em cima do custo do produto
                // se o volume ocupado for maio do que cm² então acrescenta uma 25% em cima do custo do produto
                var custoFinal = VolumeOcupado < 100 ? CustoAquisicao + (15.0 / 100.0 * CustoAquisicao) : CustoAquisicao + (25.0 / 100.0 * CustoAquisicao);

                // NECESSIDA DE REFRIGERAÇÃO 
                // se precisar de refrigeração (true) então acrescenta 8% em cima do custo do produto
                // se não precisar não acrescenta nada
                custoFinal = NecessidadeRefrigeracao ? custoFinal + (8.0 / 100.0 * custoFinal) : custoFinal;

                // RISCO VALIDADE EXPIRAR
                // se houver risco de validade a expirar (true) então acrescenta 12,5% em cima do custo do produto
                // se não precisar não acrescenta nada
                custoFinal = RiscoValidadeExpirar ? custoFinal + (12.5 / 100.0 * custoFinal) : custoFinal;

                // Outras regras para gerar o custo do produto...
                return custoFinal;
            }
        }

    }
}
