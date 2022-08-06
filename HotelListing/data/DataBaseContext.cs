using Microsoft.EntityFrameworkCore;

namespace HotelListing.data;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions options) : base(options)
    {}
    public DbSet<Country> Countries { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasData(
            new Country() {Id = 1, Name = "Egypt", ShortName = "Egy"},
            new Country() {Id = 2, Name = "Morocco", ShortName = "Mor"},
            new Country() {Id = 3, Name = "Algeria", ShortName = "Alg"}
            );
        modelBuilder.Entity<Hotel>().HasData(
            new Hotel{Id = 1, Name = "grand Hotel", Address = "Cairo", CountryId = 1, Rating = 4.5},
            new Hotel{Id = 2, Name = "sun shine", Address = "Casablanca", CountryId = 2, Rating = 5},
            new Hotel{Id = 3, Name = "Sheraton", Address = "Algeria", CountryId = 3, Rating = 4}
            );
    }
}