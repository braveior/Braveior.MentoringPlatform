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
        public IActionResult GetStudentActivities(long userId)
        {
            return Ok(_service.GetStudentActivities(userId));
        }

        /// <summary>
        /// Endpoint to get monthly average ratings for member
        /// </summary>
        /// <param name="ratedfor"></param>
        /// <returns></returns>
        [HttpPost("updateuserskill")]
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
