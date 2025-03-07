using pruebaApiPSP.model;
using Microsoft.EntityFrameworkCore;
using pruebaApiPSP.service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PlayerDatabaseSettings>(
    builder.Configuration.GetSection("PlayerDatabase"));

builder.Services.AddSingleton<PlayerService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);;
builder.Services.AddDbContext<PlayerContext>(opt =>
    opt.UseInMemoryDatabase("Players"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
