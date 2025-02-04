using EncryptionAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// L�gger till support f�r controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Encryptor>();


var app = builder.Build();

// Anv�nder Swagger
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
