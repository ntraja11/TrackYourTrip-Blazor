using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackYourTrip.Data.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Email { get; set; } = String.Empty;

        [Precision(5, 2)]
        public decimal TotalTripExpense { get; set; } = 0;

        [NotMapped]
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

        [ForeignKey("Trip")]
        public int TripId { get; set; }
        public Trip? Trip { get; set; }
    }
}
