using ForUserApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForUserApi.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> dbContext) 
                        : DbContext(dbContext)
{
    public DbSet<User> Users { get; set; }
}
