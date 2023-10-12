using Demo.Revition.DataAccess.Contexts;
using Demo.Revition.Service.Interfaces.Devices;
using Demo.Revition.Service.Interfaces.Positions;
using Demo.Revition.Service.Services.Devices;
using Demo.Revition.Service.Services.Positions;
using Demo.Revition.WepApi.Extentions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddServices();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IPositionService, PositionService>();


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