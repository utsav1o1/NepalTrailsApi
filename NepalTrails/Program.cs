using Microsoft.EntityFrameworkCore;
using NepalTrails.Data;
using NepalTrails.Mappings;
using NepalTrails.Repositories.Implementations;
using NepalTrails.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);


//make a database connection

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NepalTrailsDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<ITrailRepository, TrailRepository>();
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
