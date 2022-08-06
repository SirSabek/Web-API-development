using System.ComponentModel.DataAnnotations;
using HotelListing.data;

namespace HotelListing.Models;

public class CreateHotelDto
{
    public int Id { get; set; }
    [Required]
    [StringLength(maximumLength:150,ErrorMessage = "Name is too long!")]
    public string Name { get; set; }
    [Required]
    [StringLength(maximumLength:150,ErrorMessage = "Name is too long!")]
    public string Address { get; set; }
    [Required]
    [Range(1,5)]
    public double Rating { get; set; }
    [Required]
    public int CountryId { get; set; }
}

public class HotelDto : CreateHotelDto
{
    public int Id { get; set; }
    public CountryDto Country { get; set; }
}