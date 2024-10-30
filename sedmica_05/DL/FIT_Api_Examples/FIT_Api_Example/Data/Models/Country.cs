using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models;

public class Country
{
    public int ID { get; set; }
    public string Name { get; set; }

   // public List<City> Cities{ get; set; }

}