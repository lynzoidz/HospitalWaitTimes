using Newtonsoft.Json;
using System.Collections.Generic;

namespace HospitalWaitTimes.Model.Responses.Illness
{
    public class IllnessEmbedded
    {
        [JsonProperty("illnesses")]
        public List<IllnessGroup> Illnesses { get; set; }
    }
}
