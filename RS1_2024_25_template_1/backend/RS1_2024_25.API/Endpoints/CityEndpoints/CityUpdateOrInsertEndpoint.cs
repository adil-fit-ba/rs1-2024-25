using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityUpdateOrInsertEndpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints
{
    [Route("cities")]
    public class CityUpdateOrInsertEndpoint(ApplicationDbContext db, MyAuthService myAuthService) : MyEndpointBaseAsync
        .WithRequest<CityUpdateOrInsertRequest>
        .WithActionResult<CityUpdateOrInsertResponse>
    {
        [HttpPost]  // Using POST to support both create and update
        public override async Task<ActionResult<CityUpdateOrInsertResponse>> HandleAsync([FromBody] CityUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
        {

            MyAuthInfo myAuthInfo = myAuthService.GetAuthInfo();
            if (!myAuthInfo.IsLoggedIn)
            {
                return Unauthorized();
            }
            // Check if we're performing an insert or update based on the ID value
            bool isInsert = (request.ID == null || request.ID == 0);
            City? city;

            if (isInsert)
            {
                // Insert operation: create a new city entity
                city = new City();
                db.Cities.Add(city); // Add the new city to the context
            }
            else
            {
                // Update operation: retrieve the existing city
                city = await db.Cities.FindAsync(new object[] { request.ID }, cancellationToken);

                if (city == null)
                {
                    throw new KeyNotFoundException("City not found");
                }
            }

            // Set common properties for both insert and update operations
            city.Name = request.Name;
            city.CountryId = request.CountryId;

            // Save changes to the database
            await db.SaveChangesAsync(cancellationToken);

            return new CityUpdateOrInsertResponse
            {
                ID = city.ID,
                Name = city.Name,
                CountryId = city.CountryId
            };
        }

        public class CityUpdateOrInsertRequest
        {
            public int? ID { get; set; } // Nullable to allow null for insert operations
            public required string Name { get; set; }
            public required int CountryId { get; set; }
        }

        public class CityUpdateOrInsertResponse
        {
            public required int ID { get; set; }
            public required string Name { get; set; }
            public required int CountryId { get; set; }
        }
    }
}
