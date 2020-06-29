using Newtonsoft.Json;

namespace Test.Models
{
    public partial class Books
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Author")]
        public string Author { get; set; }
    }
}
