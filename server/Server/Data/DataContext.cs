using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public class DataContext : DbContext
{
    // static DataContext()
    // {
    //     AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    // }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserStatus> UserStatuses => Set<UserStatus>();

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(
                e =>
                    e.Entity is EntityBase
                    && (e.State == EntityState.Added || e.State == EntityState.Modified)
            );

        foreach (var entityEntry in entries)
        {
            ((EntityBase)entityEntry.Entity).ModifiedDate = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((EntityBase)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<UserStatus>()
            .HasData(
                new UserStatus { Id = 1, Description = "Active" },
                new UserStatus { Id = 2, Description = "Pending" },
                new UserStatus { Id = 3, Description = "Locked" }
            );

        modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Description = "Administrator" });

        modelBuilder
            .Entity<User>()
            .HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash =
                        "FC57D856266390FBEFE1E3BF64011C538A3CB25C4D048F867998351335F744059D6EB133A85FECC9B2A60088147EDDA18622FA95B3282C30BAAFABC0E1EA9A9D",
                    PasswordSalt =
                        "4A46744489B84AF9679B72BC470BC9401887A7CC2AA76D44CB450197BC05AC04633047A90949826784CD545CFA0885267FA8C1C9AE1918086D92DBC0FB5D64D7"
                }
            );
    }
}