using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fighters_api.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fighters_api.Controllers
{
    [EnableCors("Cors")]
    [ApiController]
    public class FighterController : ControllerBase
    {
        private IFighterData _fighterData;
        public FighterController(IFighterData fighterData)
        {
            _fighterData = fighterData;
        }
        // GET: api/values
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            return Ok(_fighterData.GetFighters());
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetFighter(int id)
        {
            var fighter = _fighterData.GetFighter(id);
            if (fighter != null)
            {
                return Ok(fighter);
            }
            return NotFound($"Fighter with Id: {id} was not found.");
        }

        // POST api/values
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddFighter(Fighters fighter)
        {
            _fighterData.AddFighter(fighter);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + fighter.id, fighter);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditFighter(int id, Fighters fighter)
        {
            var existingFighter = _fighterData.GetFighter(id);
            if (existingFighter != null)
            {
                fighter.id = existingFighter.id;
                _fighterData.EditFighter(fighter);
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteFighter(int id)
        {
            var fighter = _fighterData.GetFighter(id);
            if (fighter != null)
            {
                _fighterData.DeleteFighter(fighter);
                return Ok();
            }
            return NotFound($"Fighter was not found id: {id}");
        }
    }
}
