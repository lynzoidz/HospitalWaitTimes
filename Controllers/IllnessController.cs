using HospitalWaitTimes.Model.Responses.Illness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HospitalWaitTimes.Controllers
{
    [Route("Illness")]
    public class IllnessController : Controller
    {
        private readonly IIllnessService _illnessService;

        public IllnessController(IIllnessService illnessService)
        {
            _illnessService = illnessService;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _illnessService.GetIllnesses());
        }
    }
}
