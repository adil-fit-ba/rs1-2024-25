using FIT_Api_Example.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries{ get; set; }
    public DbSet<MyAppUser> MyAppUsers { get; set; }
  


    public ApplicationDbContext(
        DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.NoAction;
        }

       // modelBuilder.Entity<KorisnickiNalog>().UseTpcMappingStrategy();
    }
}