using Fisica.Dados;
using Fisica.Dados.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.SetupDbContext(builder.Configuration.GetValue<string>("ConnectionStrings:DbContext"));
builder.Services.SetupRepositories();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());



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

app.Services.CreateScope().ServiceProvider.GetRequiredService<FisicaDbContext>().Database.Migrate();

app.Run();
