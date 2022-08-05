using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace HotelListing.data;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public double Rating { get; set; }
    
    [ForeignKey("Id")] 
    public Country Country { get; set; }
    
    public int CountryId { get; set; }
}