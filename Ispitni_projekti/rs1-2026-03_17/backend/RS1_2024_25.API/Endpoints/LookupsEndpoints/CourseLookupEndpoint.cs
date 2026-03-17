using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.LookupsEndpoints.CourseLookupEndpoint;

namespace RS1_2024_25.API.Endpoints.LookupsEndpoints;

[Route("courses")]
public class CourseLookupEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<CourseLookupResponse[]>
{
    [HttpGet("lookup")]
    public override async Task<CourseLookupResponse[]> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await db.Courses
            .OrderBy(c => c.Name)
            .Select(c => new CourseLookupResponse
            {
                ID = c.ID,
                Name = c.Name
            })
            .ToArrayAsync(cancellationToken);

        return result;
    }

    public class CourseLookupResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
    }
}
