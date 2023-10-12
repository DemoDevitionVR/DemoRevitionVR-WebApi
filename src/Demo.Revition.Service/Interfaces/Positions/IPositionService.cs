using Demo.Revition.Service.DTOs.Positions;

namespace Demo.Revition.Service.Interfaces.Positions;

public interface IPositionService
{
    Task<UserPositionResultDto> CreateAsync(UserPositionCreationDto dto);
    Task<UserPositionResultDto> UpdateAsync(UserPositionUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<UserPositionResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserPositionResultDto>> GetAllAsync();
}