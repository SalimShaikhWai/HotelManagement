using Demo63Assignment.Models.Interface;
using HotelManagement.Data;
using HotelManagement.Data.Data_Access;
using HotelManagement.Data.Model;
using HotelManagement.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HotelMgtContext>(options => options.UseSqlServer());

AddDependancyInjection(builder.Services);

void AddDependancyInjection(IServiceCollection services)
{
   services.AddScoped<ICrudService<Hotel>, HotelService>();
    services.AddScoped<ICrudService<Room>, RoomService>();
    services.AddScoped<ICrudService<Location>, LocationService>();
    services.AddAutoMapper(typeof(AutoMapperProfiler));
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
