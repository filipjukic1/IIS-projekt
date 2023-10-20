using Newtonsoft.Json;

namespace API.Model
{
    public class Beer
    {
        [JsonProperty("title")]
        public string title { get; set; }



        [JsonProperty("alcohol")]
        public string alchool { get; set; }



        [JsonProperty("description")]
        public string description { get; set; }
    }
}
