using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWaitTimes.Model.Responses.Hospital
{
    public class HospitalSingle
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("waitingList")]
        public List<HospitalWaitingList> WaitingList { get; set; }

        [JsonProperty("location")]
        public ResponseLocation Location { get; set; }
    }
}
