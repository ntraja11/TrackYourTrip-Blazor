using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Data;

public class TrackYourTripDbContext(DbContextOptions<TrackYourTripDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Expense>()
        .HasOne(e => e.Trip)
        .WithMany(t => t.ExpenseList) // Ensure Trip has a collection of Expenses
        .HasForeignKey(e => e.TripId)
        .OnDelete(DeleteBehavior.Cascade); // Cascade delete

        // Configure Expense -> Participant relationship
        modelBuilder.Entity<Expense>()
            .HasOne(e => e.Participant)
            .WithMany(p => p.ExpenseList) // Ensure Participant has a collection of Expenses
            .HasForeignKey(e => e.ParticipantId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Trip>().HasData(
            new Trip
            {
                Id = 1,
                Name = "Ooty Summer Escape",
                Description = "A relaxing summer retreat in the hills of Ooty.",
                From = "Keelapalur",
                To = "Ooty",
                StartDate = new DateOnly(2025, 5, 15),
                EndDate = new DateOnly(2025, 5, 20),
                TotalExpense = 25000,
                Status = "Completed",
                Notes = "Wonderful weather, visited the Botanical Gardens and tea estates.",
                Type = "Family"
            },
            new Trip
            {
                Id = 2,
                Name = "Kodaikanal Adventure",
                Description = "Exploring the lakes and forests of Kodaikanal.",
                From = "Keelapalur",
                To = "Kodaikanal",
                StartDate = new DateOnly(2025, 6, 10),
                EndDate = new DateOnly(2025, 6, 14),
                TotalExpense = 18000,
                Status = "Planned",
                Notes = "Looking forward to trekking and boating.",
                Type = "Friends"
            },
            new Trip
            {
                Id = 3,
                Name = "Mysore Cultural Tour",
                Description = "A cultural trip to explore the royal city of Mysore.",
                From = "Keelapalur",
                To = "Mysore",
                StartDate = new DateOnly(2025, 4, 5),
                EndDate = new DateOnly(2025, 4, 7),
                TotalExpense = 15000,
                Status = "Completed",
                Notes = "Visited Mysore Palace and Brindavan Gardens.",
                Type = "Family"
            }


            );

        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle
            {
                Id = 1,
                Name = "Mahindra Scorpio",
                Owner = "Raja",
                Fuel = "Diesel",
                MileagePerLitre = "10"
            },
            new Vehicle
            {
                Id = 2,
                Name = "Honda Accord",
                Owner = "Raja Anand",
                Fuel = "CNG",
                MileagePerLitre = "20"
            },
            new Vehicle
            {
                Id = 3,
                Name = "Mahindra Scorpio",
                Owner = "Balu",
                Fuel = "Diesel",
                MileagePerLitre = "10"
            },
            new Vehicle
            {
                Id = 4,
                Name = "Maruti Swift",
                Owner = "Karthik Raja",
                Fuel = "Petrol",
                MileagePerLitre = "16"
            }


        );
    }

}
