using Microsoft.EntityFrameworkCore;
using PasswordManager.Api.Middlewares;
using PasswordManager.Api.Repositories;
using PasswordManager.Api.Repositories.Context;
using PasswordManager.Api.Repositories.Interfaces;
using PasswordManager.Api.Services;
using PasswordManager.Api.Services.Interfaces;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Register services to the container
builder.Services.AddDbContext<PasswordManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services to the container
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

// Register controllers to the container
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// Register middlewares to the HTTP pipeline
//app.UseMiddleware<ApiKeyMiddleware>();

// Configuration of the HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Configuration of the HTTPS redirection
app.UseHttpsRedirection();

// Map controllers to the HTTP pipeline
app.MapControllers();

app.Run();