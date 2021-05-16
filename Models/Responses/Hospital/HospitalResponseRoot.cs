using Newtonsoft.Json;

namespace HospitalWaitTimes.Model.Responses.Hospital
{
    public class HospitalResponseRoot
    {
        [JsonProperty("_embedded")]
        public HospitalEmbedded Embedded { get; set; }

        [JsonProperty("_links")]
        public ResponseLinks Links { get; set; }

        [JsonProperty("page")]
        public ResponsePageInformation Page { get; set; }
    }
}
