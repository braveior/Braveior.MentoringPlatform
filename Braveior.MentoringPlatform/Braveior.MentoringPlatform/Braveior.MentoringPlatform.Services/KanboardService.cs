using AutoMapper;
using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Repository;
using Braveior.MentoringPlatform.Repository.Models;
using Braveior.MentoringPlatform.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Braveior.MentoringPlatform.Services
{
    public class KanboardService : IKanboardService
    {
        private readonly IMapper _mapper;

        public KanboardService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void CreateUser(UserDTO userDTO)
        {
            User newUser = new User()
            {
                Name = userDTO.Name,
                InstitutionId = userDTO.InstitutionId
            };
            using (var db = new braveiordbContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
        public void UpdateUser(UserDTO userDTO)
        {

            User newUser = new User()
            {
                Name = userDTO.Name,
                InstitutionId = userDTO.InstitutionId
            };
            using (var db = new braveiordbContext())
            {
                var user = db.Users.Where(a => a.UserId == userDTO.Id).FirstOrDefault();
                if (user != null)
                {
                    user.InstitutionId = userDTO.InstitutionId;
                    user.Name = userDTO.Name;
                    db.Users.Update(user);
                    db.SaveChanges();
                }
            }
        }


        public void CreateTask(StoryDTO taskDTO)
        {
            Story newStory = new Story()
            {
                Name = taskDTO.Name,
                Description = taskDTO.Description,
                Status = "NOT-STARTED",
                KanboardId = taskDTO.KanboardId,
                ProductId = taskDTO.ProductId,
                StoryPoint = taskDTO.StoryPoint,
                StartDate = DateTime.Now
                
            };
            using (var db = new braveiordbContext())
            {
                db.Stories.Add(newStory);
                db.SaveChanges();
            }
        }

        public void UpdateStoryStatus(StoryDTO storyDTO)
        {
            using (var db = new braveiordbContext())
            {
                var story = db.Stories.Where(t => t.StoryId == storyDTO.Id).FirstOrDefault();
                if (story != null)
                {
                    story.Status = storyDTO.Status;
                    if (storyDTO.Status == "COMPLETED")
                        story.CompletionDate = DateTime.Now;
                    db.Stories.Update(story);
                    db.SaveChanges();
                }

            }

        }
        public List<StoryDTO> GetTasks(long kanboardId)
        {
            using (var db = new braveiordbContext())
            {
                var tasks = db.Stories.Where(t => t.KanboardId == kanboardId);
                return _mapper.Map<List<StoryDTO>>(tasks);
            }

        }
        public void CreateProduct(ProductDTO productDTO)
        {
            Product newProduct = new Product()
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
            };
            using (var db = new braveiordbContext())
            {
                db.Products.Add(newProduct);
                db.SaveChanges();
            }
        }
        public void CreateInstitution(InstitutionDTO institutionDTO)
        {
            Institution newInstitution = new Institution()
            {
                Name = institutionDTO.Name,
                Type = institutionDTO.Type,
                Country = institutionDTO.Country,
                State = institutionDTO.State,
                District = institutionDTO.District,
                City = institutionDTO.City,
                PinCode = institutionDTO.PinCode,
            };
            using (var db = new braveiordbContext())
            {
                db.Institutions.Add(newInstitution);
                db.SaveChanges();
            }
        }
        public void CreateKanboard(KanboardDTO kanboardDTO)
        {
            Kanboard newKanboard = new Kanboard()
            {
                Name = kanboardDTO.Name,
                InstitutionId = kanboardDTO.InstitutionId,
            };
            using (var db = new braveiordbContext())
            {
                db.Kanboards.Add(newKanboard);
                db.SaveChanges();
            }
        }

    }
}
