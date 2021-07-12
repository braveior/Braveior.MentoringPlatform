using AutoMapper;
using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Repository.Contexts;
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
            using (var db = new BraveiorDBContext())
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
            using (var db = new BraveiorDBContext())
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


        public void CreateTask(TaskDTO taskDTO)
        {
            Task newTask = new Task() 
            { 
                Name = taskDTO.Name,
                Description = taskDTO.Description, 
                Status = "NOT-STARTED", 
                KanboardId = taskDTO.KanboardId, 
                ProductId = taskDTO.ProductId, 
                StoryPoint = taskDTO.StoryPoint, 
                EstimatedDays = taskDTO.EstimatedDays, 
                ActualDays = taskDTO.ActualDays, 
                StartDate = DateTime.Now, 
                Attachment = taskDTO.Attachment 
            };
            using (var db = new BraveiorDBContext())
            {
                db.Tasks.Add(newTask);
                db.SaveChanges();
            }
        }

        public void UpdateTaskStatus(TaskDTO taskDTO)
        {
            using (var db = new BraveiorDBContext())
            {
                var task = db.Tasks.Where(t => t.TaskId == taskDTO.Id).FirstOrDefault();
                if (task != null)
                {
                    task.Status = taskDTO.Status;
                    if (taskDTO.Status == "COMPLETED")
                        task.CompletionDate = DateTime.Now;
                    db.Tasks.Update(task);
                    db.SaveChanges();
                }
                
            }

        }
        public List<TaskDTO> GetTasks(long kanboardId)
        {
            using (var db = new BraveiorDBContext())
            {
                var tasks = db.Tasks.Where(t => t.KanboardId == kanboardId);
                return _mapper.Map<List<TaskDTO>>(tasks);
            }
                                
        }
        public void CreateProduct(ProductDTO productDTO)
        {
            Product newProduct = new Product()
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
            };
            using (var db = new BraveiorDBContext())
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
                Pincode = institutionDTO.Pincode,
            };
            using (var db = new BraveiorDBContext())
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
            using (var db = new BraveiorDBContext())
            {
                db.Kanboards.Add(newKanboard);
                db.SaveChanges();
            }
        }

    }
}
