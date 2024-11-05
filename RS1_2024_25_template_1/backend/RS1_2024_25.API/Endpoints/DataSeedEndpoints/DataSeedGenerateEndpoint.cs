namespace RS1_2024_25.API.Endpoints.DataSeed;

using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper.Api;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

[Route("data-seed")]
public class DataSeedGenerateEndpoint(ApplicationDbContext db)
    : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<string>
{
    [HttpPost]
    public override async Task<string> HandleAsync(CancellationToken cancellationToken = default)
    {
        // Kreiranje država
        var countries = new List<Country>
        {
            new Country { Name = "Bosnia and Herzegovina" },
            new Country { Name = "Croatia" },
            new Country { Name = "Germany" },
            new Country { Name = "Austria" },
            new Country { Name = "USA" }
        };

        // Kreiranje gradova
        var cities = new List<City>
        {
            new City { Name = "Sarajevo", Country = countries[0] },
            new City { Name = "Mostar", Country = countries[0] },
            new City { Name = "Zagreb", Country = countries[1] },
            new City { Name = "Berlin", Country = countries[2] },
            new City { Name = "Vienna", Country = countries[3] },
            new City { Name = "New York", Country = countries[4] },
            new City { Name = "Los Angeles", Country = countries[4] }
        };

        // Kreiranje korisnika s ulogama
        var users = new List<MyAppUser>
        {
            new MyAppUser
            {
                Username = "admin1",
                Password = "admin123",
                FirstName = "Admin",
                LastName = "One",
                IsAdmin = true, 
                IsManager = false 
            },
            new MyAppUser
            {
                Username = "manager1",
                Password = "manager123",
                FirstName = "Manager",
                LastName = "One",
                IsAdmin = false,
                IsManager = true 
            },
            new MyAppUser
            {
                Username = "user1",
                Password = "user123",
                FirstName = "User",
                LastName = "One",
                IsAdmin = false, 
                IsManager = false 
            },
            new MyAppUser
            {
                Username = "user2",
                Password = "user456",
                FirstName = "User",
                LastName = "Two",
                IsAdmin = false,
                IsManager = false
            }
        };

        // Dodavanje podataka u bazu
        await db.Countries.AddRangeAsync(countries, cancellationToken);
        await db.Cities.AddRangeAsync(cities, cancellationToken);
        await db.MyAppUsers.AddRangeAsync(users, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);

        return "Data generation completed successfully.";
    }
}
