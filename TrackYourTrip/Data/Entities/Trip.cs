using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackYourTrip.Data.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        [Required]
        public string? From { get; set; }
        [Required]
        public string? To { get; set; }
        [Display(Name = "Total Expense")]
        public double TotalExpense { get; set; }
        [Display(Name = "Starting Kilometer")]
        public int? StartKm { get; set; }
        [Display(Name = "Ending Kilometer")]
        public int? EndKm { get; set; }
        [Display(Name = "Total Kilometer")]
        public int? TotalKm { get; set; }

        public string? Status { get; set; }

        public string? Notes { get; set; }

        public string? Type { get; set; }

        [NotMapped]
        public List<Participant> Participants { get; set; } = new();

        [NotMapped]
        public List<Expense> Expenses { get; set; } = new();
    }
}
