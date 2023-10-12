using Demo.Revition.Domain.Commons;

namespace Demo.Revition.Domain.Entities.Devices;

public class Device : Auditable
{
    public long DeviceId { get; set; }
    public string? Name { get; set; }
}