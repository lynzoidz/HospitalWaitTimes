using Newtonsoft.Json;

namespace HospitalWaitTimes.Model.Responses
{
    public class ResponsePageInformation
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("totalElements")]
        public int TotalElements { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }
    }
}
