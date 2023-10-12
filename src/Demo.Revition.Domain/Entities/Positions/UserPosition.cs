using Demo.Revition.Domain.Commons;
using Demo.Revition.Domain.Entities.Devices;

namespace Demo.Revition.Domain.Entities.Positions;

public class UserPosition : Auditable
{
    public long DeviceId { get; set; }
    public Device Device { get; set; }
    public string Main { get; set; }
    public string Head { get; set; }
    public string LeftHand { get; set; }
    public string RightHand { get; set; }
}