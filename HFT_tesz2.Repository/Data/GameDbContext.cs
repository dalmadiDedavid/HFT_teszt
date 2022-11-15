using HFT_tesz2.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace HFT_tesz2.Repository
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Game { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<DevelopersTeam> DevTeam { get; set; }

        public GameDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {



                optionsBuilder
                    .UseInMemoryDatabase("gamedb")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(game => game.Developers)
                    .WithMany(dev => dev.Games)
                    .HasForeignKey(game => game.DevId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });
            
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(game => game.Publisher)
                    .WithMany(pub => pub.Games)
                    .HasForeignKey(game => game.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            

            DevelopersTeam d1 = new DevelopersTeam() { Id = 1, Name = "Santa Monica Studio", Country = "USA", CountofMembers = 500 };
            DevelopersTeam d2 = new DevelopersTeam() { Id = 2, Name = "Sony Game Studio", Country = "Japan", CountofMembers = 750 };
            DevelopersTeam d3 = new DevelopersTeam() { Id = 3, Name = "Valve", Country = "USA", CountofMembers = 350 };

            Publisher p1 = new Publisher() { Id = 1, Name = "Epic Games", Platform = "Windows" };
            Publisher p2 = new Publisher() { Id = 2, Name = "Steam", Platform = "Windows" };
            Publisher p3 = new Publisher() { Id = 3, Name = "Origins", Platform = "Windows" };

            Game g1 = new Game() { Id = 1, DevId = d1.Id, PubId = p1.Id, GName = "God Of War", Type = "Adventure", AgeLimit = 12, Price = 15000 };
            Game g2 = new Game() { Id = 2, DevId = d2.Id, PubId = p2.Id, GName = "CSGO", Type = "Shooter", AgeLimit = 16, Price = 2500};
            Game g3 = new Game() { Id = 3, DevId = d2.Id, PubId = p1.Id, GName = "Spider-Man", Type = "Action", AgeLimit = 14, Price = 18000 };
            
            
           



            modelBuilder.Entity<DevelopersTeam>().HasData(d1,d2,d3);
            modelBuilder.Entity<Game>().HasData(g1,g2,g3);
            modelBuilder.Entity<Publisher>().HasData(p1,p2,p3);
            
        }
    }
}
