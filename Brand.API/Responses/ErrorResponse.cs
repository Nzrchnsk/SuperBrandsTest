using System.Collections.Generic;
using Newtonsoft.Json;

namespace Brand.API.Responses
{
    public class ErrorResponse
    {
        [JsonProperty("errors")]
        public List<ErrorResponseItem> Errors = new List<ErrorResponseItem>();
    }
}