using RS1_2024_25.API.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models;

public class Country : IMyBaseEntity
{
    public int ID { get; set; }
    public string Name { get; set; }

    // public List<City> Cities{ get; set; }
}