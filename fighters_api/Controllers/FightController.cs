using fighters_api.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fighters_api.Controllers
{
    [EnableCors("Cors")]
    [ApiController]
    public class FightController : ControllerBase
    {
        private IFightData _fightData;
        public FightController(IFightData fightData)
        {
            _fightData = fightData;
        }
        // GET: api/values
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        { 
            return Ok(_fightData.GetFights());
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetFight(int id)
        {
            var fight = _fightData.GetFight(id);
            if(fight != null)
            {
                return Ok(fight);
            }
            return NotFound($"Fight with Id: {id} was not found.");
        }

        // POST api/values
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddFight(Fight fight)
        {
            _fightData.AddFight(fight);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + fight.id, fight);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditFight(int id, Fight fight)
        {
            var existingFight = _fightData.GetFight(id);
            if(existingFight != null)
            {
                fight.id = existingFight.id;
                _fightData.EditFight(fight);
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteFight(int id)
        {
            var fight = _fightData.GetFight(id);
            if(fight != null)
            {
                _fightData.DeleteFight(fight);
                return Ok();
            }
            return NotFound($"Fight was not found id: {id}");
        }
    }
}
