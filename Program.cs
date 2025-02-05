using EncryptionAPI; 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Lägger till support för controllers och dependency injection
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Lägg till Encryptor i DI-container
builder.Services.AddScoped<Encryptor>();

var app = builder.Build();

// Använder Swagger för utvecklingsmiljö
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mappar controllers (för att endpoints ska fungera)
app.MapControllers();

app.Run();
