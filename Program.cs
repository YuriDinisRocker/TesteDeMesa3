using TesteDeMesa3;

public class Program
{

    public static void Main(string[] args)
    {
        string escolha, escolhaFinal = "";
        int questao, mes, idResgate=0;
        float valorInicial, taxa, periodoAno, periodoMes, periodoDia, periodoTotal, valorDeResgate=0, checarComprimento = 0;
        List<float> valorResgateMensal= new List<float>(), rendimentos = new List<float>(); List<int> resgateMensal = new List<int>();
        Calculo calc=new Calculo();

        Console.WriteLine("TESTE DE MESA 3");
        Console.Write("1 - atividade 1 | 2 - atividade 2: ");
        escolha = Console.ReadLine();
        int.TryParse(escolha, out questao);
        switch (questao)
        {
            case 1:
                Console.Write("QUESTÃO 1:\nInforme o valor inicial do investimento:");
                escolha=Console.ReadLine();
                float.TryParse(escolha, out valorInicial);

                Console.Write("\nInforme a quantidade de anos que o investimento se manterá:");
                escolha = Console.ReadLine();
                float.TryParse(escolha, out periodoAno);

                Console.Write("\nInforme a quantidade de meses que o investimento se manterá:");
                escolha = Console.ReadLine();
                float.TryParse(escolha, out periodoMes);

                Console.Write("\nInforme a quantidade de dias que o investimento se manterá:");
                escolha = Console.ReadLine();
                float.TryParse(escolha, out periodoDia);

                Console.Write("\nInforme a taxa de juros: ");
                escolha = Console.ReadLine();
                float.TryParse(escolha, out taxa);

                Console.WriteLine("\nA taxa está em formato: A - anual | M - mensal | D - diario ");
                escolha = Console.ReadLine();

                if(escolha == "A")
                {
                    taxa /= 12;
                    taxa /= 100;
                }else if(escolha == "M")
                {
                    taxa /= 100;
                }
                else
                {
                    taxa *=30;
                    taxa /= 100;
                }

                periodoTotal=calc.converterData(periodoAno, periodoMes, periodoDia);
                
                calc.calcularJurosSemResgate(valorInicial, taxa, periodoTotal);
                calc.calcularRendimentoMensal(valorInicial, calc.rendimentoBrutoTotal());
                Console.Clear();
                Console.WriteLine($"Valor Inicial: R${valorInicial}");
                Console.WriteLine($"Porcentagem da taxa: %{taxa * 100}");
                Console.WriteLine($"Periodo e investimento de {periodoAno} - Anos | {periodoMes} - Meses | {periodoDia} - Dias");
                Console.WriteLine($"Rendimento bruto: R${calc.rendimentoBrutoTotal():F2}");
                Console.WriteLine($"Rendimento líquido total: R${calc.rendimentoLiquidoTotal():F2}");

                calc.limparListas();
                break;

            case 2:
                Console.Write("QUESTÃO 2:\nInforme o valor inicial do investimento:");
                escolha = Console.ReadLine();
                float.TryParse(escolha, out valorInicial);
                Console.Write("\nInforme a quantidade de anos que o investimento se manterá:");
                escolha = Console.ReadLine();
                float.TryParse(escolha, out periodoAno);
                Console.Write("\nInforme a quantidade de meses que o investimento se manterá:");
                escolha = Console.ReadLine();
                float.TryParse(escolha, out periodoMes);
                Console.Write("\nInforme a quantidade de dias que o investimento se manterá:");
                escolha = Console.ReadLine();
                float.TryParse(escolha, out periodoDia);
                Console.Write("\nInforme a taxa de juros: ");
                escolha = Console.ReadLine();
                float.TryParse(escolha, out taxa);
                Console.WriteLine("\nA taxa está em formato: A - anual | M - mensal | D - diario ");
                escolha = Console.ReadLine();
                if (escolha == "A")
                {
                    taxa /= 12;
                    taxa /= 100;
                }
                else if (escolha == "M")
                {
                    taxa /= 100;
                }
                else
                {
                    taxa *= 30;
                    taxa /= 100;
                }
                periodoTotal = calc.converterData(periodoAno, periodoMes, periodoDia);
                Console.Write("Deseja resgatar alguma quantia antes da finalização: S - sim | N - não ");
                escolha = Console.ReadLine();
                if(escolha == "S")
                {
                    
                    while (escolhaFinal != "N")
                    {
                        Console.WriteLine("Informe o valor de resgate: ");
                        escolha = Console.ReadLine();
                        if (float.TryParse(escolha, out valorDeResgate)) valorResgateMensal.Add(valorDeResgate);
                        Console.WriteLine("Informe os meses que deseja resgatar um valor: ");
                        Console.Write($"Digite um mes entre 1 e {Math.Ceiling(periodoTotal)}: ");
                        escolha = Console.ReadLine();
                        int.TryParse(escolha, out mes);
                        resgateMensal.Add(mes);
                        Console.Write("\nDeseja resgatar algum valor em mais um mês: S - sim | N - não ");
                        escolhaFinal=Console.ReadLine();
                    }
                }
                
                rendimentos=calc.calcularJurosComResgate(valorInicial, taxa, periodoTotal, resgateMensal, valorResgateMensal);
                calc.calcularRendimentoMensal(valorInicial, calc.rendimentoBrutoTotal());
                Console.Clear();
                if (periodoTotal % 1 > 0)
                {
                    checarComprimento = 1;
                }
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine($" {"MÊS",-5} | {"VALOR INICIAL",-13} | {"TAXA (%)",-8} | {"REND. BRUTO",-11} | {"RESGATE",-9}");
                Console.WriteLine("---------------------------------------------------------------------------------");
                for (int i=1; i<=periodoTotal+checarComprimento; i++)
                {
                    valorDeResgate = 0;
                    if (i > 1)
                    {
                        valorInicial = rendimentos[i - 1];
                    }
                    if (resgateMensal.Contains(i))
                    {
                        
                        int index = resgateMensal.IndexOf(i);
                        if (index < valorResgateMensal.Count())
                        {
                            valorDeResgate = valorResgateMensal[index];
                            valorInicial -= valorDeResgate;
                        }
                        
                    } 
                    Console.WriteLine($" {i,-5} | R${valorInicial,-11:F2} | {taxa * 100,-7:F2} | R${rendimentos[i],-10:F2} | R${valorDeResgate, -8:F2}");
                    
                }
               
                break;

            default:
                break;

        }

    }
}