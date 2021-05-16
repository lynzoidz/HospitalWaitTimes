using Newtonsoft.Json;

namespace HospitalWaitTimes.Model.Responses.Illness
{
    public class IllnessSingle
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
