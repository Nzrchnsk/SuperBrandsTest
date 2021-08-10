using System.Collections.Generic;
using Newtonsoft.Json;

namespace Product.API.Responses
{
    public class ErrorResponse
    {
        [JsonProperty("errors")]
        public List<ErrorResponseItem> Errors = new List<ErrorResponseItem>();
    }
}