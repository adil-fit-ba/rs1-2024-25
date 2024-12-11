namespace RS1_2024_25.API.Endpoints.DataSeedEndpoints;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Enums;
using RS1_2024_25.API.Data.Models.SharedTables;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic;
using RS1_2024_25.API.Helper.Api;
using System;
using System.Collections.Generic;
using System.Linq;
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
        if (db.MyAppUsers.Any())
        {
            throw new Exception("Podaci su vec generisani");
        }

        // Kreiranje država
        var countries = new List<Country>
        {
            new Country { Name = "Bosnia and Herzegovina" },
            new Country { Name = "Croatia" },
            new Country { Name = "Germany" },
            new Country { Name = "Austria" },
            new Country { Name = "USA" }
        };

        // Kreiranje regija
        var regions = new List<Region>
        {
            new Region { Name = "Federation of Bosnia and Herzegovina", Country = countries[0] },
            new Region { Name = "Republika Srpska", Country = countries[0] },
            new Region { Name = "Dalmatia", Country = countries[1] },
            new Region { Name = "Bavaria", Country = countries[2] },
            new Region { Name = "nn", Country = countries[4] }
        };

        // Kreiranje gradova
        var cities = new List<City>
        {
            new City { Name = "Sarajevo", Country = countries[0], Region = regions[0]  },
            new City { Name = "Mostar", Country = countries[0], Region = regions[0]  },
            new City { Name = "Zagreb", Country = countries[1], Region = regions[0] },
            new City { Name = "Berlin", Country = countries[2], Region = regions[0] },
            new City { Name = "Vienna", Country = countries[3], Region = regions[0] },
            new City { Name = "New York", Country = countries[4], Region = regions[0] },
            new City { Name = "Los Angeles", Country = countries[4], Region = regions[0] }
        };

        // Kreiranje opština
        var municipalities = new List<Municipality>
        {
            new Municipality { Name = "Centar", City = cities[0], Region = regions[0] },
            new Municipality { Name = "Stari Grad", City = cities[0], Region = regions[0] },
            new Municipality { Name = "Mostar", City = cities[1], Region = regions[0] },
            new Municipality { Name = "Donji Grad", City = cities[2], Region = regions[2] },
            new Municipality { Name = "Charleston", City = cities[6], Region = regions[4] }
        };

        // Kreiranje tenant-a (univerziteta)
        var tenants = new List<Tenant>
        {
            new Tenant { Name = "University of Sarajevo", DatabaseConnection = "db_conn_sarajevo", ServerAddress = "192.168.1.1" },
            new Tenant { Name = "University of Mostar", DatabaseConnection = "db_conn_mostar", ServerAddress = "192.168.1.2" }
        };

        // Kreiranje fakulteta
        var faculties = new List<Faculty>
        {
            new Faculty { Name = "Faculty of Computer Science" },
            new Faculty { Name = "Faculty of Mathematics" }
        };

        foreach (var x in faculties)
        {
            x.Tenant = tenants[0];
        }


        // Kreiranje akademskih godina
        var academicYears = new List<AcademicYear>
        {
            new AcademicYear { StartDate = new DateOnly(2024, 9, 1), EndDate = new DateOnly(2025, 6, 30), Description = "Academic Year 2024/2025" },
            new AcademicYear { StartDate = new DateOnly(2023, 9, 1), EndDate = new DateOnly(2024, 6, 30), Description = "Academic Year 2023/2024" }
        };

        // Kreiranje korisnika s ulogama
        var users = new List<MyAppUser>
        {
            new MyAppUser
            {
                Email = "admin",
                FirstName = "Admin",
                LastName = "One",
                IsAdmin = true,
                IsDean = false
            },
            new MyAppUser
            {
                Email = "manager",
                FirstName = "Manager",
                LastName = "One",
                IsAdmin = false,
                IsDean = true
            },
            new MyAppUser
            {
                Email = "user1",
                FirstName = "User",
                LastName = "One",
                IsAdmin = false,
                IsDean = false
            },
            new MyAppUser
            {
                Email = "user2",
                FirstName = "User",
                LastName = "Two",
                IsAdmin = false,
                IsDean = false
            }
        };

        foreach (var x in users)
        {
            x.SetPassword("test");
            x.Tenant = tenants[0];
        }

        // Kreiranje profesora
        var professors = new List<Professor>
        {
            new Professor
            {
                User = users[0], // Povezano s adminom
                Title = "Dr.",
                Department = "Računarstvo",
                HireDate = DateTime.Now.AddYears(-10),
                Biography = "Iskusan profesor računarstva."
            },
            new Professor
            {
                User = users[1], // Povezano s managerom
                Title = "Prof.",
                Department = "Matematika",
                HireDate = DateTime.Now.AddYears(-15),
                Biography = "Ekspert za matematiku."
            }
        };

        foreach (var x in professors)
        {
            x.Tenant = tenants[0];
        }

        // Kreiranje studenata
        var students = new List<Student>
        {
            new Student
            {
                User = users[2], // Povezano s user1
                ParentName = "Parent One",
                BirthDate = new DateOnly(2000, 5, 15),
                Gender = Gender.Male,
                Citizenship = countries[0],
                BirthPlace = "Sarajevo",
                StudentNumber = "20240001",
                ContactMobilePhone = "+38761123456",
                ContactPrivateEmail = "student1@example.com"
            },
            new Student
            {
                User = users[3], // Povezano s user2
                ParentName = "Parent Two",
                BirthDate = new DateOnly(1999, 8, 10),
                Gender = Gender.Female,
                Citizenship = countries[0],
                BirthPlace = "Mostar",
                StudentNumber = "20240002",
                ContactMobilePhone = "+38761234567",
                ContactPrivateEmail = "student2@example.com"
            }
        };

        foreach (var x in students)
        {
            x.Tenant = tenants[0];
            x.BirthMunicipality = municipalities[0];
        }

        // Dodavanje podataka u bazu
        await db.Countries.AddRangeAsync(countries, cancellationToken);
        await db.Cities.AddRangeAsync(cities, cancellationToken);
        await db.Tenants.AddRangeAsync(tenants, cancellationToken);
        await db.Faculties.AddRangeAsync(faculties, cancellationToken);
        await db.AcademicYears.AddRangeAsync(academicYears, cancellationToken);
        await db.MyAppUsers.AddRangeAsync(users, cancellationToken);
        await db.Professors.AddRangeAsync(professors, cancellationToken);
        await db.Students.AddRangeAsync(students, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);

        return "Data generation completed successfully.";
    }
}
