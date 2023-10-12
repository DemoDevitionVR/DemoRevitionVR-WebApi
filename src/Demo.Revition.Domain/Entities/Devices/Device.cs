using Demo.Revition.Domain.Commons;
using Demo.Revition.Domain.Entities.Positions;

namespace Demo.Revition.Domain.Entities.UserPositiones;

public class UserPositione : Auditable
{
    public long UserPositioneId { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }
    public ICollection<UserPosition> UserPositions { get; set; }
}