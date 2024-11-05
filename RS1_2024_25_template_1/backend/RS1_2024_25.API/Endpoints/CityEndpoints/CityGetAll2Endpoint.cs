using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityGetAll1Endpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

//sa paging i bez filtera
public class CityGetAll2Endpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<MyPagingRequest>
    .WithResult<MyPagedList<CityGetAll1Response>>
{
    [HttpGet]
    public override async Task<MyPagedList<CityGetAll1Response>> HandleAsync([FromQuery] MyPagingRequest request, CancellationToken cancellationToken = default)
    {
        var query = db.Cities
                        .Select(c => new CityGetAll1Response
                        {
                            ID = c.ID,
                            Name = c.Name,
                            CountryName = c.Country != null ? c.Country.Name : ""
                        });

        var result = await MyPagedList<CityGetAll1Response>.CreateAsync(query, request, cancellationToken);

        return result;
    }

    public class CityGetAll2Response
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string CountryName { get; set; }
    }
}