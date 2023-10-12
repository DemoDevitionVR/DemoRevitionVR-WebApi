using AutoMapper;
using Demo.Revition.DataAccess.IRepositories;
using Demo.Revition.Domain.Entities.Devices;
using Demo.Revition.Domain.Entities.Positions;
using Demo.Revition.Service.DTOs.Positions;
using Demo.Revition.Service.Excaptions;
using Demo.Revition.Service.Interfaces.Positions;
using Microsoft.EntityFrameworkCore;

namespace Demo.Revition.Service.Services.Positions;

public class PositionService : IPositionService
{
    private IMapper _mapper;
    private IRepository<Device> _deviceRepository;
    private IRepository<UserPosition> _repository;

    public PositionService(
        IMapper mapper,
        IRepository<UserPosition> repository, 
        IRepository<Device> deviseRepository)
    {
        this._mapper = mapper;
        this._repository = repository;
        this._deviceRepository = deviseRepository;
    }
    public async Task<UserPositionResultDto> CreateAsync(UserPositionCreationDto dto)
    {
        var dbResult = await _deviceRepository.SelectAsync(x => x.Id.Equals(dto.DeviceId));

        if (dbResult is null)
            throw new DemoException(404, "Not found Device");

        var userPosition = _mapper.Map<UserPosition>(dto);
        userPosition.Device = dbResult;
        await _repository.CreateAsync(userPosition);
        await _repository.SaveAsync();

        return _mapper.Map<UserPositionResultDto>(userPosition);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var dbResult = await _repository.SelectAsync(id => id.Id.Equals(id));

        if (dbResult is null)
            throw new DemoException(404, "Not Found Position");

        _repository.Delete(dbResult);
        await _repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<UserPositionResultDto>> GetAllAsync()
    {
        var dbResult = await _repository.SelectAll().ToListAsync();

        return _mapper.Map<IEnumerable<UserPositionResultDto>>(dbResult);
    }

    public async Task<UserPositionResultDto> GetByIdAsync(long id)
    {
        var dbResult = await _repository.SelectAsync(i => i.Id.Equals(id));

        if (dbResult is null)
            throw new DemoException(404, "Not found User Position");

        return _mapper.Map<UserPositionResultDto>(dbResult);
    }

    public async Task<UserPositionResultDto> UpdateAsync(long id, UserPositionUpdateDto dto)
    {
        var dbResult = await _repository.SelectAsync(i => i.Equals(id));

        if (dbResult is null)
            throw new DemoException(404, "Not found User Position");

        var dbDevice = await _deviceRepository.SelectAsync(x => x.Id.Equals(dto.DeviceId));

        if (dbDevice is null)
            throw new DemoException(404, "Not found Device");

        var userPosition = _mapper.Map(dto, dbResult);
        userPosition.Device = dbDevice;
        _repository.Update(userPosition);
        await _repository.SaveAsync();

        return _mapper.Map<UserPositionResultDto>(userPosition);
    }
}
