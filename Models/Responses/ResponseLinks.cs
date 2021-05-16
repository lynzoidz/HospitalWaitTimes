using Newtonsoft.Json;

namespace HospitalWaitTimes.Model.Responses
{
    public class ResponseLinks
    {
        [JsonProperty("illnesses")]
        public ResponseHref IllnessLink { get; set; }

        [JsonProperty("self")]
        public ResponseHref Self { get; set; }

        [JsonProperty("next")]
        public ResponseHref Next { get; set; }
    }
}
