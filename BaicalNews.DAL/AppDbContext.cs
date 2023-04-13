using Microsoft.EntityFrameworkCore;
using BaikalNews.Domain.Models;
using BaikalNews.Domain.Enum;

namespace BaikalNews.DAL;

public class AppDbContext : DbContext
{
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public AppDbContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Worker>(builder =>
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(20).HasColumnType("varchar");
            builder.Property(x => x.Lastname).HasMaxLength(20).HasColumnType("varchar");
            builder.Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(x => x.Password).HasMaxLength(255).HasColumnType("varchar");
            builder.HasData(new Worker
            {
                Id = 1,
                Name = "Admin",
                Email = "Admin@mail.ru",
                IdRole = ListRole.SuperAdmin,
                Password = new Md5().HashPassword("admin"),
                DateCreated = DateTime.Now
            });
        });

        modelBuilder.Entity<Article>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasMaxLength(255).HasColumnType("varchar");
            builder.Property(x => x.Text).HasColumnType("text");
        });

        modelBuilder.Entity<Comment>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            builder.Property(x => x.Text).IsRequired().HasColumnType("text");
        });
        modelBuilder.Entity<Category>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100).HasColumnType("varchar");
        });

    }
}