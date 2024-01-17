using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Mapping;
using NZWalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Data Injection
builder.Services.AddDbContext<NZWalksDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

// Repository Pattern
// it means which component implmenet the IRegionRepository that mean using SQLRegionRepository
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
// it's easy to switch database
// builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();

builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

// AUTOMAPPER
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
