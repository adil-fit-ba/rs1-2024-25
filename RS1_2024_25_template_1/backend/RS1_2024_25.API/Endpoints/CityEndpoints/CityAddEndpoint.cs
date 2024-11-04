using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityAddEndpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

public class CityAddEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<CityAddRequest>
    .WithResult<CityAddResponse>
{
    [HttpPost]
    public override async Task<CityAddResponse> HandleAsync([FromBody] CityAddRequest request, CancellationToken cancellationToken = default)
    {
        var city = new City
        {
            Name = request.Name,
            CountryId = request.CountryId
        };

        db.Cities.Add(city);
        await db.SaveChangesAsync(cancellationToken);

        return new CityAddResponse
        {
            ID = city.ID,
            Name = city.Name,
            CountryId = city.CountryId
        };
    }

    public class CityAddRequest
    {
        public required string Name { get; set; }
        public required int CountryId { get; set; }
    }

    public class CityAddResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required int CountryId { get; set; }
    }
}
