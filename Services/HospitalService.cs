using HospitalWaitTimes.Model.Responses.Hospital;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HospitalWaitTimes
{
    public interface IHospitalService
    {
        public Task<List<HospitalSingle>> GetHospitals(int? levelOfPain);
    }

    public class HospitalService : IHospitalService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HospitalService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<HospitalSingle>> GetHospitals(int? levelOfPain)
        {
            using var client = _httpClientFactory.CreateClient("hospitalService");
            HttpResponseMessage response = await client.GetAsync("hospitals");

            if (response.IsSuccessStatusCode)
            {
                HospitalResponseRoot responseObject = JsonConvert.DeserializeObject<HospitalResponseRoot>(await response.Content.ReadAsStringAsync());

                if(levelOfPain != null && levelOfPain >= 0 && levelOfPain <= 4)
                    responseObject.Embedded.Hospitals.ForEach(x => x.WaitingList.RemoveAll(y => y.LevelOfPain != levelOfPain));

                return responseObject.Embedded.Hospitals.OrderBy(hospital => 
                    hospital.WaitingList.Min(list => list.AverageProcessTime))
                .ToList();
            }

            return new List<HospitalSingle>();
        }
    }
}
