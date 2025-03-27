using Microsoft.OpenApi.Models;
using TelegramBotAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TelegramBotAPI", Version = "v1" });
});

builder.Services.AddHttpClient();
builder.Services.AddSingleton<TelegramService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TelegramBotAPI v1"));
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();