using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Repository.Models;
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
    
    public class WebinarController : ControllerBase
    {

        private IWebinarService _service;
        public WebinarController(IWebinarService service)
        {
            _service = service;
        }

        [HttpGet("getbootcampactivity/{bootCampActivityId}")]
        public IActionResult GetBootCampActivity(long bootCampActivityId)
        {
            return Ok(_service.GetBootCampActivity(bootCampActivityId));
        }
        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getbootcampactivities")]
        public IActionResult GetBootCampActivities()
        {
            return Ok(_service.GetBootCampActivities());
        }

        [HttpGet("getbootcamps")]
        public IActionResult GetBootCamps()
        {
            return Ok(_service.GetBootCamps());
        }

        [HttpPost("addbootcampactivity")]
        public IActionResult AddBootCampActivity(BootCampActivityDTO bootCampActivityDTO)
        {
            _service.AddBootCampActivity(bootCampActivityDTO);
            return Ok();
        }

        [HttpPost("updatebootcampactivity")]
        public IActionResult UpdateBootCampActivity(BootCampActivityDTO bootCampActivityDTO)
        {
            _service.UpdateBootCampActivity(bootCampActivityDTO);
            return Ok();
        }

        [HttpDelete("deletebootcampactivity")]
        public IActionResult DeleteBootCampActivity(long bootCampActivityId)
{
            _service.DeleteBootCampActivity(bootCampActivityId);
            return Ok();
        }

       


    }
}
