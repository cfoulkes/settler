using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Auth;
using Server.Models;

namespace Server.Data;

public class DataContext : DbContext
{
    public IHttpContextAccessor httpContextAccessor { get; }

    public DataContext(
        DbContextOptions<DataContext> options,
        IHttpContextAccessor httpContextAccessor
    ) : base(options)
    {
        this.httpContextAccessor = httpContextAccessor;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserStatus> UserStatuses => Set<UserStatus>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<Agency> Agencies => Set<Agency>();
    public DbSet<AgencyStatus> AgencyStatuses => Set<AgencyStatus>();

    public DbSet<Client> Clients => Set<Client>();

    public override int SaveChanges()
    {
        var identity = (CustomIdentity?)this.httpContextAccessor.HttpContext?.User.Identity;

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

        modelBuilder.Entity<User>().Property(b => b.RowVer).IsRowVersion();
        modelBuilder.Entity<Client>().Property(b => b.RowVer).IsRowVersion();

        modelBuilder
            .Entity<UserStatus>()
            .HasData(
                new UserStatus { Id = 1, Description = "Active" },
                new UserStatus { Id = 2, Description = "Pending" },
                new UserStatus { Id = 3, Description = "Locked" }
            );

        modelBuilder
            .Entity<AgencyStatus>()
            .HasData(
                new AgencyStatus { Id = 1, Description = "Active" },
                new AgencyStatus { Id = 2, Description = "Suspended" }
            );

        modelBuilder
            .Entity<Role>()
            .HasData(
                new Role { Id = 1, Description = "SysAdmin" },
                new Role { Id = 2, Description = "Admin" },
                new Role { Id = 3, Description = "Intake" },
                new Role { Id = 4, Description = "Manager" }
            );

        modelBuilder
            .Entity<User>()
            .HasData(
                new User
                {
                    Id = 1,
                    UserStatusId = 1,
                    Email = "admin@settler.test",
                    PasswordHash =
                        "FC57D856266390FBEFE1E3BF64011C538A3CB25C4D048F867998351335F744059D6EB133A85FECC9B2A60088147EDDA18622FA95B3282C30BAAFABC0E1EA9A9D",
                    PasswordSalt =
                        "4A46744489B84AF9679B72BC470BC9401887A7CC2AA76D44CB450197BC05AC04633047A90949826784CD545CFA0885267FA8C1C9AE1918086D92DBC0FB5D64D7"
                }
            );

        modelBuilder
            .Entity<UserRole>()
            .HasData(
                new UserRole
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1
                }
            );

        //TEST DATA
        modelBuilder
            .Entity<User>()
            .HasData(
                new User
                {
                    Id = 2,
                    UserStatusId = 1,
                    Email = "all@settler.test",
                    PasswordHash =
                        "FC57D856266390FBEFE1E3BF64011C538A3CB25C4D048F867998351335F744059D6EB133A85FECC9B2A60088147EDDA18622FA95B3282C30BAAFABC0E1EA9A9D",
                    PasswordSalt =
                        "4A46744489B84AF9679B72BC470BC9401887A7CC2AA76D44CB450197BC05AC04633047A90949826784CD545CFA0885267FA8C1C9AE1918086D92DBC0FB5D64D7"
                }
            );

        modelBuilder
            .Entity<UserRole>()
            .HasData(
                new UserRole
                {
                    Id = 2,
                    UserId = 2,
                    RoleId = 1
                },
                new UserRole
                {
                    Id = 3,
                    UserId = 2,
                    RoleId = 2
                },
                new UserRole
                {
                    Id = 4,
                    UserId = 2,
                    RoleId = 3
                }
            );

        modelBuilder
            .Entity<Agency>()
            .HasData(
                new Agency
                {
                    Id = 1,
                    Name = "Test Agency 1",
                    AgencyStatusId = 1,
                }
            );

        modelBuilder
            .Entity<UserProfile>()
            .HasData(
                new UserProfile
                {
                    Id = 2,
                    LanguagePreference = "en-CA",
                    AgencyId = 1
                }
            );

        modelBuilder
            .Entity<Client>()
            .HasData(
                new Client
                {
                    Id = 1,
                    FirstName = "Fred",
                    LastName = "Flintstone",
                    AgencyId = 1
                },
                new Client
                {
                    Id = 2,
                    FirstName = "Wilma",
                    LastName = "Flintstone",
                    AgencyId = 1
                },
                new Client
                {
                    Id = 3,
                    FirstName = "Barney",
                    LastName = "Rubble",
                    AgencyId = 1
                }
            );
    }
}
