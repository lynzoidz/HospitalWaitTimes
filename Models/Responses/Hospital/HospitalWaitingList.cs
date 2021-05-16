using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWaitTimes.Model.Responses.Hospital
{
    public class HospitalWaitingList
    {
        [JsonProperty("patientCount")]
        public int PatientCount { get; set; }

        [JsonProperty("levelOfPain")]
        public int LevelOfPain { get; set; }

        [JsonProperty("averageProcessTime")]
        public int AverageProcessTime { get; set; }
    }
}
