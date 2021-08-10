using Newtonsoft.Json;

namespace Brand.API.Responses
{
    public class ErrorResponseItem
    {
        /// <summary>
        /// Поле
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; set; }
        
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}