using HospitalWaitTimes.Model.Responses.Hospital;
using HospitalWaitTimes.Model.Responses.Illness;
using HospitalWaitTimes.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HospitalWaitTimes
{
    public interface IIllnessService
    {
        public Task<List<IllnessGroup>> GetIllnesses();
    }

    public class IllnessService : IIllnessService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IllnessService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<IllnessGroup>> GetIllnesses()
        {
            using var client = _httpClientFactory.CreateClient("hospitalService");

            HttpResponseMessage response = await client.GetAsync("illnesses");
            if (response.IsSuccessStatusCode)
            {
                string contents = await response.Content.ReadAsStringAsync();
                IllnessResponseRoot responseObject = JsonConvert.DeserializeObject<IllnessResponseRoot>(contents);

                return responseObject.Embedded.Illnesses.OrderBy(y => y.Illness.Name).ToList();
            }

            return new List<IllnessGroup>();
        }
    }
}
