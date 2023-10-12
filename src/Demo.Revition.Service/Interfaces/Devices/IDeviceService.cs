using Demo.Revition.Service.DTOs.UserPositiones;

namespace Demo.Revition.Service.Interfaces.UserPositiones
{
    public interface IUserPositioneService
    {
        Task<UserPositioneResultDto> CreateAsync(UserPositioneCreationDto dto);
        Task<UserPositioneResultDto> UpdateAsync(UserPositioneUpdateDto dto);
        Task<bool> DeleteAsync(long id);
        Task<UserPositioneResultDto> GetByIdAsync(long id);
        Task<IEnumerable<UserPositioneResultDto>> GetAllAsync();
    }
}
