using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : DbContext
{
    public DataContext() { }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Passenger> Passengers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Hotel>()
            .HasMany(e => e.Rooms)
            .WithOne(e => e.Hotel)
            .HasForeignKey(e => e.HotelId)
            .IsRequired();
        
        modelBuilder.Entity<Room>()
            .HasMany(e => e.Books)
            .WithOne(e => e.Room)
            .HasForeignKey(e => e.RoomId)
            .IsRequired();
        
        modelBuilder.Entity<Book>()
            .HasMany(e => e.Passengers)
            .WithOne(e => e.Book)
            .HasForeignKey(e => e.BookId)
            .IsRequired();
        
        modelBuilder.Entity<Book>()
            .HasOne(e => e.Contact)
            .WithOne(e => e.Book)
            .HasForeignKey<Contact>(e => e.BookId)
            .IsRequired();
        
        modelBuilder.Entity<Passenger>()
            .Property(e => e.Genre)
            .HasConversion(
                v => v.ToString(),
                v => (GenreEnum)Enum.Parse(typeof(GenreEnum), v)
            );
    }
}
