using Newtonsoft.Json;

namespace HospitalWaitTimes.Model.Responses
{
    public class ResponseHref
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
