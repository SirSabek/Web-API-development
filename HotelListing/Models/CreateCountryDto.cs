using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models;

public class CreateCountryDto
{
 
    [Required]
    [StringLength(maximumLength:50, ErrorMessage = "Name is too long!")]
    public string Name { get; set; }
    [Required]
    [StringLength(maximumLength:3, ErrorMessage = "maximum short name is 3!")]
    public string ShortName { get; set; }
}