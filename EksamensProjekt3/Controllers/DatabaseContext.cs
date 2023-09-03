using ArtistLibrary;
using Microsoft.EntityFrameworkCore;

namespace EksamensProjekt3.Controllers
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PassengerTable>().HasKey(p => new { p.AppointmentID, p.JoinedUserId });
        //}

        public DbSet<User> FestivalUsers { get; set; }

        public DbSet<Artist> FestivalArtists { get; set; }
    }
}
