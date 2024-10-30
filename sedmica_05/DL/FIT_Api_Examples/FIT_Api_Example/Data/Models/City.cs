using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models;

public class City
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }


    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }
    public Country Country { get; set; }
}