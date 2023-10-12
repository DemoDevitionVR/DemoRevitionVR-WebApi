using Demo.Revition.DataAccess.Contexts;
using Demo.Revition.DataAccess.IRepositories;
using Demo.Revition.DataAccess.Repositories;
using Demo.Revition.Service.Interfaces.Devices;
using Demo.Revition.Service.Interfaces.Positions;
using Demo.Revition.Service.Mappers;
using Demo.Revition.Service.Services.Devices;
using Demo.Revition.Service.Services.Positions;

namespace Demo.Revition.WepApi.Extentions;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddDbContext<AppDbContext>();

        services.AddScoped<IDeviceService, DeviceService>();
        services.AddScoped<IPositionService, PositionService>();
    }
}