using Demo.Revition.Service.DTOs.Devices;

namespace Demo.Revition.Service.Interfaces.Devices;

public interface IDeviceService
{
    Task<DeviceResultDto> CreateAsync(DeviceCreationDto dto);
    Task<DeviceResultDto> UpdateAsync(long id, DeviceUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<DeviceResultDto> GetByIdAsync(long id);
    Task<DeviceResultDto> UpdateIsActiveAsync(long id, bool isActive);
    Task<IEnumerable<DeviceResultDto>> GetAllAsync();
}