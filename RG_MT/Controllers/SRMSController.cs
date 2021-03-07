using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RG_MT.Data;
using RG_MT.Models;
using Microsoft.EntityFrameworkCore;

namespace RG_MT.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SRMSController : ControllerBase
    {
       
        
        private readonly SRMSContext _context;
        public SRMSController(SRMSContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("summary")]
        public IActionResult GetSummary()
        {
            return Ok(new SummaryDataStore(_context).Summaries);
        }

    }
}
