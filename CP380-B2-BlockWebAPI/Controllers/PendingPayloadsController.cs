using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        private PendingPayloads pending_Payloads;
        public PendingPayloadsController(PendingPayloads pendingPayloads)
        {
            pending_Payloads = pendingPayloads;
        }

        [HttpGet]
        [Route("/PendingPayloads")]
        public string GetLatestBlocks()
        {
            return JsonConvert.SerializeObject(pending_Payloads.Payloads);
        }

        [HttpPost]
        [Route("/PendingPayloads")]
        public string AddPayload (Payload payload)
        {
            pending_Payloads.Payloads.Add(payload);
            return JsonConvert.SerializeObject("Added Successfully..!!");
        }
    }
}
