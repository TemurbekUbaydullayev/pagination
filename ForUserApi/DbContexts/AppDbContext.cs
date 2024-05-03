using ForUserApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForUserApi.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> dbContext) 
                        : DbContext(dbContext)
{
    public DbSet<User> Users { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    modelBuilder.Entity<User>()
    //        .HasData(new User
    //        {
    //            Id = new Guid(),
    //            FirstName = "Temurbek",
    //            LastName = "Ubaydullayev",

    //        });
    //}
}
