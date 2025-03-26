using System.ComponentModel.DataAnnotations;

namespace TrackYourTrip.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Owner { get; set; }

        public string? Fuel { get; set; }

        [Display(Name = "Mileage Per Litre")]
        public string? MileagePerLitre { get; set; }
    }
}
