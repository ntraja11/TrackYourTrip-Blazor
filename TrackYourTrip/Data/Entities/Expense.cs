using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackYourTrip.Data.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        [Required]
        [Precision(10, 2)]
        public decimal Amount { get; set; } = 0;
        public DateOnly? ExpenseDate { get; set; }


        [ForeignKey("Participant")]
        public int ParticipantId { get; set; }
        public Participant? Participant { get; set; }

        [ForeignKey("Trip")]
        public int TripId { get; set; }
        public Trip? Trip { get; set; }
    }
}
