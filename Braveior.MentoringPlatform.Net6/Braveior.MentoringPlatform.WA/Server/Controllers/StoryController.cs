using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.WA.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class StoryController : ControllerBase
    {

        private IStoryService _service;
        public StoryController(IStoryService service)
        {
            _service = service;
        }


        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("createstory")]
        public IActionResult CreateStory(StoryDTO storyDTO)
        {
            _service.CreateStory(storyDTO);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("createtask")]
        public IActionResult CreateTask(TaskDTO taskDTO)
        {
            _service.CreateTask(taskDTO);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("updatestory")]
        public IActionResult UpdateStory(StoryDTO storyDTO)
        {
            _service.UpdateStory(storyDTO);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("updatetask")]
        public IActionResult UpdateTask(TaskDTO taskDTO)
        {
            _service.UpdateTask(taskDTO);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getstory/{storyId}")]
        public IActionResult GetStory(long storyId)
        {
            return Ok(_service.GetStory(storyId));
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("gettask/{taskId}")]
        public IActionResult GetTask(long taskId)
        {
            return Ok(_service.GetTask(taskId));
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("gettasks")]
        public IActionResult GetTasks(long storyId)
        {
            return Ok(_service.GetTasks(storyId));
        }


        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getstories/{kanboardId}")]
        public IActionResult GetStories(long kanboardId)
        {

            return Ok(_service.GetStories(kanboardId));
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        //[HttpGet("getkanboardstories/{userId}")]
        //public IActionResult GetKanboardStories(long userId)
        //{
        //    return Ok(_service.GetKanboardStories(userId));
        //}

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getkanboard/{kanboardId}")]
        public IActionResult GetKanboard(long kanboardId)
        {
            var test = HttpContext.User;
            return Ok(_service.GetKanboard(kanboardId));
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("updatetaskstatus")]
        public IActionResult UpdateTaskStatus(TaskDTO taskDTO)
        {
            _service.UpdateTaskStatus(taskDTO);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("updatestorystatus")]
        public IActionResult UpdateStoryStatus(StoryDTO storyDTO)
        {
            _service.UpdateStoryStatus(storyDTO);
            return Ok();
        }


    }
}
