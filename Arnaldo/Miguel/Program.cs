
using Arnaldo.Miguel.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

app.MapPost("/folha/cadastrar/{id}", ([FromBody] Folha folha, [FromServices] AppDbContext ctx, [FromRoute] string id)=>
{
                ctx.Folhas.Add(folha);
                ctx.SaveChanges();
                return Results.Created();
            

});

app.MapGet("/folha/listar/", ([FromServices] AppDbContext ctx)=>
{   
    if (ctx.Folhas.Any()){
        return Results.Ok(ctx.Folhas.ToList());
    }
    return Results.NotFound();
    
        
    
});

app.Run();
