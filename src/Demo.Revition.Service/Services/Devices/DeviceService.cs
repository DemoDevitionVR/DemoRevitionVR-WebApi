using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Demo.Revition.Service.Excaptions;
using Demo.Revition.Service.DTOs.Devices;
using Demo.Revition.Domain.Entities.Devices;
using Demo.Revition.DataAccess.IRepositories;
using Demo.Revition.Service.Interfaces.Devices;

namespace Demo.Revition.Service.Services.Devices;

public class DeviceService : IDeviceService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Device> _repository;
    public DeviceService(IMapper mapper, IRepository<Device> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<DeviceResultDto> CreateAsync(DeviceCreationDto dto)
    {
        var existDevice = await _repository.SelectAsync(d => d.DeviceId.Equals(dto.DeviceId));
        if (existDevice is not null)
            throw new DemoException(403, "This device already exists");

        var mappedDevice = _mapper.Map<Device>(dto);
        mappedDevice.IsActive = true;
        await _repository.CreateAsync(mappedDevice);
        await _repository.SaveAsync();

        return _mapper.Map<DeviceResultDto>(mappedDevice);
    }

    public async Task<DeviceResultDto> UpdateAsync(long id, DeviceUpdateDto dto)
    {
        var existDevice = await _repository.SelectAsync(d => d.Id.Equals(id));
        if (existDevice is null)
            throw new DemoException(404, "This device is not found");

        var mappedDevice = _mapper.Map(dto, existDevice);
        _repository.Update(mappedDevice);
        await _repository.SaveAsync();

        return _mapper.Map<DeviceResultDto>(mappedDevice);
    }
    public async Task<DeviceResultDto> UpdateIsActiveAsync(long id, bool isActive)
    {
        var existDevice = await _repository.SelectAsync(d => d.Id.Equals(id));
        if (existDevice is null)
            throw new DemoException(404, "This device is not found");

        existDevice.Id = id;
        existDevice.IsActive = isActive;
        _repository.Update(existDevice);
        await _repository.SaveAsync();

        return _mapper.Map<DeviceResultDto>(existDevice);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existDevice = await _repository.SelectAsync(d => d.Id.Equals(id));
        if (existDevice is null)
            throw new DemoException(404, "This device is not found");

        _repository.Delete(existDevice);
        await _repository.SaveAsync();
        return true;
    }

    public async Task<DeviceResultDto> GetByIdAsync(long id)
    {
        var existDevice = await _repository.SelectAsync(d => d.Id.Equals(id));
        if (existDevice is null)
            throw new DemoException(404, "This device is not found");

        return _mapper.Map<DeviceResultDto>(existDevice);
    }

    public async Task<IEnumerable<DeviceResultDto>> GetAllAsync()
    {
        var devices = await _repository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<DeviceResultDto>>(devices);
    }
}