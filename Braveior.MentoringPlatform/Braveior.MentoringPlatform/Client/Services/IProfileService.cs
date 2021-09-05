using Braveior.MentoringPlatform.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Client.Services
{
    public interface IProfileService
    {
        //Task<List<AssetDTO>> GetAssets(long userId);

        Task<List<InstitutionDTO>> GetColleges();

        Task<List<UserDTO>> GetStudents(long institutionId, string key);

        Task<List<SkillDTO>> GetSkills(string key);

        Task<List<UserSkillDTO>> GetUserSkills(long userId);

        Task<StudentAchievementDTO> GetStudentAchievements(long studentId);

        Task<List<EventDTO>> GetEvents();

        Task<List<ChallengeDTO>> GetChallenges();

        Task UpdateUserSkill(UserSkillDTO userSkillDTO);

        Task UpdateUserProfile(UserDTO userDTO);

        Task DeleteUserSkill(long userSkillId);

        Task DeleteStudentActivity(long studentActivityId);
        Task<List<StudentActivityDTO>> GetStudentActivities(long userId);

        Task UpdateStudentEvent(StudentActivityDTO studentActitityDTO);

        Task UpdateStudentChallenge(StudentActivityDTO studentActitityDTO);

        Task UpdateStudentAsset(StudentActivityDTO studentActitityDTO);

        Task ResetPassword(UserDTO userDTO);

        Task ApproveStudentActivity(StudentActivityDTO studentActivityDTO);

        Task<List<StudentActivityDTO>> GetPendingStudentActivities();

        Task AddUserSkill(UserSkillDTO userSkillDTO);

        Task AddStudentEvent(StudentActivityDTO studentActivityDTO);

        Task AddStudentChallenge(StudentActivityDTO studentActivityDTO);

        Task AddStudentAsset(StudentActivityDTO studentActivityDTO);

    }
}
