using AutoMapper;
using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Repository;
using Braveior.MentoringPlatform.Repository.Models;
using Braveior.MentoringPlatform.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Braveior.MentoringPlatform.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;

        public ProfileService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<AssetDTO> GetAssets(long userId)
        {
            using (var db = new braveiordbContext())
            {
                var assets = db.Assets.Where(u => u.UserId == userId).ToList();
                return _mapper.Map<List<AssetDTO>>(assets);
            }
        }
        public ProfileDTO GetProfile(long userId)
        {
            using (var db = new braveiordbContext())
            {
                var user = db.Users.Where(u => u.UserId == userId).Include(i => i.Institution).Include(uk => uk.UserSkills).ThenInclude(a => a.Skill).FirstOrDefault();

                var studentWorkItemstest = db.StudentWorkItems.Where(u => u.UserId == userId).FirstOrDefault();
                var studentWorkItems = db.StudentWorkItems.Where(u => u.UserId == userId).Include(a => a.Asset).Include(a=>a.Activity).Include(a => a.Challenge).ThenInclude(a=>a.Product);
                ProfileDTO profileDTO = new ProfileDTO()
                {
                    UserId = user.UserId,
                    StudentName = $"{user.FirstName} {user.LastName}",
                    LinkedInLink = user.LinkedInUrl,
                    Description = user.Description,
                    InsitutionName = user.Institution.Name,
                    UserSkills = _mapper.Map<List<UserSkillDTO>>(user.UserSkills),
                    StudentWorkItems = _mapper.Map<List<StudentWorkItemDTO>>(studentWorkItems)
                };
                return profileDTO;
            }
        }

        public List<ProfileDTO> GetProfiles()
        {
            using (var db = new braveiordbContext())
            {
                var students = db.Users.Where(u => u.Display == true && u.Role == "Student").Include(us => us.UserSkills).Include(i => i.Institution).ToList();
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
                        //TODO
                        Points = student.Points.Value,
                        UserSkills = _mapper.Map<List<UserSkillDTO>>(student.UserSkills)
                    };
                    profiles.Add(profileDTO);
                }
                return GetRankedProfiles(profiles);
            }
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
            using (var db = new braveiordbContext())
            {
                db.Kanboards.Add(newKanboard);
                db.SaveChanges();
            }
        }

    }
}
