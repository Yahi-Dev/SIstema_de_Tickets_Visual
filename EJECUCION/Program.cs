using Prac4.Servicio;
using Prac4.Verificacion_de_carpetas;
using Prac4.Correo.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions.Common;
using Prac4.Estrategy;
using Prac4.ResolucionEnvio;
using Prac4.WhatsApp;

var builder = WebApplication.CreateBuilder(args);

Verificacion verificar = new Verificacion();
verificar.verificar();



builder.Configuration.AddJsonFile("appsettings.json");

var configuration = builder.Configuration;

var services = builder.Services;

services.AddScoped<MContexto>();

services.AddScoped<IMensajeria, WhatsAppEnvio>();

services.AddScoped<FactoryMensajeria>();
services.AddScoped<MensajeriaEnvia>();

IServiceCollection serviceCollection = services.AddScoped<Prac4.Servicio.Reporte>();

// Inicializando la independencia de la api registro FormatException: Could not parse the JSON file.
builder.Services.AddControllers();

// Registra el servicio RegistroServicio en el contenedor.
builder.Services.AddScoped<RegistroServicio>();

// Inicializando la independencia de la api Inicio de sesion
builder.Services.AddScoped<Prac4.Servicio.InicioSesion>();

// Añade el soporte para Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opcion =>
{
    opcion.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Aqqui termina


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGmailService, GmailService>();
builder.Services.AddSingleton(configuration);

builder.Services.AddCors(opcion =>
{
    opcion.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();