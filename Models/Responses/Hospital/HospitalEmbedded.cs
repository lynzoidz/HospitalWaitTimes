using Newtonsoft.Json;
using System.Collections.Generic;

namespace HospitalWaitTimes.Model.Responses.Hospital
{
    public class HospitalEmbedded
    {
        [JsonProperty("hospitals")]
        public List<HospitalSingle> Hospitals { get; set; }
    }
}
