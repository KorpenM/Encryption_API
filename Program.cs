var builder = WebApplication.CreateBuilder(args);

// Lägg till support för controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Använd Swagger (API-dokumentation)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mappar controllers (gör att våra endpoints fungerar)
app.MapControllers();

app.Run();
