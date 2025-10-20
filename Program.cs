using TesteDeMesa3;

public class Program
{

    public static void Main(string[] args)
    {
        String escolha; int questao; float valorInicial; float taxa; float periodoAno; float periodoMes; float periodoDia; float periodoTotal;
        float valorResgateMensal=0; String escolhaFinal = ""; int mes; List<float> rendimentos = new List<float>();
        List<int> resgateMensal = new List<int>();
        List<float> valorFinal;
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
                Console.Write("Deseja resgatar alguma quantia antes da finalização: S - sim | N - não");
                escolha = Console.ReadLine();
                if(escolha == "S")
                {
                    Console.WriteLine("Informe o valor de resgate: ");
                    escolha = Console.ReadLine();
                    float.TryParse(escolha, out valorResgateMensal);
                    Console.WriteLine("Informe os meses que deseja resgatar um valor: ");
                    while (escolhaFinal != "N")
                    {

                        Console.Write($"Digite um número entre {periodoTotal:F2}: ");
                        escolha = Console.ReadLine();
                        int.TryParse(escolha, out mes);
                        resgateMensal.Add(mes);
                        Console.Write("\nDeseja resgatar algum valor em mais um mês: S - sim | N - não");
                        escolhaFinal=Console.ReadLine();
                    }
                }
                
                rendimentos=calc.calcularJurosComResgate(valorInicial, taxa, periodoTotal, resgateMensal, valorResgateMensal);
                calc.calcularRendimentoMensal(valorInicial, calc.rendimentoBrutoTotal());
                Console.Clear();
                for(int i=0; i<periodoTotal; i++)
                {
                    Console.Write("\n\n\n");
                    Console.WriteLine($"-------------------------ESTATISTICAS MÊS {i+1}-------------------------");
                    if (resgateMensal.Contains(i))
                    {
                        Console.WriteLine($"Valor Inicial: R${(valorInicial - valorResgateMensal):F2}");
                        valorInicial -= valorResgateMensal;
                    }
                    else
                    {
                        Console.WriteLine($"Valor Inicial: R${valorInicial:F2}");
                    }

                    Console.WriteLine($"Porcentagem da taxa: %{taxa * 100}");
                    Console.WriteLine($"Rendimento bruto: R${rendimentos[i]:F2}");
                 
                }
                break;

            default:
                break;

        }

    }
}