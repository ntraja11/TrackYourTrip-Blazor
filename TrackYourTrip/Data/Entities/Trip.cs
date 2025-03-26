using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        public decimal TotalExpense { get; set; }
        [Display(Name = "Starting Kilometer")]
        public int? StartKm { get; set; }
        [Display(Name = "Ending Kilometer")]
        public int? EndKm { get; set; }
        [Display(Name = "Total Kilometer")]
        public int? TotalKm { get; set; }

        public string? Status { get; set; }

        public string? Notes { get; set; }

        public string? Type { get; set; }

        [ForeignKey("Vehicle")]
        public int? VehicleId { get; set; }
        [ValidateNever]
        public Vehicle? Vehicle { get; set; }

        [NotMapped]
        public IEnumerable<Participant> ParticipantList { get; set; } = new List<Participant>();

        [NotMapped]
        public IEnumerable<Expense> ExpenseList { get; set; } = new List<Expense>();
    }
}
