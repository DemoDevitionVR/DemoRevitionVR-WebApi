using Microsoft.EntityFrameworkCore;

namespace Demo.Revition.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}