using System.ComponentModel.DataAnnotations;

namespace TrackYourTrip.Data.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
                    
        public string? Location { get; set; } = "Denmark";

    }
}
