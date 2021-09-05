using Braveior.MentoringPlatform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Services.Interfaces
{
    public interface IProfileService
    {
        ProfileDTO GetProfile(long userId);

        List<ProfileDTO> GetProfiles();

        List<StudentActivityDTO> GetPendingStudentActivties();

        List<ProfileDTO> GetProfiles(long institutionId);
        //List<AssetDTO> GetAssets(long userId);

        List<InstitutionDTO> GetColleges();

        List<UserDTO> GetUsers(long institutionId,string key);

        List<SkillDTO> GetSkills(string key);

        void UpdateProfile(UserDTO userDTO);

        List<EventDTO> GetEvents();

        List<ChallengeDTO> GetChallenges();

        List<UserSkillDTO> GetUserSkills(long userId);

        void UpdateUserSkill(UserSkillDTO userSkillDTO);

        List<StudentActivityDTO> GetStudentActivities(long userId);

        void UpdateStudentEvent(StudentActivityDTO studentActitityDTO, bool IsAdmin);

        void UpdateStudentChallenge(StudentActivityDTO studentActitityDTO, bool IsAdmin);

        void UpdateStudentAsset(StudentActivityDTO studentActitityDTO,bool IsAdmin);

        void ApproveStudentActivity(StudentActivityDTO studentActitityDTO);

        StudentAchievementDTO GetStudentAchievements(long studentId);
        void ResetPassword(UserDTO userDTO);

        void DeleteUserSkill(long userSkillId);

        void DeleteStudentActivity(long studentActivityId);

        void AddUserSkill(UserSkillDTO userSkillDTO);

        void AddStudentEvent(StudentActivityDTO studentActivityDTO, bool IsAdmin);

        void AddStudentChallenge(StudentActivityDTO studentActivityDTO, bool IsAdmin);

        void AddStudentAsset(StudentActivityDTO studentActivityDTO, bool IsAdmin);


    }
}
