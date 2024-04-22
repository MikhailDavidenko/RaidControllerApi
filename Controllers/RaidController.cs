using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaidControllerApi.Interfaces.Services;

namespace RaidControllerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaidController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IRaidService _raidService;
        public RaidController(IRaidService raidService, IPlayerService playerService)
        {
            _raidService = raidService;
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult GetPlayersTimeInfo()
        {
            return Ok();
        }

        [HttpPost("start")]
        public IActionResult StartRaid()
        {
            int id = _raidService.StartRaid();

            if (id == 0) return StatusCode(401);
            _playerService.ChangeRaidId(id);
            return Ok(id);
        }

        [HttpPost("finish")]
        public IActionResult FinishRaid([FromQuery] int id)
        {
            if (id <= 0)
            {
                return StatusCode(402);
            }
            bool res = _raidService.FinishRaid(id);
            if (res)
            {
                _playerService.ChangeStatusForAll(null);
                return Ok();
            }
            else
                return StatusCode(401);
        }


    }
}
