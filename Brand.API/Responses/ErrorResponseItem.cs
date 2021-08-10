using Newtonsoft.Json;

namespace Brand.API.Responses
{
    public class ErrorResponseItem
    {
        [JsonProperty("field")]
        public string Field { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}