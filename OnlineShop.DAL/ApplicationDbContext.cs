﻿

using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entity;
using OnlineShop.Domain.Enum;
using OnlineShop.Domain.Helpers;

namespace OnlineShop.DAL
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ItemColor> ItemColors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.Id);

                builder.HasData(new User
                {
                    Id = 1,
                    Name = "Browissimo",
                    Password = HashPasswordHelper.HashPassword("123456"),
                    Role = Role.Admin,
                    Email = "Browissimo@mail.ru"
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

                builder.HasOne(x => x.Profile)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profiles").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Age);
                builder.Property(x => x.Address).HasMaxLength(200).IsRequired(false);
            });


            modelBuilder
                .Entity<Item>()
                .HasMany(c => c.Colors)
                .WithMany(c => c.Items)
                .UsingEntity<ItemColor>(
                j => j
                    .HasOne(pt => pt.Color)
                    .WithMany(p => p.itemColors)
                    .HasForeignKey(pt => pt.ColorId),
                j => j
                    .HasOne(pt => pt.Item)
                    .WithMany(t => t.itemColors)
                    .HasForeignKey(pt => pt.ItemID),
                j =>
                {
                    j.Property(pt => pt.ModelCharacteristics);
                    j.HasKey(t => t.id);
                    j.ToTable("ItemColors");
            });               
        }
    }
}
