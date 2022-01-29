using Braveior.MentoringPlatform.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.WA.Client.Services
{
    public interface IVideoBookService
    {
        Task<VideoBookDTO> GetVideoBook(long videoBookId);
        Task<List<VideoBookDTO>> GetVideoBooks();
        Task<List<LessonDTO>> GetVideoBookLessons(long videoBookId);
        Task AddVideoBook(VideoBookDTO videoBookDTO);
        Task UpdateVideoBook(VideoBookDTO videoBookDTO);
        Task AddVideoBookLesson(LessonDTO videoBookLessonDTO);
        Task UpdateVideoBookLesson(LessonDTO videoBookLessonDTO);
        Task DeleteVideoBook(long videoBookId);
        Task DeleteVideoBookLesson(long videoBookLessonId);
    }
}
