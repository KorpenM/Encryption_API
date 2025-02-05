using EncryptionAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Skapar en instans av EncryptionService med en nyckel
int key = 3;
var encryptionService = new EncryptionService(key);

app.MapGet("/", () => "Tjena kompis!");

app.MapGet("/encrypt", (string input) => encryptionService.Encrypt(input));

app.MapGet("/decrypt", (string input) => encryptionService.Decrypt(input));

app.Run();