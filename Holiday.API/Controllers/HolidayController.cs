using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Holiday.API.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Holiday.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidayController : ControllerBase
    {
        [HttpGet("/api/GetAllCountries")]
        [SwaggerOperation(Summary = "Get all countries", Description = "Returns a list with the code for querying holidays for all available countries.")]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = $"https://date.nager.at/api/v3/AvailableCountries";

                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        List<Countries>? countries = JsonConvert.DeserializeObject<List<Countries>>(content);

                        if (countries != null && countries.Count > 0)
                        {
                            return Ok(countries);
                        }
                        else
                        {
                            var errorObject = new { Error = "No countries were found!" };

                            return NotFound(errorObject);
                        }
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/GetHoliday/{year}/{countryCode}")]
        [SwaggerOperation(Summary = "Gets all public holidays", Description = "Returns a list of all public holidays for a given country and a given year.")]
        public async Task<IActionResult> GetHoliday([Range(2000, 2099, ErrorMessage = "The year must have 4 digits.")] int year, [StringLength(2, MinimumLength = 2, ErrorMessage = "Country code must be 2 characters long.")] string countryCode)
        
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = $"https://date.nager.at/api/v3/PublicHolidays/{year}/{countryCode}";

                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        List<Models.Holiday>? holidays = JsonConvert.DeserializeObject<List<Models.Holiday>>(content);

                        if (holidays != null && holidays.Count > 0)
                        {                            
                            return Ok(holidays);
                        }
                        else
                        {
                            var errorObject = new { Error = "No holidays were found!" };

                            return NotFound(errorObject);
                        }
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}