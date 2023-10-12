using AutoMapper;
using Demo.Revition.Domain.Entities.Devices;
using Demo.Revition.Domain.Entities.Positions;
using Demo.Revition.Service.DTOs.Devices;
using Demo.Revition.Service.DTOs.Positions;

namespace Demo.Revition.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DeviceResultDto, Device>().ReverseMap();
        CreateMap<DeviceUpdateDto, Device>().ReverseMap();
        CreateMap<DeviceCreationDto, Device>().ReverseMap();

        CreateMap<UserPositionResultDto, UserPosition>().ReverseMap();
        CreateMap<UserPositionUpdateDto, UserPosition>().ReverseMap();
        CreateMap<UserPositionCreationDto, UserPosition>().ReverseMap();
    }
}