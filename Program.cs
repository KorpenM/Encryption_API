using EncryptionAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Skapar en instans av EncryptionService med en nyckel
        int key = 3;
        var encryptionService = new EncryptionService(key);

        // Standardroute för att välkomna användare
        app.MapGet("/", () => "Hello World!");

        // Endpoint för kryptering
        app.MapGet("/encrypt", (string input) => encryptionService.Encrypt(input));

        // Endpoint för avkryptering
        app.MapGet("/decrypt", (string input) => encryptionService.Decrypt(input));

        app.Run();
    }
}
