using System;
using fighters_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace fighters_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Fight2Controller:ControllerBase
    {
        private IFightData _fightData;
        public Fight2Controller(IFightData fightData)
        {
            _fightData = fightData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetFights()
        {
            return Ok(_fightData.GetFights());
        }
    }
}
