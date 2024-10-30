using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIT_Api_Example.Data.Models;

public class  MyAppUser
{
    [Key]
    public int ID { get; set; }
    public string Username { get; set; }
    [JsonIgnore]
    public string Password { get; set; }

}