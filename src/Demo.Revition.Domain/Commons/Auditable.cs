using System.ComponentModel.DataAnnotations;

namespace Demo.Revition.Domain.Commons;

public abstract class Auditable
{
    [Key]
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}