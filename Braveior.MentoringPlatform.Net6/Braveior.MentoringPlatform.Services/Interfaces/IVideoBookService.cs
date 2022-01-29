using Braveior.MentoringPlatform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Services.Interfaces
{
    public interface IVideoBookService
    {
        VideoBookDTO GetVideoBook(long videoBookId);
        List<VideoBookDTO> GetVideoBooks();

        List<LessonDTO> GetVideoBookLessons(long videoBookId);
        void AddVideoBook(VideoBookDTO videoBookDTO);
        void UpdateVideoBook(VideoBookDTO videoBookDTO);
        void AddVideoBookLesson(LessonDTO lessonDTO);
        void UpdateVideoBookLesson (LessonDTO lessonDTO);

        void DeleteVideoBook(long videoBookId);

        void DeleteVideoBookLesson(long videoBookId);




    }
}
