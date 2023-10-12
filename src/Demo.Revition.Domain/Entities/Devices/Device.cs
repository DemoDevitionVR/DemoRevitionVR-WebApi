using Demo.Revition.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace Demo.Revition.Domain.Entities.Devices;

public class Device : Auditable
{
    [Key]
    public long DeviceId { get; set; }
    public string? Name { get; set; }
}