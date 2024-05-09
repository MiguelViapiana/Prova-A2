using System.ComponentModel.DataAnnotations;

namespace Arnaldo.Miguel.Models;

public class Funcionario
{

    public Funcionario(String nome, string cpf){
        this.Nome = nome;
        this.Cpf = cpf;
        this.funcionarioId = Guid.NewGuid().ToString();
    }
    public string? funcionarioId { get; set; }
    public string? Nome { get; set; }
    public string Cpf { get; set; }



}