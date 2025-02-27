using API_Filmes_senai.Context;
using API_Filmes_senai.Interfaces;
using API_Filmes_senai.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Filmes_Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();

builder.Services.AddDbContext<Filmes_Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



