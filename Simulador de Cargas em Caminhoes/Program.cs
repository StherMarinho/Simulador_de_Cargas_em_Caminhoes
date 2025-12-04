using Simulador_de_Cargas_em_Caminhoes.Repositories;
using Simulador_de_Cargas_em_Caminhoes.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CaminhaoRepository>();
builder.Services.AddScoped<CargaRepository>();
builder.Services.AddScoped<CaminhaoService>();
builder.Services.AddScoped<CargaService>();
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
