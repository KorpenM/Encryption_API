using EncryptionAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Lägger till support för controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Encryptor>();


var app = builder.Build();

// Använder Swagger
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
