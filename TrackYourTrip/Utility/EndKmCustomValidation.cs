using System.ComponentModel.DataAnnotations;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Utility
{
    public class EndKmGreaterThanStartKmAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var trip = (Trip)validationContext.ObjectInstance;

            if (trip.EndKm <= trip.StartKm || (trip.EndKm > 0 && (trip.StartKm == 0 || trip.StartKm is null)))
            {
                return new ValidationResult("Startkm must be assigned and EndKm must be greater than StartKm.");
            }



            return ValidationResult.Success;
        }
    }
}
