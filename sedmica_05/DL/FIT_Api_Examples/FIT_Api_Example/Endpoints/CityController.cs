using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FIT_Api_Example.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(ApplicationDbContext _db) : ControllerBase
    {
        public class CityRequest
        {
            public string Name { get; set; }
            public int CountryId { get; set; }
        }
        public class CityResponse
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string CountryName { get; set; }
        }

        // GET: api/City
        [HttpGet]
        public ActionResult<CityResponse[]> GetCities()
        {
            var cities = _db.Cities
                            .Include(c => c.Country)
                            .Select(c => new CityResponse
                            {
                                ID = c.ID,
                                Name = c.Name,
                                CountryName = c.Country != null ? c.Country.Name : "Unknown"
                            })
                            .ToArray();

            return cities;
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public ActionResult<CityResponse> GetCity(int id)
        {
            var city = _db.Cities
                          .Include(c => c.Country)
                          .Where(c => c.ID == id)
                          .Select(c => new CityResponse
                          {
                              ID = c.ID,
                              Name = c.Name,
                              CountryName = c.Country != null ? c.Country.Name : "Unknown"
                          })
                          .First(); // Ako grad nije pronađen, generira se izuzetak

            return city;
        }

        // POST: api/City
        [HttpPost]
        public ActionResult<CityResponse> PostCity(CityRequest request)
        {
            var city = new City
            {
                Name = request.Name,
                CountryId = request.CountryId
            };

            _db.Cities.Add(city);
            _db.SaveChanges();

            var response = new CityResponse
            {
                ID = city.ID,
                Name = city.Name,
                CountryName = _db.Countries.Find(city.CountryId)?.Name ?? "Unknown"
            };

            return Ok(response);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public ActionResult<string> PutCity(int id, CityRequest request)
        {
            var city = _db.Cities.Find(id) ?? throw new KeyNotFoundException("City not found");

            city.Name = request.Name;
            city.CountryId = request.CountryId;

            _db.SaveChanges();

            return Ok("City updated successfully");
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCity(int id)
        {
            var city = _db.Cities.Find(id) ?? throw new KeyNotFoundException("City not found");

            _db.Cities.Remove(city);
            _db.SaveChanges();

            return Ok("City deleted successfully");
        }
    }
}
