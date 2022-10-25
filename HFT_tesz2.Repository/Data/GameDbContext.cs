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
            modelBuilder.Entity<Game>(game => game
                .HasOne<DevelopersTeam>()
                .WithMany()
                .HasForeignKey(game => game.DevId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Publisher>(x => x
                .HasOne<Game>()
                .WithMany()
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull));

            DevelopersTeam dp1 = new DevelopersTeam() { DevId = 1, Name = "CD project Red", CountofMembers = 450, Country = "Poland" };
            DevelopersTeam dp2 = new DevelopersTeam() { DevId = 2, Name = "Valve", CountofMembers = 500, Country = "USA" };

            

            
            modelBuilder.Entity<DevelopersTeam>().HasData(dp1,dp2);
            
        }
    }
}
