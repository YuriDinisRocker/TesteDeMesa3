using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TesteDeMesa3
{
    internal class Calculo
    {
        private float valorInicial, periodo, valorFinal, taxa;
        private List<float> rendimentosMensais = new List<float>(), valoresRendimentos = new List<float>();
         

        public Calculo()
        {

        }

        public List<float> calcularJurosSemResgate(float valorInicial, float taxa, float periodo)
        {
            this.valorInicial = valorInicial; this.taxa = taxa; this.periodo = periodo; float periodoCount = 0;
            this.valoresRendimentos.Add(this.valorInicial);
            for (int i=1; i<=(int)periodo; i++)
            {
                if(this.periodo - (float)i == 0)
                {
                    periodoCount = this.periodo;
                }
                else
                {
                    periodoCount = this.periodo - (this.periodo - (float)i);
                }

                float resultado = this.valorInicial * (float)Math.Pow((1 + this.taxa), periodoCount);
                this.valorFinal = resultado;
                this.valoresRendimentos.Add(this.valorFinal);
            }
            float resto = this.periodo - (int)this.periodo;
            if (resto > 0)
            {
                float resultadoFinal = this.valorInicial * MathF.Pow(1 + this.taxa, this.periodo);
                this.valorFinal = resultadoFinal;
                this.valoresRendimentos.Add(this.valorFinal);
            }
            return valoresRendimentos;
        }
        
        ////////////////////////////////////////////////////

        public List<float> calcularJurosComResgate(float valorInicial, float taxa, float periodo, List<int> periodoResgate, List<float> resgate)
        {
            this.valorInicial = valorInicial; this.taxa = taxa; this.periodo = periodo; float periodoCount = 0;
            this.valoresRendimentos.Add(this.valorInicial);
            int id = 0; int idResgate = 0;
            for (int i = 1; i <= (int)periodo; i++)
            {
                id++;

                if (periodoResgate.Contains(i))
                {
                    id = 1;
                    this.valorInicial = this.valorFinal - resgate[idResgate];
                    idResgate++;
                }

                periodoCount = id;

                float resultado = this.valorInicial *   MathF.Pow((1 + this.taxa), periodoCount);
                this.valorFinal = resultado;
                this.valoresRendimentos.Add(this.valorFinal);
            }
            float resto = this.periodo - (int)this.periodo;
            if (resto > 0)
            {
                float resultadoFinal = this.valorInicial * MathF.Pow(1 + this.taxa, this.periodo);
                this.valorFinal = resultadoFinal;
                this.valoresRendimentos.Add(this.valorFinal);
            }
            return valoresRendimentos;
        }

        //////////////////////////////////////////////////////////

        public List<float> calcularRendimentoMensal(float valorInicial, float valorFinal)
        {
            for(int i=0; i < (this.valoresRendimentos.Count() -1 ); i++)
            {
                float rendimentoMensal = valoresRendimentos[i + 1] - valoresRendimentos[i];
                rendimentosMensais.Add(rendimentoMensal);
            }
            return rendimentosMensais;

        }

        public float converterData(float ano, float mes, float dia)
        {
            float calculoAno = ano * 12;
            float calculoDia = dia / 30;
            float res = calculoAno + calculoDia + mes;
            return res;
        }

        public float rendimentoBrutoTotal()
        {
            return valoresRendimentos.Last();
        }

        public float rendimentoLiquidoTotal()
        {
            return rendimentosMensais.Sum();
        }

        public float getValorInicial()
        {
            return this.valorInicial;
        }
        public void limparListas()
        {
            rendimentosMensais.Clear();
            valoresRendimentos.Clear();
        }
    }
}
