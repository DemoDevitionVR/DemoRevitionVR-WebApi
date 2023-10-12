using Demo.Revition.Service.Mappers;
using Demo.Revition.Service.Services;
using Demo.Revition.DataAccess.Repositories;
using Demo.Revition.DataAccess.IRepositories;
using Demo.Revition.Service.Interfaces.Devices;

namespace Demo.Revition.WepApi.Extentions;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<IDeviceService, DeviceService>();
    }
}