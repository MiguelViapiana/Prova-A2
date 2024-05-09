using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Arnaldo.Miguel.Models;

public class Folha
{

    public string? folhaId { get; set; }
    public double Valor { get; set; }
    public double Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public double salarioBruto { get; set; }

    public double impostoIrrf { get; set; }

    public double impostoInss { get; set; }

    public double impostoFgts { get; set; }

    public double salarioLiquido { get; set; }

    public String FuncId { get; set; }
    public Funcionario? Funcionario { get; set; }



    public Folha(double valor, double quantidade, int mes, int ano, String funcId)
    {
        folhaId = Guid.NewGuid().ToString();
        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
        FuncId = funcId;
        salarioBruto = valor * quantidade;
        calcSalario();

    }

    public void calcSalario(){
        if (salarioBruto <= 1903.98)
        {
            impostoIrrf = 0.00;
        }
        else if (salarioBruto <= 2826.65)
        {
            impostoIrrf = (salarioBruto/100) * 7.50;
        }
        else if (salarioBruto <= 3751.05)
        {
            impostoIrrf = (salarioBruto/100) * 15;
        }
        else if (salarioBruto <= 4664.68)
        {
            impostoIrrf = (salarioBruto/100) * 22.5;
        }
        else
        {
            impostoIrrf = (salarioBruto/100) * 27.5;
        }

        if (salarioBruto >= 1693.72)
        {
            impostoInss = (salarioBruto/100) * 8;
        }
        else if (salarioBruto <= 2822.90)
        {
            impostoInss = (salarioBruto/100) * 9;
        }
        else if (salarioBruto <= 5645.80)
        {
            impostoInss = (salarioBruto/100) * 11;
        }
        else
        {
            impostoInss = 621.03;
        }

        impostoFgts = (salarioBruto/100) * 8;

        salarioLiquido = (salarioBruto - impostoFgts) - (impostoInss + impostoIrrf);
    }
}


