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
    public class BlocksController : ControllerBase
    {
        // TODO

        [HttpGet]
        [Route("/blocks")]
        public string GetAllBlocks()
        {
            BlockList blockList = new BlockList();
            return JsonConvert.SerializeObject(blockList.Chain.Select(block => new BlockSummary()
            {
                
                TimeStamp = block.TimeStamp,
                PreviousHash = block.PreviousHash,
                Hash = block.Hash

            }));
        }

        [HttpGet]
        [Route("/blocks/{hash?}")]
        public string GetAllBlocks(string hash)
        {
            BlockList blockList = new BlockList();
            var block = blockList.Chain
                .Where(block => block.Hash.Equals(hash));

            if (block != null && block.Count() > 0)
            {
                return JsonConvert.SerializeObject(block
                    .Select(block => new BlockSummary()
                    {
                        Hash = block.Hash,
                        PreviousHash = block.PreviousHash,
                        TimeStamp = block.TimeStamp
                    }
                    )
                    .First());
            }

            return JsonConvert.SerializeObject(NotFound());
        }

        [HttpGet]
        [Route("{hash}/Payloads")]
        public string GetAllPayloads (string hash)
        {
            BlockList blockList = new BlockList();
            var block = blockList.Chain
                        .Where(block => block.Hash.Equals(hash));
            if (block != null && block.Count() > 0)
            {
                return JsonConvert.SerializeObject(block
                    .Select(block => block.Data
                    )
                    .First());
            }
            return JsonConvert.SerializeObject(NotFound());
        }
    }
}
