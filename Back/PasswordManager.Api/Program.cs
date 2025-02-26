using Microsoft.EntityFrameworkCore;
using PasswordManager.Api.Repositories.Context;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Register services to the container
builder.Services.AddDbContext<PasswordManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configuration of the HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Configuration of the HTTPS redirection
app.UseHttpsRedirection();


app.Run();