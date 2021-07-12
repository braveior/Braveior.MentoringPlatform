using Braveior.MentoringPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class KanboardController : ControllerBase
    {

        private IKanboardService _service;
        public KanboardController(IKanboardService service)
        {
            _service = service;
        }
        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("gettasks/{kanboardid}")]
        public IActionResult GetTasks(long kanboardid)
        {
            var tasks = _service.GetTasks(kanboardid);
            return Ok(tasks);
        }

    }
}
