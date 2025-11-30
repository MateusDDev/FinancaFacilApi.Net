using Fiap.Api.FinancaFacil.Data.Contexts;
using Fiap.Api.FinancaFacil.Data.Repository;
using Fiap.Api.FinancaFacil.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Banco de dados

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging()
);

#endregion

#region Repositorios

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

#endregion

#region Services

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

#endregion


#region AutoMapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
