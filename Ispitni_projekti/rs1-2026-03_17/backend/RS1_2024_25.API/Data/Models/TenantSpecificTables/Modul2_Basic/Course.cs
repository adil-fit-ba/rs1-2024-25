namespace RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic;

using RS1_2024_25.API.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;

public class Course : TenantSpecificTable
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
}
