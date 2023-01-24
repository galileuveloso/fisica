using FisicaUsuario.Classes;
using FisicaUsuario.Dados.Repositories;
using FisicaUsuario.Interfaces;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IRepository<Favorito>), typeof(Repository<Favorito>));
builder.Services.AddScoped(typeof(IRepository<Instituicao>), typeof(Repository<Instituicao>));
builder.Services.AddScoped(typeof(IRepository<Perfil>), typeof(Repository<Perfil>));
builder.Services.AddScoped(typeof(IRepository<Usuario>), typeof(Repository<Usuario>));
builder.Services.AddScoped(typeof(IRepository<Widget>), typeof(Repository<Widget>));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
