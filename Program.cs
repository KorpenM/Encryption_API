var builder = WebApplication.CreateBuilder(args);

// L�gg till support f�r controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Anv�nd Swagger (API-dokumentation)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mappar controllers (g�r att v�ra endpoints fungerar)
app.MapControllers();

app.Run();
