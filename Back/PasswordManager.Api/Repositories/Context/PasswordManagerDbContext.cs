using Microsoft.EntityFrameworkCore;
using PasswordManager.Api.Domain.Models;

namespace PasswordManager.Api.Repositories.Context;

public class PasswordManagerDbContext : DbContext
{
    public PasswordManagerDbContext(DbContextOptions<PasswordManagerDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Application> Applications { get; set; }
    public DbSet<Password> Passwords { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Unique index on ApplicationId and AccountName in the Password table
        modelBuilder.Entity<Password>()
            .HasIndex(p => new { p.ApplicationId, p.AccountName })
            .IsUnique();

        // Relation One-to-Many between Application and Password
        modelBuilder.Entity<Password>()
            .HasOne(p => p.Application)
            .WithMany(a => a.Passwords)
            .HasForeignKey(p => p.ApplicationId);

        // Unique index on ApplicationName in the Application table
        modelBuilder.Entity<Application>()
            .HasIndex(a => a.ApplicationName)
            .IsUnique();
        
        // Seed the database with the default applications
        SeedApplications(modelBuilder);
    }
    
    private void SeedApplications(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>().HasData(
            new Application 
            { 
                ApplicationId = 1, 
                ApplicationName = "Example App 1", 
                ApplicationType = ApplicationType.Public 
            },
            new Application 
            { 
                ApplicationId = 2, 
                ApplicationName = "Example App 2", 
                ApplicationType = ApplicationType.Professional 
            }
        );
    }
}