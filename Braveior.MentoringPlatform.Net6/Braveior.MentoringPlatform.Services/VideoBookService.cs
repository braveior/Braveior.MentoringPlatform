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
    public class VideoBookService : IVideoBookService
    {
        private readonly IMapper _mapper;
        braveiordbContext _dbContext;
        public VideoBookService(IMapper mapper, braveiordbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public VideoBookDTO GetVideoBook(long videoBookId)
        {
            var videoBook = _dbContext.VideoBooks.Where(v=>v.VideoBookId == videoBookId).Include(l => l.Lessons).FirstOrDefault();
            return _mapper.Map<VideoBookDTO>(videoBook);
        }
        public List<VideoBookDTO> GetVideoBooks()
        {
            var videoBooks = _dbContext.VideoBooks.Include(l => l.Lessons).ToList();
            return _mapper.Map<List<VideoBookDTO>>(videoBooks);
        }
        public List<LessonDTO> GetVideoBookLessons(long videoBookId)
        {
            var videoBookLessons = _dbContext.Lessons.Where(v => v.VideoBookId == videoBookId).ToList();
            return _mapper.Map<List<LessonDTO>>(videoBookLessons);
        }
        public void AddVideoBook(VideoBookDTO videoBookDTO)
        {
            VideoBook videoBook = new VideoBook()
            {
                Name = videoBookDTO.Name,
                Description = videoBookDTO.Description,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
            _dbContext.VideoBooks.Add(videoBook);
            _dbContext.SaveChanges();
        }

        public void UpdateVideoBook(VideoBookDTO videoBookDTO)
        {
            var videoBook = _dbContext.VideoBooks.Where(vb => vb.VideoBookId == videoBookDTO.VideoBookId).FirstOrDefault();
            videoBook.Name = videoBookDTO.Name;
            videoBook.Description = videoBookDTO.Description;
            videoBook.ModifiedDate = DateTime.Now;
            _dbContext.VideoBooks.Update(videoBook);
            _dbContext.SaveChanges();
        }

        public void AddVideoBookLesson(LessonDTO lessonDTO)
        {
            Lesson videoBookLesson = new Lesson()
            {
                Name = lessonDTO.Name,
                Description = lessonDTO.Description,
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                DisplayOrder = lessonDTO.DisplayOrder,
                Type = lessonDTO.Type,
                Url = lessonDTO.Url,
                VimeoId = lessonDTO.VimeoId,
                VideoBookId = lessonDTO.VideoBookId
            };
            _dbContext.Lessons.Add(videoBookLesson);
            _dbContext.SaveChanges();
        }

        public void UpdateVideoBookLesson(LessonDTO lessonDTO)
        {
            var videoBookLesson = _dbContext.Lessons.Where(l => l.LessonId == lessonDTO.LessonId).FirstOrDefault();
            videoBookLesson.Name = lessonDTO.Name;
            videoBookLesson.Description = lessonDTO.Description;
            videoBookLesson.Type = lessonDTO.Type;
            videoBookLesson.Url = lessonDTO.Url;
            videoBookLesson.DisplayOrder = lessonDTO.DisplayOrder;
            videoBookLesson.VimeoId = lessonDTO.VimeoId;
            videoBookLesson.ModifiedDate = DateTime.Now;
            _dbContext.Lessons.Update(videoBookLesson);
            _dbContext.SaveChanges();
        }

        public void DeleteVideoBook(long videoBookId)
        {
            var videoBook = _dbContext.VideoBooks.Where(vb => vb.VideoBookId == videoBookId).FirstOrDefault();

            if (videoBook != null)
            {
                _dbContext.VideoBooks.Remove(videoBook);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteVideoBookLesson(long videoBookLessonId)
        {
            var videoBookLesson = _dbContext.Lessons.Where(vbl => vbl.LessonId == videoBookLessonId).FirstOrDefault();

            if (videoBookLesson != null)
            {
                _dbContext.Lessons.Remove(videoBookLesson);
                _dbContext.SaveChanges();
            }
        }
    }
}
