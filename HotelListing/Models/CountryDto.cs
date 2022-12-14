using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models;

public class CountryDto : CreateCountryDto
{
    public int Id { get; set; }
    public virtual IList<HotelDto> Hotels { get; set; }
}