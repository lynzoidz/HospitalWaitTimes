using Newtonsoft.Json;

namespace HospitalWaitTimes.Model.Responses.Illness
{
    public class IllnessResponseRoot
    {
        [JsonProperty("_embedded")]
        public IllnessEmbedded Embedded { get; set; }

        [JsonProperty("_links")]
        public ResponseLinks Links { get; set; }

        [JsonProperty("page")]
        public ResponsePageInformation Page { get; set; }
    }
}
