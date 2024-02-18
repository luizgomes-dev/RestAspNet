using System.Text.Json.Serialization;

namespace RestAspNet.Data.VO
{
    public class BookVO
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
