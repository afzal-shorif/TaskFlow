using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var adminRoleId = Guid.NewGuid();

        //modelBuilder.Entity<RoleEntity>(e =>
        //{
        //    e.Property<Guid>(r => r.Id).IsRequired();
        //    e.Property(r => r.Name).IsRequired();

        //    e.HasData(
        //        new RoleEntity { Id = adminRoleId, Name = "Admin" },
        //        new RoleEntity { Id = Guid.NewGuid(), Name = "User" }
        //    );
        //});

        //modelBuilder.Entity<UserEntity>().OwnsOne<RoleEntity>(r => r.Role)

        //modelBuilder.Entity<UserEntity>(e =>
        //{
        //    e.Property(u => u.Id).IsRequired();
        //    e.Property(u => u.Name).IsRequired();
        //    e.Property(u => u.Email).IsRequired();
        //    e.Property(u => u.Role).IsRequired();

        //    e.HasData(new UserEntity
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Admin",
        //        Email = "admin@taskflow.com",
        //        Role = adminRoleId,
        //        CreatedAt = DateTimeOffset.UtcNow,
        //        UpdatedAt = DateTimeOffset.UtcNow
        //    });
        //})
        //.HasOne<RoleEntity>();

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }

}
