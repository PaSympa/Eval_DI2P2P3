using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Api.Encryption.EncryptionStrategies;
using PasswordManager.Api.Middlewares;
using PasswordManager.Api.Repositories;
using PasswordManager.Api.Repositories.Context;
using PasswordManager.Api.Repositories.Interfaces;
using PasswordManager.Api.Services;
using PasswordManager.Api.Services.Interfaces;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Load RSA key from file
string rsaKeyFile = Path.Combine(AppContext.BaseDirectory, "rsaKey.pem");

var rsa = RSA.Create(2048);

if (File.Exists(rsaKeyFile))
{
    // Load the existing RSA key from file
    string pem = File.ReadAllText(rsaKeyFile);
    rsa.ImportFromPem(pem.ToCharArray());
}
else
{
    // Generate a new RSA key and export it to PEM format
    string pem = ExportPrivateKeyToPem(rsa);
    File.WriteAllText(rsaKeyFile, pem);
}

// Register services to the container
builder.Services.AddDbContext<PasswordManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services to the container
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

builder.Services.AddSingleton(rsa);

// Register encryption strategies to the container
builder.Services.AddSingleton<RsaEncryptionStrategy>(sp =>
{
    var sharedRsa = sp.GetRequiredService<RSA>();
    return new RsaEncryptionStrategy(sharedRsa);
});
builder.Services.AddSingleton<AesEncryptionStrategy>();

// Add CORS policy for Angular development
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Register controllers to the container
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("AllowAngularDev");
app.UseMiddleware<ApiKeyMiddleware>();

// Configuration of the HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.MapScalarApiReference();
}

// Configuration of the HTTPS redirection
app.UseHttpsRedirection();

// Map controllers to the HTTP pipeline
app.MapControllers();

app.Run();


static string ExportPrivateKeyToPem(RSA rsa)
{
    byte[] privateKeyBytes = rsa.ExportRSAPrivateKey();
    string base64 = Convert.ToBase64String(privateKeyBytes);
    var sb = new StringBuilder();
    sb.AppendLine("-----BEGIN RSA PRIVATE KEY-----");
    for (int i = 0; i < base64.Length; i += 64)
    {
        int chunkSize = Math.Min(64, base64.Length - i);
        sb.AppendLine(base64.Substring(i, chunkSize));
    }
    sb.AppendLine("-----END RSA PRIVATE KEY-----");
    return sb.ToString();
}