using Microsoft.EntityFrameworkCore;
using Demo.Revition.Domain.Entities.Devices;
using Demo.Revition.Domain.Entities.Positions;

namespace Demo.Revition.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<Device> Devices { get; set; }
    public DbSet<UserPosition> Positions { get; set; }
}