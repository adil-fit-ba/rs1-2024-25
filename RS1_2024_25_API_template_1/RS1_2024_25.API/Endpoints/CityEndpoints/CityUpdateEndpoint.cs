using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityUpdateEndpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints
{
    public class CityUpdateEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
        .WithRequest<CityUpdateRequest>
        .WithResult<CityUpdateResponse>
    {
        [HttpPut]
        public override async Task<CityUpdateResponse> HandleAsync([FromBody] CityUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var city = await db.Cities.FindAsync([request.ID], cancellationToken);//ili SingleOrDefault

            if (city == null)
                throw new KeyNotFoundException("City not found");

            city.Name = request.Name;
            city.CountryId = request.CountryId;

            await db.SaveChangesAsync(cancellationToken);

            return new CityUpdateResponse
            {
                ID = city.ID,
                Name = city.Name,
                CountryId = city.CountryId
            };
        }

        public class CityUpdateRequest
        {
            public required int ID { get; set; }
            public required string Name { get; set; }
            public required int CountryId { get; set; }
        }

        public class CityUpdateResponse
        {
            public required int ID { get; set; }
            public required string Name { get; set; }
            public required int CountryId { get; set; }
        }
    }
}
