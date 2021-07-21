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
    public class StoryService : IStoryService
    {
        private readonly IMapper _mapper;

        public StoryService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public void CreateStory(StoryDTO storyDTO)
        {
            Story newStory = new Story()
            {
                Name = storyDTO.Name,
                Description = storyDTO.Description,
                Status = storyDTO.Status,
                AcceptanceCriteria = storyDTO.AcceptanceCriteria,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                ProductId = 1
            };
            using (var db = new braveiordbContext())
            {
                db.Stories.Add(newStory);
                db.SaveChanges();
            }
        }

        public void CreateTask(TaskDTO taskDTO)
        {
            Task newTask = new Task()
            {
                Name = taskDTO.Name,
                Description = taskDTO.Description,
                Status = taskDTO.Status,
                
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                StoryId = taskDTO.StoryId
            };
            using (var db = new braveiordbContext())
            {
                db.Tasks.Add(newTask);
                db.SaveChanges();
            }
        }

        public List<StoryDTO> GetStories(long kanboardId)
        {
            using (var db = new braveiordbContext())
            {
                var stories = db.KanboardStories.Where(t => t.KanboardId == kanboardId).Select(s => s.Story);
                return _mapper.Map<List<StoryDTO>>(stories);
            }

        }

        public List<TaskDTO> GetTasks(long storyId)
        {
            using (var db = new braveiordbContext())
            {
                var tasks = db.Tasks.Where(t => t.StoryId == storyId).ToList();
                return _mapper.Map<List<TaskDTO>>(tasks);
            }
        }

        public StoryDTO GetStory(long storyid)
        {
            using (var db = new braveiordbContext())
            {
                var story = db.Stories.Where(t => t.StoryId == storyid).Include(t=>t.Tasks).ThenInclude(ut=>ut.UserTasks).ThenInclude(u=>u.User).FirstOrDefault();
                var retstory = _mapper.Map<StoryDTO>(story);
                return retstory;
            }

        }

        public TaskDTO GetTask(long taskid)
        {
            using (var db = new braveiordbContext())
            {
                var task = db.Tasks.Where(t => t.TaskId == taskid).FirstOrDefault();
                return _mapper.Map<TaskDTO>(task);
            }

        }

        public void UpdateTaskStatus(TaskDTO taskDTO)
        {
            using (var db = new braveiordbContext())
            {
                var task = db.Tasks.Where(t => t.TaskId == taskDTO.TaskId).FirstOrDefault();
                if (task != null)
                {
                    task.Status = taskDTO.Status;
                    if (taskDTO.Status == 2 && task.Status != 2)
                    {
                        task.Status = 2;
                        task.CompletionDate = DateTime.Now;
                    }
                    else if (taskDTO.Status == 1 && task.Status != 1)
                    {
                        task.Status = 1;
                        if (task.StartDate != null)
                            task.StartDate = DateTime.Now;
                    }
                    else if (taskDTO.Status == 0 && task.Status != 0)
                    {
                        task.Status = 0;
                    }
                    db.Tasks.Update(task);
                    db.SaveChanges();
                }

            }

        }

        public void UpdateStoryStatus(StoryDTO storyDTO)
        {
            using (var db = new braveiordbContext())
            {
                var story = db.Stories.Where(t => t.StoryId == storyDTO.StoryId).FirstOrDefault();
                if (story != null)
                {
                    story.Status = storyDTO.Status;
                    if (storyDTO.Status == 2 && story.Status != 2)
                    {
                        story.Status = 2;
                        story.CompletedDate = DateTime.Now;
                    }
                    else if (storyDTO.Status == 1 && story.Status != 1)
                    {
                        story.Status = 1;
                        if(story.StartDate !=null)
                            story.StartDate = DateTime.Now;
                    }
                    else if (storyDTO.Status == 0 && story.Status != 0)
                    {
                        story.Status = 0;
                        
                    }
                    db.Stories.Update(story);
                    db.SaveChanges();
                }

            }

        }

        public void UpdateStory(StoryDTO storyDTO)
        {

            using (var db = new braveiordbContext())
            {
                var story = db.Stories.Where(a => a.StoryId == storyDTO.StoryId).FirstOrDefault();
                if (story != null)
                {
                    story.Name = storyDTO.Name;
                    story.Description = storyDTO.Description;
                    story.Status = storyDTO.Status;
                    story.AcceptanceCriteria = storyDTO.AcceptanceCriteria;
                    story.ModifiedDate = DateTime.Now;
                    db.Stories.Update(story);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateTask(TaskDTO taskDTO)
        {

            using (var db = new braveiordbContext())
            {
                var task = db.Tasks.Where(a => a.TaskId == taskDTO.TaskId).FirstOrDefault();
                if (task != null)
                {
                    task.Name = taskDTO.Name;
                    task.Description = taskDTO.Description;
                    task.Status = taskDTO.Status;
                    task.ModifiedDate = DateTime.Now;
                    db.Tasks.Update(task);
                    db.SaveChanges();
                }
            }
        }


    }
}
