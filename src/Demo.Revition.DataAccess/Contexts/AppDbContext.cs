using Demo.Revition.Domain.Entities.Positions;
using Demo.Revition.Domain.Entities.UserPositiones;
using Microsoft.EntityFrameworkCore;

namespace Demo.Revition.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<UserPositione> UserPositiones { get; set; }
    public DbSet<UserPosition> Positions { get; set; }

}