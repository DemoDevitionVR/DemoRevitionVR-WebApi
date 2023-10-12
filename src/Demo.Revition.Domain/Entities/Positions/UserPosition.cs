using Demo.Revition.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace Demo.Revition.Domain.Entities.Positions;

public class UserPosition : Auditable
{
    public long DeviceId { get; set; }
    public string Main { get; set; }
    public string Head { get; set; }
    public string LeftHand { get; set; }
    public string RightHand { get; set; }
}