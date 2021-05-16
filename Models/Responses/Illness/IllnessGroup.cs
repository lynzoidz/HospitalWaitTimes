using Newtonsoft.Json;

namespace HospitalWaitTimes.Model.Responses.Illness
{
    public class IllnessGroup
    {
        [JsonProperty("illness")]
        public IllnessSingle Illness { get; set; }

        [JsonProperty("_links")]
        public ResponseLinks Links { get; set; }
    }
}
