using Swashbuckle.AspNetCore.Annotations;

namespace Holiday.API.Models
{
    public class Holiday
    {
        [SwaggerSchema(Description = "Holiday date.")]
        public DateTime Date { get; set; }

        [SwaggerSchema(Description = "Name of the holiday in the country.")]
        public string? LocalName { get; set; }

        [SwaggerSchema(Description = "Holiday name.")]
        public string? Name { get; set; }

        [SwaggerSchema(Description = "Country code for holiday search.")]
        public string? CountryCode { get; set; }

        [SwaggerSchema(Description = "Is this public holiday every year on the same date.")]        
        public bool Fixed { get; set; }

        [SwaggerSchema(Description = "Is this public holiday in every county (federal state).")]
        public bool Global { get; set; }

        [SwaggerSchema(Description = "If it is not global you found here the Federal states (ISO-3166-2).")]
        public List<string>? Counties { get; set; }

        [SwaggerSchema(Description = "The launch year of the public holiday.")]
        public int? LaunchYear { get; set; }

        [SwaggerSchema(Description = "The types of the public holiday, several possible\r\nPublic\r\nBank (Bank holiday, banks and offices are closed)\r\nSchool (School holiday, schools are closed)\r\nAuthorities (Authorities are closed)\r\nOptional (Majority of people take a day off)\r\nObservance (Optional festivity, no paid day off).")]
        public List<string>? Types { get; set; }
    }
}
