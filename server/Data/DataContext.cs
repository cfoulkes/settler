using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

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
    }
}
