using System;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Netflix_Faker.Application.Services;
using Netflix_Faker.Domain.Interfaces;
using Netflix_Faker.Domain.Interfaces.Repositories;
using Netflix_Faker.Infrastructure.Data;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// services 
builder.Services.AddTransient<IBlobService, BlobService>();
builder.Services.AddTransient<ICatalogoRepository, CatalogoRepository>();


// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

// Configuração do banco de dados (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=NetflixFakerDb;User Id=sa;Password=P@55w0rd;TrustServerCertificate=True;")
);

builder.Build().Run();
