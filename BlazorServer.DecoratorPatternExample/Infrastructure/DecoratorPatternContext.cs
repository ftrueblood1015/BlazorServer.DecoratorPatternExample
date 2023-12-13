using Microsoft.EntityFrameworkCore;
using BlazorServer.DecoratorPatternExample.Domain.Models;

namespace BlazorServer.DecoratorPatternExample.Infrastructure
{
    public class DecoratorPatternContext : DbContext
    {
        public DecoratorPatternContext(DbContextOptions<DecoratorPatternContext> options) : base(options) { }

        DbSet<Holiday> Holidays => Set<Holiday>();
        DbSet<Birthday> Birthdays => Set<Birthday>();
        DbSet<Anniversary> Anniversaries => Set<Anniversary>();
        DbSet<EventLogger> EventLogs => Set<EventLogger>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Holiday>().HasData(
                new Holiday { Id = 1, Comments = "Its Christmas", Date = new DateTime(2023, 12, 25), Description = "Christmas", IsActive = true, Name = "Christmas" },    
                new Holiday { Id = 2, Comments = "Its New Years Eve", Date = new DateTime(2023, 12, 31), Description = "New Years Eve", IsActive = true, Name = "New Years Eve" }    
            );

            modelBuilder.Entity<Birthday>().HasData(
                new Holiday { Id = 1, Comments = "My Bday", Date = new DateTime(2000, 2, 20), Description = "Fletcher Bday", IsActive = true, Name = "Fletcher Bday" },
                new Holiday { Id = 2, Comments = "Not My Bday", Date = new DateTime(1981, 1, 17), Description = "Not My Bday", IsActive = true, Name = "Not My Bday" }
            );

            modelBuilder.Entity<Anniversary>().HasData(
                new Holiday { Id = 1, Comments = "My Anniversay", Date = new DateTime(2015, 3, 13), Description = "My Anniversay", IsActive = true, Name = "My Anniversay" },
                new Holiday { Id = 2, Comments = "Not My Anniversay", Date = new DateTime(2014, 9, 22), Description = "Not My Anniversay", IsActive = true, Name = "Not My Anniversay" }
            );
        }
    }
}
