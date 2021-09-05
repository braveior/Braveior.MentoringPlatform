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
    public class WebinarService : IWebinarService
    {
        private readonly IMapper _mapper;
        braveiordbContext _dbContext;
        public WebinarService(IMapper mapper, braveiordbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public BootCampActivityDTO GetBootCampActivity(long bootCampActivityId)
        {
            var bootCampActivity = _dbContext.BootCampActivities.Where(v=>v.BootCampActivityId == bootCampActivityId).Include(l => l.BootCamp).FirstOrDefault();
            return _mapper.Map<BootCampActivityDTO>(bootCampActivity);
        }
        public List<BootCampActivityDTO> GetBootCampActivities()
        {
            var bootCampActivities = _dbContext.BootCampActivities.Include(l => l.BootCamp).ToList();
            return _mapper.Map<List<BootCampActivityDTO>>(bootCampActivities);
        }
        public List<BootCampDTO> GetBootCamps()
        {
            var bootCamps = _dbContext.BootCamps.ToList();
            return _mapper.Map<List<BootCampDTO>>(bootCamps);
        }

        public void AddBootCampActivity(BootCampActivityDTO bootCampActivityDTO)
        {
            BootCampActivity bootCampActivity = new BootCampActivity()
            {
                BootCampId = bootCampActivityDTO.BootCampId,
                StartDate = bootCampActivityDTO.StartDate,
                EndDate = bootCampActivityDTO.EndDate,
                MeetingUrl = bootCampActivityDTO.MeetingUrl
            };
            _dbContext.BootCampActivities.Add(bootCampActivity);
            _dbContext.SaveChanges();
        }

        public void UpdateBootCampActivity(BootCampActivityDTO bootCampActivityDTO)
        {
            var bootCampActivity = _dbContext.BootCampActivities.Where(vb => vb.BootCampActivityId== bootCampActivityDTO.BootCampActivityId).FirstOrDefault();
            if (bootCampActivity != null)
            {
                bootCampActivity.StartDate = bootCampActivityDTO.StartDate;
                bootCampActivity.EndDate= bootCampActivityDTO.EndDate;
                bootCampActivity.MeetingUrl = bootCampActivityDTO.MeetingUrl;
                _dbContext.BootCampActivities.Update(bootCampActivity);
                _dbContext.SaveChanges();
            }
        }
        public void DeleteBootCampActivity(long bootCampActivityId)
        {
            var bootCampActivity = _dbContext.BootCampActivities.Where(vb => vb.BootCampActivityId == bootCampActivityId).FirstOrDefault();

            if (bootCampActivity != null)
            {
                _dbContext.BootCampActivities.Remove(bootCampActivity);
                _dbContext.SaveChanges();
            }
        }

    }
}
