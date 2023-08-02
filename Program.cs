using Microsoft.EntityFrameworkCore;
using PlantApi.Data;
using PlantApi.Interfaces;
using PlantApi.Models;
using PlantApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<PlantContext>(opt => opt.UseInMemoryDatabase("PlantList"));
builder.Services.AddDbContext<PlantContext>(opt => opt.UseSqlServer("Data Source=192.168.1.95,1433;Initial Catalog=PlantFactDB;User ID=SA;Password=st4ong3epass2wor9dgoon34713;Encrypt=False")) ;
builder.Services.AddScoped<IPlantService,PlantService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

