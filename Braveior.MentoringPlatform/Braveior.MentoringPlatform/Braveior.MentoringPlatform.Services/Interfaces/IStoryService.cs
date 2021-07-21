using Braveior.MentoringPlatform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Services.Interfaces
{
    public interface IStoryService
    {
        void CreateStory(StoryDTO story);
        void CreateTask(TaskDTO taskDTO);

        void UpdateStory(StoryDTO story);
        void UpdateTask(TaskDTO taskDTO);
        StoryDTO GetStory(long storyid);
        TaskDTO GetTask(long taskid);
        List<TaskDTO> GetTasks(long storyId);

        List<StoryDTO> GetStories(long kanboardId);
        void UpdateTaskStatus(TaskDTO taskDTO);
        
        void UpdateStoryStatus(StoryDTO storyDTO);


    }
}
