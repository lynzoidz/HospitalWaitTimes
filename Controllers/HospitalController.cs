using HospitalWaitTimes.Model.Responses.Hospital;
using HospitalWaitTimes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalWaitTimes.Controllers
{
    [Route("Hospital")]
    public class HospitalController : Controller
    {
        private readonly IHospitalService _hospitalService;
        private AWSService _awsService;

        public HospitalController(IHospitalService hospitalService, AWSService awsService)
        {
            _hospitalService = hospitalService;
            _awsService = awsService;
        }

        public async Task<ActionResult> Index(int? level, string name, string illness)
        {
            await _awsService.DropIllnessEntryTable();
            await _awsService.CreateIllnessEntryTable();
            await _awsService.InsertUserIllnessEntry(illness, name);


            return View(await _hospitalService.GetHospitals(level));
        }
    }
}
