namespace Demo.Revition.Service.DTOs.Positions;

public class UserPositionCreationDto
{
    public long DeviceId { get; set; }
    public string Main { get; set; }
    public string Head { get; set; }
    public string LeftHand { get; set; }
    public string RightHand { get; set; }
}