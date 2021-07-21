using Braveior.MentoringPlatform.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Client.Services
{
    public interface IStoryService
    {
        Task CreateStory(StoryDTO storyDTO);
        Task CreateTask(TaskDTO taskDTO);

        Task UpdateStory(StoryDTO storyDTO);
        Task UpdateTask(TaskDTO taskDTO);
        Task<StoryDTO> GetStory(long storyId);
        Task<TaskDTO> GetTask(long taskId);

        Task<List<TaskDTO>> GetTasks(long taskId);

        Task<List<StoryDTO>> GetStories(long storyId);

        Task UpdateTaskStatus(TaskDTO taskDTO);

        Task UpdateStoryStatus(StoryDTO storyDTO);






    }
}
