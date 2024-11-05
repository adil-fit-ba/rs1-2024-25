﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using static RS1_2024_25.API.Endpoints.CityEndpoints.CityGetByIdEndpoint;

namespace RS1_2024_25.API.Endpoints.CityEndpoints;

public class CityGetByIdEndpoint: MyEndpointBaseAsync
    .WithRequest<int>
    .WithResult<CityGetByIdResponse>
{
    ApplicationDbContext db;

    public CityGetByIdEndpoint(ApplicationDbContext db)
    {
        this.db = db;
    }

    [HttpGet("{id}")]
    public override async Task<CityGetByIdResponse> HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var city = await db.Cities
                            .Where(c => c.ID == id)
                            .Select(c => new CityGetByIdResponse
                            {
                                ID = c.ID,
                                Name = c.Name,
                                CountryName = c.Country != null ? c.Country.Name : "",
                                CountryId = c.CountryId
                            })
                            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (city == null)
            throw new KeyNotFoundException("City not found");

        return city;
    }

    public class CityGetByIdResponse
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string CountryName { get; set; }
        public required int CountryId { get; set; }
    }
}
