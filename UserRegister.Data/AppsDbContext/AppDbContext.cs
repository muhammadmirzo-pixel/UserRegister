using Microsoft.EntityFrameworkCore;
using UserRegister.Domain.Entities;

namespace UserRegister.Data.AppsDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
