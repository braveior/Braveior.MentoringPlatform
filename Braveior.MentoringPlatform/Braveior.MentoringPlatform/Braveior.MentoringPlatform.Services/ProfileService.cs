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

        //public List<AssetDTO> GetAssets(long userId)
        //{
        //    using (var db = new braveiordbContext())
        //    {
        //        var assets = db.Assets.Where(u => u.UserId == userId).ToList();
        //        return _mapper.Map<List<AssetDTO>>(assets);
        //    }
        //}
        public ProfileDTO GetProfile(long userId)
        {
           
            //using (var db = new braveiordbContext())
            //{
            var user = _dbContext.Users.Where(u => u.UserId == userId).Include(i => i.Institution).Include(uk => uk.UserSkills).ThenInclude(a => a.Skill).FirstOrDefault();
                var studentWorkItems = _dbContext.StudentActivities.Where(u => u.UserId == userId).Include(a=>a.Event).Include(a => a.Challenge).ThenInclude(a=>a.Product);
                ProfileDTO profileDTO = new ProfileDTO()
                {
                    UserId = user.UserId,
                    IsLeader = user.IsLeader,
                    Points = user.Points,
                    StudentName = $"{user.FirstName} {user.LastName}",
                    LinkedInLink = user.LinkedInUrl,
                    Description = user.Description,
                    Grade = user.Grade,
                    InsitutionName = user.Institution.Name,
                    UserSkills = _mapper.Map<List<UserSkillDTO>>(user.UserSkills.OrderByDescending(a=>a.Stars)),
                    StudentWorkItems = _mapper.Map<List<StudentActivityDTO>>(studentWorkItems)
                };
                return profileDTO;
            //}
        }

        public List<StudentActivityDTO> GetPendingStudentActivties()
        {
            var studentActivities = _dbContext.StudentActivities.Where(u => u.Status == 0).Include(i => i.User).ThenInclude(i=>i.Institution).ToList();
            return _mapper.Map<List<StudentActivityDTO>>(studentActivities);
        }

        public List<ProfileDTO> GetProfiles()
        {
            //using (var db = new braveiordbContext())
            //{
                var students = _dbContext.Users.Where(u => u.Role == 1).Include(us => us.UserSkills).Include(i => i.Institution).ToList();
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
                        Grade = student.Grade,
                        //TODO
                        Points = student.Points,
                        UserSkills = _mapper.Map<List<UserSkillDTO>>(student.UserSkills)
                    };
                    profiles.Add(profileDTO);
                }
                //return GetRankedProfiles(profiles);
                return profiles.OrderByDescending(p => p.Points).ToList();
            //}
        }

        public List<ProfileDTO> GetProfiles(long institutionId)
        {
            //using (var db = new braveiordbContext())
            //{
            var students = _dbContext.Users.Where(u => u.Role == 1 && u.InstitutionId== institutionId).Include(us => us.UserSkills).Include(i => i.Institution).ToList();
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
                    Grade = student.Grade,
                    //TODO
                    Points = student.Points,
                    UserSkills = _mapper.Map<List<UserSkillDTO>>(student.UserSkills)
                };
                profiles.Add(profileDTO);
            }
            //return GetRankedProfiles(profiles);
            return profiles.OrderByDescending(p => p.Points).ToList();
            //}
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
            //using (var db = new braveiordbContext())
           // {
                var colleges = _dbContext.Institutions.ToList();
                return _mapper.Map<List<InstitutionDTO>>(colleges);
           // }
        }

        public List<UserDTO> GetUsers(long institutionId, string key)
        {
            //using (var db = new braveiordbContext())
            //{
                var users = _dbContext.Users.Where(i=>i.InstitutionId == institutionId && i.FirstName.StartsWith(key)).ToList();
                return _mapper.Map<List<UserDTO>>(users);
            //}
        }

        public List<SkillDTO> GetSkills(string key)
        {
           // using (var db = new braveiordbContext())
           // {
                var skills = _dbContext.Skills.Where(a => a.Name.StartsWith(key)).OrderBy(a => a.Name).ToList();
                return _mapper.Map<List<SkillDTO>>(skills);
           // }
        }

        public List<UserSkillDTO> GetUserSkills(long userId)
        {
           // using (var db = new braveiordbContext())
           // {
                var skills = _dbContext.UserSkills.Where(us=>us.UserId== userId).Include(s=>s.Skill).ToList();
                return _mapper.Map<List<UserSkillDTO>>(skills);
           // }
        }

        public List<EventDTO> GetEvents()
        {
           // using (var db = new braveiordbContext())
           // {
                var events = _dbContext.Events.ToList();
                return _mapper.Map<List<EventDTO>>(events);
           // }
        }

        public List<ChallengeDTO> GetChallenges()
        {
           // using (var db = new braveiordbContext())
           // {
                var challenges = _dbContext.Challenges.ToList();
                return _mapper.Map<List<ChallengeDTO>>(challenges);
           // }
        }



        public List<StudentActivityDTO> GetStudentActivities(long userId)
        {
           // using (var db = new braveiordbContext())
           // {
                var studentActivities = _dbContext.StudentActivities.Where(us => us.UserId == userId && us.Status == 1).Include(s => s.Challenge).Include(s => s.Event).ToList();
                return _mapper.Map<List<StudentActivityDTO>>(studentActivities);
          //  }
        }

        public void UpdateUserSkill(UserSkillDTO userSkillDTO)
        {
            //using (var db = new braveiordbContext())
            //{
                var userSkill = _dbContext.UserSkills.Where(us => us.UserSkillId == userSkillDTO.UserSkillId).FirstOrDefault();
                userSkill.Stars = userSkillDTO.Stars;
            _dbContext.UserSkills.Update(userSkill);
            _dbContext.SaveChanges();
           // }
        }

        public void UpdateProfile(UserDTO userDTO)
        {
            //using (var db = new braveiordbContext())
            //{
                var userProfile = _dbContext.Users.Where(us => us.UserId == userDTO.UserId).FirstOrDefault();
                userProfile.FirstName = userDTO.FirstName;
                userProfile.LastName = userDTO.LastName;
                userProfile.Description = userDTO.Description;
                userProfile.LinkedInUrl = userDTO.LinkedInUrl;
                userProfile.Email = userDTO.Email;
            _dbContext.Users.Update(userProfile);
            _dbContext.SaveChanges();
            //}
        }
        
        public void ApproveStudentActivity(StudentActivityDTO studentActitityDTO)
        {
            //using (var db = new braveiordbContext())
            //{
            var studentActitity = _dbContext.StudentActivities.Where(sa => sa.StudentActivityId == studentActitityDTO.StudentActivityId).FirstOrDefault();
            if (studentActitity != null)
            {
                studentActitity.Status = studentActitityDTO.Status;
                studentActitity.Points = studentActitityDTO.Points;
                _dbContext.StudentActivities.Update(studentActitity);
                _dbContext.SaveChanges();
            }

            //}
        }
        public void UpdateStudentEvent(StudentActivityDTO studentActitityDTO,bool isAdmin)
        {
                var studentEvent = _dbContext.StudentActivities.Where(sa => sa.StudentActivityId == studentActitityDTO.StudentActivityId).FirstOrDefault();
                if(isAdmin)        
                    studentEvent.Points = studentActitityDTO.Points;
                studentEvent.Status = studentActitityDTO.Status;
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
            //using (var db = new braveiordbContext())
            //{
                var studentChallenge = _dbContext.StudentActivities.Where(sa => sa.StudentActivityId == studentActitityDTO.StudentActivityId).FirstOrDefault();
                if(isAdmin)
                    studentChallenge.Points = studentActitityDTO.Points;
                studentChallenge.Status = studentActitityDTO.Status;
                studentChallenge.AssetUrl = studentActitityDTO.AssetUrl;
            _dbContext.StudentActivities.Update(studentChallenge);
            _dbContext.SaveChanges();
            //}
        }
        public void UpdateStudentAsset(StudentActivityDTO studentActitityDTO, bool isAdmin)
        {
            //using (var db = new braveiordbContext())
            //{
                var studentAsset = _dbContext.StudentActivities.Where(sa => sa.StudentActivityId == studentActitityDTO.StudentActivityId).FirstOrDefault();
                if(isAdmin)
                    studentAsset.Points = studentActitityDTO.Points;
                studentAsset.Status = studentActitityDTO.Status;
                studentAsset.AssetName = studentActitityDTO.AssetName;
                studentAsset.AssetDescription = studentActitityDTO.AssetDescription;
                studentAsset.AssetUrl = studentActitityDTO.AssetUrl;
            _dbContext.StudentActivities.Update(studentAsset);
            _dbContext.SaveChanges();
            //}
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
            // using (var db = new braveiordbContext())
            // {
            _dbContext.UserSkills.Add(userSkill);
            _dbContext.SaveChanges();
           // }
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
            };
            // using (var db = new braveiordbContext())
            //  {
            _dbContext.StudentActivities.Add(studentActivity);
            _dbContext.SaveChanges();
           // }
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
            };
            //using (var db = new braveiordbContext())
            //{
            _dbContext.StudentActivities.Add(studentActivity);
            _dbContext.SaveChanges();
            //}
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
            };
            //using (var db = new braveiordbContext())
            // {
            _dbContext.StudentActivities.Add(studentActivity);
            _dbContext.SaveChanges();
           // }
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
        //public void CreateUser(UserDTO userDTO)
        //{
        //    User newUser = new User()
        //    {
        //        Name = userDTO.Name,
        //        InstitutionId = userDTO.InstitutionId
        //    };
        //    using (var db = new braveiordbContext())
        //    {
        //        db.Users.Add(newUser);
        //        db.SaveChanges();
        //    }
        //}
        //public void UpdateUser(UserDTO userDTO)
        //{

        //    User newUser = new User()
        //    {
        //        Name = userDTO.Name,
        //        InstitutionId = userDTO.InstitutionId
        //    };
        //    using (var db = new braveiordbContext())
        //    {
        //        var user = db.Users.Where(a => a.UserId == userDTO.Id).FirstOrDefault();
        //        if (user != null)
        //        {
        //            user.InstitutionId = userDTO.InstitutionId;
        //            user.Name = userDTO.Name;
        //            db.Users.Update(user);
        //            db.SaveChanges();
        //        }
        //    }
        //}


        //public void CreateTask(TaskDTO taskDTO)
        //{
        //    Task newTask = new Task()
        //    {
        //        Name = taskDTO.Name,
        //        Description = taskDTO.Description,
        //        Status = 0,
        //    };
        //    using (var db = new braveiordbContext())
        //    {
        //        db.Tasks.Add(newTask);
        //        db.SaveChanges();
        //    }
        //}


        //public void CreateProduct(ProductDTO productDTO)
        //{
        //    Product newProduct = new Product()
        //    {
        //        Name = productDTO.Name,
        //        Description = productDTO.Description,
        //    };
        //    using (var db = new braveiordbContext())
        //    {
        //        db.Products.Add(newProduct);
        //        db.SaveChanges();
        //    }
        //}
        //public void CreateInstitution(InstitutionDTO institutionDTO)
        //{
        //    Institution newInstitution = new Institution()
        //    {
        //        Name = institutionDTO.Name,
        //        Type = institutionDTO.Type,
        //        Country = institutionDTO.Country,
        //        State = institutionDTO.State,
        //        District = institutionDTO.District,
        //        City = institutionDTO.City,
        //        PinCode = institutionDTO.PinCode,
        //    };
        //    using (var db = new braveiordbContext())
        //    {
        //        db.Institutions.Add(newInstitution);
        //        db.SaveChanges();
        //    }
        //}
        public void CreateKanboard(KanboardDTO kanboardDTO)
        {
            Kanboard newKanboard = new Kanboard()
            {
                Name = kanboardDTO.Name
            };
            // using (var db = new braveiordbContext())
            // {
            _dbContext.Kanboards.Add(newKanboard);
            _dbContext.SaveChanges();
          //  }
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
