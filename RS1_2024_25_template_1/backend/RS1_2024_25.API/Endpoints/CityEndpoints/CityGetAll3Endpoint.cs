using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityGetAll3Endpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

//sa paging i sa filterom
[Route("cities")]
public class CityGetAll3Endpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<CityGetAll3Request>
    .WithResult<MyPagedList<CityGetAll3Response>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<CityGetAll3Response>> HandleAsync([FromQuery] CityGetAll3Request request, CancellationToken cancellationToken = default)
    {
        // Kreiranje osnovnog query-a
        var query = db.Cities
            .AsQueryable();

        // Primjena filtera na osnovu naziva grada
        if (!string.IsNullOrWhiteSpace(request.FilterCityName))
        {
            query = query.Where(c => c.Name.Contains(request.FilterCityName));
        }

        // Primjena filtera na osnovu naziva zemlje
        if (!string.IsNullOrWhiteSpace(request.FilterCountryName))
        {
            query = query.Where(c => c.Country != null && c.Country.Name.Contains(request.FilterCountryName));
        }

        // Projektovanje u rezultatni tip
        var projectedQuery = query.Select(c => new CityGetAll3Response
        {
            ID = c.ID,
            Name = c.Name,
            CountryName = c.Country != null ? c.Country.Name : ""
        });

        // Kreiranje paginiranog odgovora sa filterom
        var result = await MyPagedList<CityGetAll3Response>.CreateAsync(projectedQuery, request, cancellationToken);


        return result;
    }
    public class CityGetAll3Request : MyPagedRequest //naslijeđujemo
    {
        public string FilterCityName { get; set; } = string.Empty;
        public string FilterCountryName { get; set; } = string.Empty;
    }

    public class CityGetAll3Response
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string CountryName { get; set; }
    }
}