using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMercado
{
    public static class DT
    {
        public static double formulaMagica(double custo, int validade)
        {

            // define valor com lucro inicialmente com valor do custo inicial
            double valorComLucro = custo;

            // define valor inicial de 0 (%) mas esta variável será atualizada abaixo conforme a validade informada
            double porcentagemLucro = 0.0;

            // REGRAS *Custo do produto vai variar conforme o prazo de validade
            // Para produtos com validade de 90 dias para vencer o acrescentar lucro de 82%
            if (validade >= 90)
                porcentagemLucro = 82.0;
            // Para produtos com validade de 60 a 90 dias para vencer o acrescentar lucro de 70%
            else if (validade >= 60 && validade < 90)
                porcentagemLucro = 70.0;
            // Para produtos com validade de 30 a 60 dias para vencer o acrescentar lucro de 50%
            else if (validade >= 30 && validade < 60)
                porcentagemLucro = 50.0;
            // Para produtos com validade de 15 a 30 dias para vencer o acrescentar lucro de 35%
            else if (validade >= 15 && validade < 30)
                porcentagemLucro = 35.0;
            // Para produtos com validade de 5 a 15 dias para vencer o acrescentar lucro de 25%
            else if (validade >= 5 && validade < 15)
                porcentagemLucro = 25.0;
            // Para produtos com validade de 1 a 5 dias para vencer o acrescentar lucro de 10%
            else if (validade >= 1 && validade < 5)
                porcentagemLucro = 10.0;

            //calcula o valor com lucro baseado na validade
            valorComLucro += (porcentagemLucro / 100.0) * valorComLucro;

            // arredonda o valor para até duas casas decimais depois da virgula
            return Math.Round(valorComLucro, 2);
        }
    }
}
