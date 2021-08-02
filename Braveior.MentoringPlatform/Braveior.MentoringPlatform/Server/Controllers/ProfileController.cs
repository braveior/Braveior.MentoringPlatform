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
    //[Authorize]
    public class ProfileController : ControllerBase
    {

        private IProfileService _service;
        public ProfileController(IProfileService service)
        {
            _service = service;
        }
        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getprofile/{userId}")]
        public IActionResult GetStory(long userId)
        {
            return Ok(_service.GetProfile(userId));
        }
        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getassets/{userId}")]
        public IActionResult GetAssets(long userId)
        {
            return Ok(_service.GetAssets(userId));
        }
    }
}
