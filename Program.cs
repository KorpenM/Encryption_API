using EncryptionAPI; 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// L�gger till support f�r controllers och dependency injection
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// L�gg till Encryptor i DI-container
builder.Services.AddScoped<Encryptor>();

var app = builder.Build();

// Anv�nder Swagger f�r utvecklingsmilj�
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mappar controllers (f�r att endpoints ska fungera)
app.MapControllers();

app.Run();
