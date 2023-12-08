using Swashbuckle.AspNetCore.Annotations;

namespace Holiday.API.Models
{
    public class Countries
    {
        [SwaggerSchema(Description = "Country code for holiday search.")]
        public string? countryCode { get; set; }
        [SwaggerSchema(Description = "Name of the country.")]
        public string? name { get; set; }
    }
}
