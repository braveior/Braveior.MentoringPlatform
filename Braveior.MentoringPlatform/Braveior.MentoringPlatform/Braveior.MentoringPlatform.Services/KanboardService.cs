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
    public class KanboardService : IKanboardService
    {
        private readonly IMapper _mapper;
        braveiordbContext _dbContext;
        public KanboardService(IMapper mapper, braveiordbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
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
            //  using (var db = new braveiordbContext())
            //  {
            _dbContext.Kanboards.Add(newKanboard);
            _dbContext.SaveChanges();
            //}
        }

    }
}
