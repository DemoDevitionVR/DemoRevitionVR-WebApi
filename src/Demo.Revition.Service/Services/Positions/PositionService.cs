using AutoMapper;
using Demo.Revition.DataAccess.IRepositories;
using Demo.Revition.Domain.Entities.Positions;
using Demo.Revition.Service.DTOs.Positions;
using Demo.Revition.Service.Excaptions;
using Demo.Revition.Service.Interfaces.Positions;
using Microsoft.EntityFrameworkCore;

namespace Demo.Revition.Service.Services.Positions
{
    public class PositionService : IPositionService
    {
        private IMapper _mapper;
        private IRepository<UserPosition> _repository;

        public PositionService(IRepository<UserPosition> repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }
        public async Task<UserPositionResultDto> CreateAsync(UserPositionCreationDto dto)
        {
            var userPosition = _mapper.Map<UserPosition>(dto);
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
            var dbResult = await _repository.SelectAsync(id => id.Id.Equals(id));

            if (dbResult is null)
                throw new DemoException(404, "Not found User Position");

            return _mapper.Map<UserPositionResultDto>(dbResult);
        }

        public async Task<UserPositionResultDto> UpdateAsync(long id, UserPositionUpdateDto dto)
        {
            var dbResult = await _repository.SelectAsync(id => id.Equals(id));

            if (dbResult is null)
                throw new DemoException(404, "Not found User Position");

            var usrposition = _mapper.Map(dto, dbResult);
            _repository.Update(usrposition);
            await _repository.SaveAsync();

            return _mapper.Map<UserPositionResultDto>(usrposition);
        }
    }
}
