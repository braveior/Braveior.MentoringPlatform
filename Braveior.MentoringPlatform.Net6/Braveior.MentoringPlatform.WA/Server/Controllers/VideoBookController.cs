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
    
    public class VideoBookController : ControllerBase
    {

        private IVideoBookService _service;
        public VideoBookController(IVideoBookService service)
        {
            _service = service;
        }

        [HttpGet("getvideobooks/{videoBookId}")]
        public IActionResult GetVideoBook(long videoBookId)
        {
            return Ok(_service.GetVideoBook(videoBookId));
        }
        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getvideobooks")]
        public IActionResult GetVideoBooks()
        {
            return Ok(_service.GetVideoBooks());
        }

        [HttpGet("getvideobooklessons/{videoBookId}")]
        public IActionResult GetVideoBookLessons(long videoBookId)
        {
            return Ok(_service.GetVideoBookLessons(videoBookId));
        }

        [HttpPost("addvideobook")]
        public IActionResult AddVideoBook(VideoBookDTO videoBookDTO)
        {
            _service.AddVideoBook(videoBookDTO);
            return Ok();
        }

        [HttpPost("addvideobooklesson")]
        public IActionResult AddVideoBookLesson(LessonDTO videoBookLessonDTO)
        {
            _service.AddVideoBookLesson(videoBookLessonDTO);
            return Ok();
        }

        [HttpPost("updatevideobook")]
        public IActionResult UpdateVideoBook(VideoBookDTO videoBookDTO)
        {
            _service.UpdateVideoBook(videoBookDTO);
            return Ok();
        }

        [HttpPost("updatevideobooklesson")]
        public IActionResult UpdateVideoBookLesson(LessonDTO videoBookLessonDTO)
        {
            _service.UpdateVideoBookLesson(videoBookLessonDTO);
            return Ok();
        }

        [HttpDelete("deletevideobook/{videoBookId}")]
        public IActionResult DeleteVideoBook(long videoBookId)
        {
            _service.DeleteVideoBook(videoBookId);
            return Ok();
        }

        [HttpDelete("deletevideobooklesson/{videoBookLessonId}")]
        public IActionResult DeleteVideoBookLesson(long videoBookLessonId)
        {
            _service.DeleteVideoBookLesson(videoBookLessonId);
            return Ok();
        }




    }
}
