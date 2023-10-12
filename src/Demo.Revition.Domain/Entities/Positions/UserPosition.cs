using Demo.Revition.Domain.Commons;
using Demo.Revition.Domain.Entities.UserPositiones;

namespace Demo.Revition.Domain.Entities.Positions;

public class UserPosition : Auditable
{
    public long UserPositioneId { get; set; }
    public UserPositione UserPositione { get; set; }
    public string Main { get; set; }
    public string Head { get; set; }
    public string LeftHand { get; set; }
    public string RightHand { get; set; }
}