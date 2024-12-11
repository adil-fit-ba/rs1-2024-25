using RS1_2024_25.API.Helper;
using RS1_2024_25.API.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models.SharedTables;

public class City : SharedTableBase
{
    public string Name { get; set; }

    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }
    public Country? Country { get; set; }

    public int RegionId { get; set; } // FK na regiju
    [ForeignKey(nameof(RegionId))]
    public Region? Region { get; set; } // Navigaciona veza na regiju
}