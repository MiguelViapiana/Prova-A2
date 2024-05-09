
using Arnaldo.Miguel.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/", () => "API de funcionários");

app.MapPost("/funcionario/cadastrar/", ([FromBody] Funcionario funcionario, [FromServices] AppDbContext ctx)=>
{   
    Funcionario? funcionarioBuscado = ctx.Funcionarios.FirstOrDefault(x => x.Nome == funcionario.Nome);
    if(funcionarioBuscado is null){
        
        ctx.Funcionarios.Add(funcionario);
        ctx.SaveChanges();
        return Results.Created("", funcionario);
    }
    return Results.BadRequest("Já existe um funcionario igual!!");
});

app.MapGet("/funcionario/listar/", ([FromServices] AppDbContext ctx)=>
{
    if(ctx.Funcionarios.Any()){
        return Results.Ok(ctx.Funcionarios.ToList());
    }
    return Results.NotFound("Não existe funcionarios cadastrados!");
});

app.MapPost("/folha/cadastrar/", ([FromBody] Folha folha, [FromServices] AppDbContext ctx)=>
{   
    Funcionario? funcionario = ctx.Funcionarios.Find(folha.FuncId);
    if(funcionario is null){
        return Results.NotFound();
    }
    folha.Funcionario = funcionario;
    ctx.Folhas.Add(folha);
    ctx.SaveChanges();
    return Results.Created("", folha);
});

app.MapGet("/folha/listar/", ([FromServices] AppDbContext ctx)=>
{
    if (ctx.Folhas.Any()){
        return Results.Ok(ctx.Folhas.ToList());
    }
    return Results.BadRequest();
});

app.MapGet("/folha/buscar/{mes}/{ano}", ([FromRoute] int mes, int ano, [FromServices] AppDbContext ctx)=>
{
    Folha folha = ctx.Folhas.FirstOrDefault(f => f.Mes == mes && f.Ano == ano);
    if (folha == null){
            return Results.NotFound("Folha não encontrado");
        }
        return Results.Ok(folha);

});

app.Run();
