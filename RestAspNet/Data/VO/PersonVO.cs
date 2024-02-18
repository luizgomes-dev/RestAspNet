using AspNetCore.Hateoas.Models;
using System.Text.Json.Serialization;

namespace RestAspNet.Data.VO
{

    public class PersonVO
    {
        [JsonPropertyName("code")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address{ get; set; }
        public string Gender { get; set; }
         

    }
}
