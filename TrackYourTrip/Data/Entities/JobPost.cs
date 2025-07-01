using System.ComponentModel.DataAnnotations;

namespace TrackYourTrip.Data.Entities
{
    public class JobPost
    {
        public int Id { get; set; }
        [Required]
        public string JobTitle { get; set; } = string.Empty;
        [Required]
        public string Company { get; set; } = string.Empty;
        [Required]
        public DateOnly PostedOn { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
