using Braveior.MentoringPlatform.DTO;
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
        public IActionResult GetProfile(long userId)
        {


            return Ok(_service.GetProfile(userId));
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getprofiles")]
        public IActionResult GetProfiles()
        {
            return Ok(_service.GetProfiles());
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getpendingstudentactivities")]
        [Authorize]
        public IActionResult GetPendingStudentActivties()
        {
            return Ok(_service.GetPendingStudentActivties());
        }

        

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getprofiles/{institutionId}")]
        [Authorize]
        public IActionResult GetProfiles(long institutionId)
        {
            return Ok(_service.GetProfiles(institutionId));
        }
        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        //[HttpGet("getassets/{userId}")]
        //public IActionResult GetAssets(long userId)
        //{
        //    return Ok(_service.GetAssets(userId));
        //}

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getcolleges")]
        [Authorize]
        public IActionResult GetColleges()
        {
            return Ok(_service.GetColleges());
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getstudents/{collegeId}/{key}")]
        [Authorize]
        public IActionResult GetStudents(long collegeId, string key)
        {
            return Ok(_service.GetUsers(collegeId,key));
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getskills/{key}")]
        [Authorize]
        public IActionResult GetSkills(string key)
        {
            return Ok(_service.GetSkills(key));
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getuserskills/{userId}")]
        [Authorize]
        public IActionResult GetUserSkills(long userId)
        {
            var accessToken = HttpContext;
            var accessToken1 = Request.Headers["Authorization"];
            return Ok(_service.GetUserSkills(userId));
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getchallenges")]
        [Authorize]
        public IActionResult GetChallenges()
        {
            return Ok(_service.GetChallenges());
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getevents")]
        [Authorize]
        public IActionResult GetEvents()
        {
            return Ok(_service.GetEvents());
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpGet("getstudentactivities/{userId}")]
        [Authorize]
        public IActionResult GetStudentActivities(long userId)
        {
            return Ok(_service.GetStudentActivities(userId));
        }

        [HttpGet("getstudentachievements/{studentId}")]
        [Authorize]
        public IActionResult GetStudentAchievements(long studentId)
        {
            return Ok(_service.GetStudentAchievements(studentId));
        }
        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("updateuserskill")]
        [Authorize]
        public IActionResult UpdateUserSkill(UserSkillDTO userSkillDTO)
        {
            _service.UpdateUserSkill(userSkillDTO);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("approvestudentactivity")]
        [Authorize]
        public IActionResult ApproveStudentActivity(StudentActivityDTO studentActivityDTO)
        {
            _service.ApproveStudentActivity(studentActivityDTO);
            return Ok();
        }
        

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("resetpassword")]
        [Authorize]
        public IActionResult ResetPassword(UserDTO userDTO)
        {
            _service.ResetPassword(userDTO);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("updateuserprofile")]
        [Authorize]
        public IActionResult UpdateProfile(UserDTO userDTO)
        {
            _service.UpdateProfile(userDTO);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpDelete("deleteuserskill/{userSkillId}")]
        [Authorize]
        public IActionResult DeleteUserSkill(long userSkillId)
        {
            _service.DeleteUserSkill(userSkillId);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpDelete("deletestudentactivity/{studentActivityId}")]
        [Authorize]
        public IActionResult DeleteStudentActivity(long studentActivityId)
        {
            _service.DeleteStudentActivity(studentActivityId);
            return Ok();
        }
        
        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("updatestudentevent")]
        [Authorize]
        public IActionResult UpdateStudentEvent(StudentActivityDTO studentActivityDTO)
        {
            bool isAdmin = false;
            if (HttpContext.User.Claims.Where(a => a.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").FirstOrDefault().Value == "2")
            {
                isAdmin = true;
            }
            _service.UpdateStudentEvent(studentActivityDTO,isAdmin);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("updatestudentchallenge")]
        [Authorize]
        public IActionResult UpdateStudentChallenge(StudentActivityDTO studentActivityDTO)
        {
            bool isAdmin = false;
            if (HttpContext.User.Claims.Where(a => a.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").FirstOrDefault().Value == "2")
            {
                isAdmin = true;
            }
            _service.UpdateStudentChallenge(studentActivityDTO,isAdmin);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("updatestudentasset")]
        [Authorize]
        public IActionResult UpdateStudentAsset(StudentActivityDTO studentActivityDTO)
        {
            bool isAdmin = false;
            if (HttpContext.User.Claims.Where(a => a.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").FirstOrDefault().Value == "2")
            {
                isAdmin = true;
            }
            _service.UpdateStudentAsset(studentActivityDTO, isAdmin);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("addstudentskill")]
        [Authorize]
        public IActionResult AddStudentSkill(UserSkillDTO userSkillDTO)
        {
            _service.AddUserSkill(userSkillDTO);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("addstudentevent")]
        [Authorize]
        public IActionResult AddStudentEvent(StudentActivityDTO studentActivityDTO)
        {
            bool isAdmin = false;
            if (HttpContext.User.Claims.Where(a => a.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").FirstOrDefault().Value == "2")
            {
                isAdmin = true;
            }
            _service.AddStudentEvent(studentActivityDTO,isAdmin);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("addstudentchallenge")]
        [Authorize]
        public IActionResult AddStudentChallenge(StudentActivityDTO studentActivityDTO)
        {
            bool isAdmin = false;
            if (HttpContext.User.Claims.Where(a => a.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").FirstOrDefault().Value == "2")
            {
                isAdmin = true;
            }
            _service.AddStudentChallenge(studentActivityDTO,isAdmin);
            return Ok();
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("addstudentasset")]
        [Authorize]
        public IActionResult AddStudentAsset(StudentActivityDTO studentActivityDTO)
        {
            bool isAdmin = false;
            if (HttpContext.User.Claims.Where(a => a.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").FirstOrDefault().Value == "2")
            {
                isAdmin = true;
            }
            _service.AddStudentAsset(studentActivityDTO,isAdmin);
            return Ok();
        }
    }
}
