using Demo.Revition.Domain.Commons;
using Demo.Revition.Domain.Entities.Positions;

namespace Demo.Revition.Domain.Entities.Devices;

public class Device : Auditable
{
    public long DeviceId { get; set; }
    public bool IsActive { get; set; }
    public string? Name { get; set; }
    public ICollection<UserPosition> UserPositions { get; set; }
}