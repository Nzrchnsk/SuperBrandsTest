using System.Collections.Generic;
using Newtonsoft.Json;

namespace Brand.API.Responses
{
    public class ErrorResponse
    {
        /// <summary>
        /// Ошибки
        /// </summary>
        [JsonProperty("errors")]
        public List<ErrorResponseItem> Errors = new List<ErrorResponseItem>();
    }
}