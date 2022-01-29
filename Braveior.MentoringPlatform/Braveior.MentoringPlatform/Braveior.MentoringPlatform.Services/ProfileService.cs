using AutoMapper;
using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Repository;
using Braveior.MentoringPlatform.Repository.Models;
using Braveior.MentoringPlatform.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;

namespace Braveior.MentoringPlatform.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        braveiordbContext _dbContext;
        public ProfileService(IMapper mapper, braveiordbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public ProfileDTO GetProfile(long userId)
        {
            var user = _dbContext.Users.Where(u => u.UserId == userId).Include(i => i.Institution).Include(uk => uk.UserSkills).ThenInclude(a => a.Skill).FirstOrDefault();
                var studentWorkItems = _dbContext.StudentActivities.Where(u => u.UserId == userId && u.Status == 1).Include(a=>a.Event).Include(a => a.Challenge).ThenInclude(a=>a.Product);
                ProfileDTO profileDTO = new ProfileDTO()
                {
                    UserId = user.UserId,
                    IsLeader = user.IsLeader,
                    Points = user.Points,
                    StudentName = $"{user.FirstName} {user.LastName}",
                    LinkedInLink = user.LinkedInUrl,
                    BLevel = user.BLevel,
                    Description = user.Description,
                    Grade = user.Grade,
                    InsitutionName = user.Institution.Name,
                    UserSkills = _mapper.Map<List<UserSkillDTO>>(user.UserSkills.OrderByDescending(a=>a.Stars)),
                    StudentWorkItems = _mapper.Map<List<StudentActivityDTO>>(studentWorkItems)
                };
                return profileDTO;
        }

        public List<StudentActivityDTO> GetPendingStudentActivties()
        {
            var studentActivities = _dbContext.StudentActivities.Where(u => u.Status == 0).Include(i => i.User).ThenInclude(i=>i.Institution).ToList();
            return _mapper.Map<List<StudentActivityDTO>>(studentActivities);
        }

        public List<ProfileDTO> GetProfiles()
        {
                var students = _dbContext.Users.Where(u => u.Role == 1 && u.Display == true).Include(us => us.UserSkills).Include(i => i.Institution).Take(100).ToList();
                List<ProfileDTO> profiles = new List<ProfileDTO>();
                foreach (var student in students)
                {
                    ProfileDTO profileDTO = new ProfileDTO()
                    {
                         UserId = student.UserId,
                        StudentName = $"{student.FirstName} {student.LastName}",
                        LinkedInLink = student.LinkedInUrl,
                        Description = student.Description,
                        InsitutionName = student.Institution.Name,
                        IsLeader = student.IsLeader,
                        BLevel = student.BLevel,
                        Grade = student.Grade,
                        //TODO
                        Points = student.Points,
                        UserSkills = _mapper.Map<List<UserSkillDTO>>(student.UserSkills)
                    };
                    profiles.Add(profileDTO);
                }
                return profiles.OrderByDescending(p => p.Points).ToList();
        }

        public List<ProfileDTO> GetProfiles(long institutionId)
        {
            
            var students = _dbContext.Users.Where(u => u.Role == 1 && u.Display == true && u.InstitutionId== institutionId).Include(us => us.UserSkills).Include(i => i.Institution).ToList();
            List<ProfileDTO> profiles = new List<ProfileDTO>();
            foreach (var student in students)
            {
                ProfileDTO profileDTO = new ProfileDTO()
                {
                    UserId = student.UserId,
                    StudentName = $"{student.FirstName} {student.LastName}",
                    LinkedInLink = student.LinkedInUrl,
                    Description = student.Description,
                    InsitutionName = student.Institution.Name,
                    IsLeader = student.IsLeader,
                    BLevel = student.BLevel,
                    Grade = student.Grade,
                    //TODO
                    Points = student.Points,
                    UserSkills = _mapper.Map<List<UserSkillDTO>>(student.UserSkills)
                };
                profiles.Add(profileDTO);
            }
            return profiles.OrderByDescending(p => p.Points).ToList();
        }

        private List<ProfileDTO> GetRankedProfiles(List<ProfileDTO> profiles)
        {
            //List<ProfileDTO> rankedProfiles = new List<ProfileDTO>();
            int r = 1;
            double lastWin = -1;
            long lastRank = 1;
            Console.WriteLine("Entered");
            var rankedProfiles = (from name in profiles
                             let point = name.Points
                             orderby point descending
                             select new ProfileDTO { UserId = name.UserId, StudentName = name.StudentName, Description = name.Description, InsitutionName = name.InsitutionName, UserSkills = name.UserSkills,  Rank = r++, Points = point }).ToList();
            foreach (var rank in rankedProfiles)
            {
                if (lastWin == rank.Points)
                {
                    rank.Rank = lastRank;
                }
                lastWin = rank.Points;
                lastRank = rank.Rank;

                //yield return rank;
            }
            return rankedProfiles.OrderBy(r=>r.Rank).ToList();
        }
        public List<InstitutionDTO> GetColleges()
        {
                var colleges = _dbContext.Institutions.ToList();
                return _mapper.Map<List<InstitutionDTO>>(colleges);
        }

        public StudentAchievementDTO GetStudentAchievements(long studentId)
        {
            StudentAchievementDTO studentAchievementDTO = new StudentAchievementDTO();
            studentAchievementDTO.PointsTimeline = new List<GraphDataDTO>();
            var studentActivities = _dbContext.StudentActivities.Where(a => a.UserId == studentId && a.Status == 1).ToList().OrderBy(a=>a.CreatedDate);
            var student = _dbContext.Users.Where(a => a.UserId == studentId).FirstOrDefault();
            foreach (var studentActivitiy in studentActivities)
            {
                if (studentActivitiy.ChallengeId == 1 )
                {
                    studentAchievementDTO.Challenge1Complete = true;
                    studentAchievementDTO.Challenge1Points = studentActivitiy.Points;
                    studentAchievementDTO.Challenge1CompleteDate = studentActivitiy.CreatedDate;
                }
                else if (studentActivitiy.ChallengeId == 2 )
                {
                    studentAchievementDTO.Challenge2Complete = true;
                    studentAchievementDTO.Challenge2Points = studentActivitiy.Points;
                    studentAchievementDTO.Challenge2CompleteDate = studentActivitiy.CreatedDate;
                }
                else if (studentActivitiy.ChallengeId == 3 )
                {
                    studentAchievementDTO.Challenge3Complete = true;
                    studentAchievementDTO.Challenge3Points = studentActivitiy.Points;
                    studentAchievementDTO.Challenge3CompleteDate = studentActivitiy.CreatedDate;
                }
                //studentAchievementDTO.PointsTimeline.Add(new GraphDataDTO() { XAxis1 = studentActivitiy.CreatedDate.ToShortDateString(), YAxis1 = studentActivitiy.Points });
            }
            studentAchievementDTO.PointsSplitup = studentActivities.GroupBy(a => a.Type).Select(a => new GraphDataDTO() { XAxis1 = GetActivityName(a.First().Type),YAxis1 = a.Sum(p=>p.Points)}).ToList();

            studentAchievementDTO.PointsTimeline = studentActivities.GroupBy(a => new {a.CreatedDate.Month, a.CreatedDate.Year }).Select(a => new GraphDataDTO() { XAxis1 = $"{a.Key.Month}|{a.Key.Year}", YAxis1 = a.Sum(p => p.Points) }).ToList();
            studentAchievementDTO.StartDate = student.CreationDate;
            studentAchievementDTO.BraveiorChampion = student.IsLeader;
            return studentAchievementDTO;
        }
        private string GetActivityName(int id)
        {
            switch (id)
            {
                case 1:
                    return "Group Discussion";
                case 2:
                    return "Hackathon";
                case 3:
                    return "R & D Solutioning";
                case 4:
                    return "Challenge";
                case 5:
                    return "Blog";
                case 6:
                    return "Vlog";
                default:
                    return "General";
            }
        }
        public List<UserDTO> GetUsers(long institutionId, string key)
        {
                var users = _dbContext.Users.Where(i=>i.InstitutionId == institutionId && i.FirstName.StartsWith(key)).ToList();
                return _mapper.Map<List<UserDTO>>(users);
        }

        public List<SkillDTO> GetSkills(string key)
        {
                var skills = _dbContext.Skills.Where(a => a.Name.StartsWith(key)).OrderBy(a => a.Name).ToList();
                return _mapper.Map<List<SkillDTO>>(skills);
        }

        public List<UserSkillDTO> GetUserSkills(long userId)
        {
                var skills = _dbContext.UserSkills.Where(us=>us.UserId== userId).Include(s=>s.Skill).ToList();
                return _mapper.Map<List<UserSkillDTO>>(skills);
        }

        public List<EventDTO> GetEvents()
        {
                var events = _dbContext.Events.ToList();
                return _mapper.Map<List<EventDTO>>(events);
        }

        public List<ChallengeDTO> GetChallenges()
        {
                var challenges = _dbContext.Challenges.ToList();
                return _mapper.Map<List<ChallengeDTO>>(challenges);
        }
        public List<StudentActivityDTO> GetStudentActivities(long userId)
        {
                var studentActivities = _dbContext.StudentActivities.Where(us => us.UserId == userId).Include(s => s.Challenge).Include(s => s.Event).ToList();
                return _mapper.Map<List<StudentActivityDTO>>(studentActivities);
        }

        public void UpdateUserSkill(UserSkillDTO userSkillDTO)
        {
                var userSkill = _dbContext.UserSkills.Where(us => us.UserSkillId == userSkillDTO.UserSkillId).FirstOrDefault();
                userSkill.Stars = userSkillDTO.Stars;
            _dbContext.UserSkills.Update(userSkill);
            _dbContext.SaveChanges();
        }

        public void UpdateProfile(UserDTO userDTO)
        {
                var userProfile = _dbContext.Users.Where(us => us.UserId == userDTO.UserId).FirstOrDefault();
                userProfile.FirstName = userDTO.FirstName;
                userProfile.LastName = userDTO.LastName;
                userProfile.Description = userDTO.Description;
                userProfile.LinkedInUrl = userDTO.LinkedInUrl;
                userProfile.Email = userDTO.Email.Trim();
                userProfile.Display = userDTO.Display;
                userProfile.IsLeader = userDTO.IsLeader;
            _dbContext.Users.Update(userProfile);
            _dbContext.SaveChanges();
        }
        
        public void ApproveStudentActivity(StudentActivityDTO studentActitityDTO)
        {
            var studentActitity = _dbContext.StudentActivities.Where(sa => sa.StudentActivityId == studentActitityDTO.StudentActivityId).FirstOrDefault();
            if (studentActitity != null)
            {
                studentActitity.Status = studentActitityDTO.Status;
                studentActitity.Points = studentActitityDTO.Points;
                _dbContext.StudentActivities.Update(studentActitity);
                _dbContext.SaveChanges();
            }
        }
        public void UpdateStudentEvent(StudentActivityDTO studentActitityDTO,bool isAdmin)
        {
                var studentEvent = _dbContext.StudentActivities.Where(sa => sa.StudentActivityId == studentActitityDTO.StudentActivityId).FirstOrDefault();
                if(isAdmin)        
                    studentEvent.Points = studentActitityDTO.Points;
                studentEvent.Status = studentActitityDTO.Status;
            studentEvent.CreatedDate = studentActitityDTO.CreatedDate.Value;
            studentEvent.ModifiedDate= DateTime.Now;
            _dbContext.StudentActivities.Update(studentEvent);
            _dbContext.SaveChanges();
        }
        public void ResetPassword(UserDTO userDTO)
        {
            var loggedInUser = _dbContext.Users.Where(u => u.UserId == userDTO.UserId).FirstOrDefault();
            if (loggedInUser != null)
            {
                loggedInUser.Password = Encrypt(userDTO.Password);
                _dbContext.Users.Update(loggedInUser);
                _dbContext.SaveChanges();
            }
        }
        public void UpdateStudentChallenge(StudentActivityDTO studentActitityDTO, bool isAdmin)
        {
                var studentChallenge = _dbContext.StudentActivities.Where(sa => sa.StudentActivityId == studentActitityDTO.StudentActivityId).FirstOrDefault();
                if(isAdmin)
                    studentChallenge.Points = studentActitityDTO.Points;
                studentChallenge.Status = studentActitityDTO.Status;
                studentChallenge.AssetUrl = studentActitityDTO.AssetUrl;
            studentChallenge.ModifiedDate = DateTime.Now;
            studentChallenge.CreatedDate = studentActitityDTO.CreatedDate.Value;
            _dbContext.StudentActivities.Update(studentChallenge);
            _dbContext.SaveChanges();
        }
        public void UpdateStudentAsset(StudentActivityDTO studentActitityDTO, bool isAdmin)
        {
                var studentAsset = _dbContext.StudentActivities.Where(sa => sa.StudentActivityId == studentActitityDTO.StudentActivityId).FirstOrDefault();
                if(isAdmin)
                    studentAsset.Points = studentActitityDTO.Points;
                studentAsset.Status = studentActitityDTO.Status;
                studentAsset.AssetName = studentActitityDTO.AssetName;
                studentAsset.AssetDescription = studentActitityDTO.AssetDescription;
                studentAsset.AssetUrl = studentActitityDTO.AssetUrl;
                studentAsset.ModifiedDate = DateTime.Now;
                studentAsset.CreatedDate = studentActitityDTO.CreatedDate.Value;
            _dbContext.StudentActivities.Update(studentAsset);
            _dbContext.SaveChanges();
        }

        public void AddUserSkill(UserSkillDTO userSkillDTO)
        {
            UserSkill userSkill = new UserSkill()
            {
                UserId = userSkillDTO.UserId,
                SkillId = userSkillDTO.SkillId,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                Stars = userSkillDTO.Stars
            };
            _dbContext.UserSkills.Add(userSkill);
            _dbContext.SaveChanges();
        }

        public void AddStudentEvent(StudentActivityDTO studentActivityDTO,bool isAdmin)
        {
            StudentActivity studentActivity = new StudentActivity()
            {
                UserId = studentActivityDTO.UserId,
                EventId = studentActivityDTO.EventId,
                Points = isAdmin?studentActivityDTO.Points:0,
                Type = studentActivityDTO.Type,
                Status = studentActivityDTO.Status,
                ModifiedDate = DateTime.Now,
                CreatedDate = studentActivityDTO.CreatedDate.Value
            };
            _dbContext.StudentActivities.Add(studentActivity);
            _dbContext.SaveChanges();
        }

        

        public void AddStudentChallenge(StudentActivityDTO studentActivityDTO,bool isAdmin)
        {

            var studentChallenge = _dbContext.StudentActivities.Where(us => us.UserId == studentActivityDTO.UserId && us.ChallengeId == studentActivityDTO.ChallengeId).FirstOrDefault();
            if (studentChallenge != null)
            {
                throw new Exception("Challenge already exists for the user");
            }
            StudentActivity studentActivity = new StudentActivity()
            {
                UserId = studentActivityDTO.UserId,
                ChallengeId = studentActivityDTO.ChallengeId,
                Points = isAdmin?studentActivityDTO.Points:0,
                Type = studentActivityDTO.Type,
                AssetUrl = studentActivityDTO.AssetUrl,
                Status = studentActivityDTO.Status,
                ModifiedDate = DateTime.Now,
                CreatedDate = studentActivityDTO.CreatedDate.Value
            };
            _dbContext.StudentActivities.Add(studentActivity);
            _dbContext.SaveChanges();
        }

        public void AddStudentAsset(StudentActivityDTO studentActivityDTO,bool isAdmin)
        {
            StudentActivity studentActivity = new StudentActivity()
            {
                UserId = studentActivityDTO.UserId,
                Points = isAdmin?studentActivityDTO.Points:0,
                Type = studentActivityDTO.Type,
                AssetName = studentActivityDTO.AssetName,
                AssetDescription = studentActivityDTO.AssetDescription,
                AssetUrl = studentActivityDTO.AssetUrl,
                Status = studentActivityDTO.Status,
                ModifiedDate = DateTime.Now,
                CreatedDate = studentActivityDTO.CreatedDate.Value
            };
            _dbContext.StudentActivities.Add(studentActivity);
            _dbContext.SaveChanges();
        }

        public void DeleteUserSkill(long userSkillId)
        {
            var userSkill = _dbContext.UserSkills.Where(us => us.UserSkillId == userSkillId).FirstOrDefault();
            if (userSkill != null)
            {
                _dbContext.UserSkills.Remove(userSkill);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteStudentActivity(long studentActivityId)
        {
            var studentActivity = _dbContext.StudentActivities.Where(sa => sa.StudentActivityId == studentActivityId).FirstOrDefault();

            if(studentActivity != null)
            {
                _dbContext.StudentActivities.Remove(studentActivity);
                _dbContext.SaveChanges();
            }
        }
       
        public void CreateKanboard(KanboardDTO kanboardDTO)
        {
            Kanboard newKanboard = new Kanboard()
            {
                Name = kanboardDTO.Name
            };
            _dbContext.Kanboards.Add(newKanboard);
            _dbContext.SaveChanges();
        }

        public void Register(UserDTO userDTO)
        {
            var existingUser = _dbContext.Users.Where(u => u.Email == userDTO.Email).FirstOrDefault();

            if (existingUser == null)
            {
                User newUser = new User()
                {
                    Email = userDTO.Email,
                    InstitutionId = userDTO.InstitutionId,
                    Role = userDTO.Role,
                    Password = Encrypt("password"),
                    Description = String.Empty,
                    Display = false,
                    Grade = String.Empty,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    IsActive = true,
                    Points = 0,
                    IsLeader = false,
                    LinkedInUrl = "",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("User already exists");
            }
        }
        private string Encrypt(string text)
        {
            var b = Encoding.UTF8.GetBytes(text);
            var encrypted = getAes().CreateEncryptor().TransformFinalBlock(b, 0, b.Length);
            return Convert.ToBase64String(encrypted);
        }

        private string Decrypt(string encrypted)
        {
            var b = Convert.FromBase64String(encrypted);
            var decrypted = getAes().CreateDecryptor().TransformFinalBlock(b, 0, b.Length);
            return Encoding.UTF8.GetString(decrypted);
        }

        private Aes getAes()
        {
            var keyBytes = new byte[16];
            var skeyBytes = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            Array.Copy(skeyBytes, keyBytes, Math.Min(keyBytes.Length, skeyBytes.Length));

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.Key = keyBytes;
            aes.IV = keyBytes;

            return aes;
        }
    }
}