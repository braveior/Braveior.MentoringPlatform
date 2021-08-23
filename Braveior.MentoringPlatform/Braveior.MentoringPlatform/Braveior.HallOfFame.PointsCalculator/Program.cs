using Braveior.MentoringPlatform.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Braveior.HallOfFame.PointsCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new braveiordbContext())
            {
                var users = db.Users.Include(a=>a.StudentActivities).ToList();
                foreach (var user in users)
                {
                    var totalpoints = user.StudentActivities.Sum(a => a.Points);
                    user.Points = totalpoints;
                    db.Users.Update(user);
                }
                db.SaveChanges();
            }
        }
    }
}
