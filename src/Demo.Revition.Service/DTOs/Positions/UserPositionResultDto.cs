using Demo.Revition.Service.DTOs.Devices;

namespace Demo.Revition.Service.DTOs.Positions;

public class UserPositionResultDto
{
    public long Id { get; set; }
    public string Main { get; set; }
    public string Head { get; set; }
    public string LeftHand { get; set; }
    public string RightHand { get; set; }
    public DeviceResultDto Device { get; set; }
}