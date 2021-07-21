using DataLoader.Models;
using System;

namespace DataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new braveiordbContext())
            {
                #region Insititution Data

                Institution i1 = new Institution()
                {
                    Name = "Dr. Mahalingam College of Engineering and Technology",
                    Type = "Institution",
                    Country = "India",
                    State = "TN",
                    District = "Coimbatore",
                    City = "Coimbatore",
                    PinCode = "641035",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                       
                };
                Institution i2 = new Institution()
                {
                    Name = "Karpagam College of Technology",
                    Type = "Institution",
                    Country = "India",
                    State = "TN",
                    District = "Coimbatore",
                    City = "Coimbatore",
                    PinCode = "641035",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                Institution i3 = new Institution()
                {
                    Name = "P.S.G College of Engineering and Technology",
                    Type = "Institution",
                    Country = "India",
                    State = "TN",
                    District = "Coimbatore",
                    City = "Coimbatore",
                    PinCode = "641035",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                Institution i4 = new Institution()
                {
                    Name = "Govertment College of Engineering and Technology",
                    Type = "Institution",
                    Country = "India",
                    State = "TN",
                    District = "Coimbatore",
                    City = "Coimbatore",
                    PinCode = "641035",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };

                db.Institutions.Add(i1);
                db.Institutions.Add(i2);
                db.Institutions.Add(i3);
                db.Institutions.Add(i4);
                #endregion

                #region Group data
                Group g1 = new Group()
                {
                    Name = "GroupA",
                    Institution = i1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now
                };
                Group g2 = new Group()
                {
                    Name = "GroupB",
                    Institution = i1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now

                };
                Group g3 = new Group()
                {
                    Name = "GroupC",
                    Institution = i2,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now

                };
                Group g4 = new Group()
                {
                    Name = "GroupD",
                    Institution = i2,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now

                };

                db.Groups.Add(g1);
                db.Groups.Add(g2);
                db.Groups.Add(g3);
                db.Groups.Add(g4);

                #endregion

                #region User Data

                User u1 = new User()
                {
                    Name = "Veeraraghavan",
                    Email = "veera@email.com",
                    Institution = i1,
                    Password = "password",
                    Role = "Student",
                    Group = g1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                User u2 = new User()
                {
                    Name = "Sreehari",
                    Email = "sree@email.com",
                    Institution = i1,
                    Password = "password",
                    Role = "Student",
                    Group = g1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                User u3 = new User()
                {
                    Name = "Srilakshmini",
                    Email = "lami@email.com",
                    Institution = i1,
                    Password = "password",
                    Role = "Student",
                    Group = g2,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                User u4 = new User()
                {
                    Name = "Aswath",
                    Email = "aswath@email.com",
                    Institution = i1,
                    Password = "password",
                    Role = "Student",
                    Group = g2,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                User u5 = new User()
                {
                    Name = "Rajesh",
                    Email = "rajesh@email.com",
                    Institution = i2,
                    Password = "password",
                    Role = "Student",
                    Group = g3,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                User u6 = new User()
                {
                    Name = "Leema",
                    Email = "leema@email.com",
                    Institution = i2,
                    Password = "password",
                    Role = "Student",
                    Group = g3,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                User u7 = new User()
                {
                    Name = "Praveena",
                    Email = "praveena@email.com",
                    Institution = i2,
                    Password = "password",
                    Role = "Student",
                    Group = g4,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                User u8 = new User()
                {
                    Name = "Subhashini",
                    Email = "suba@email.com",
                    Institution = i2,
                    Password = "password",
                    Role = "Student",
                    Group = g4,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };

                db.Users.Add(u1);
                db.Users.Add(u2);
                db.Users.Add(u3);
                db.Users.Add(u4);
                db.Users.Add(u5);
                db.Users.Add(u6);
                db.Users.Add(u7);
                db.Users.Add(u8);

                #endregion






                #region Kanboard data

                Kanboard k1 = new Kanboard()
                {
                    Name = "Kanboard A",
                    Group = g1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Kanboard A Description"
                         
                };
                Kanboard k2 = new Kanboard()
                {
                    Name = "Kanboard B",
                    Group = g2,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Kanboard B Description"
                };

                Kanboard k3 = new Kanboard()
                {
                    Name = "Kanboard C",
                    Group = g3,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Kanboard C Description"
                };
                Kanboard k4 = new Kanboard()
                {
                    Name = "Kanboard D",
                    Group = g4,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Kanboard D Description"
                };
                db.Kanboards.Add(k1);
                db.Kanboards.Add(k2);
                db.Kanboards.Add(k3);
                db.Kanboards.Add(k4);
                #endregion

                #region Product data

                Product p1 = new Product()
                {
                    Name = "Product A",
                    Description = "Product A Description",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsBraveior = true
                         
                };
                Product p2 = new Product()
                {
                    Name = "Product B",
                    Description = "Product B Description",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsBraveior = true
                };
                Product p3 = new Product()
                {
                    Name = "Product C",
                    Description = "Product C Description",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsBraveior = true
                };
                Product p4 = new Product()
                {
                    Name = "Product D",
                    Description = "Product D Description",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsBraveior = true
                };
                db.Products.Add(p1);
                db.Products.Add(p2);
                db.Products.Add(p3);
                db.Products.Add(p4);
                #endregion

                #region Story data

                Story s1 = new Story()
                {
                    Name = "Story A",
                    Description = "Story A Description",
                    Status = 0,
                    AcceptanceCriteria = "Story A Acceptance Criteria",
                    Point = 1,
                    Product = p1,
                    CreationDate = DateTime.Now,
                    //CompletedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now

                };
                Story s2 = new Story()
                {
                    Name = "Story B",
                    Description = "Story B Description",
                    Status = 0,
                    AcceptanceCriteria = "Story B Acceptance Criteria",
                    Point = 1,
                    Product = p1,
                    CreationDate = DateTime.Now,
                    //CompletedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now

                };
                Story s3 = new Story()
                {
                    Name = "Story C",
                    Description = "Story C Description",
                    Status = 1,
                    AcceptanceCriteria = "Story C Acceptance Criteria",
                    Point = 1,
                    Product = p1,
                    CreationDate = DateTime.Now,
                    //CompletedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now

                };
                Story s4 = new Story()
                {
                    Name = "Story A",
                    Description = "Story A Description",
                    Status = 2,
                    AcceptanceCriteria = "Story A Acceptance Criteria",
                    Point = 1,
                    Product = p1,
                    CreationDate = DateTime.Now,
                    //CompletedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now

                };

                #endregion

                db.Stories.Add(s1);
                db.Stories.Add(s2);
                db.Stories.Add(s3);
                db.Stories.Add(s4);

                #region Task data

                Task t1 = new Task()
                {
                    Name = "Task A",
                    Description = "Task A Description",
                    Complexity = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Story = s1
                };
                Task t2 = new Task()
                {
                    Name = "Task B",
                    Description = "Task B Description",
                    Complexity = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Story = s1
                };
                Task t3 = new Task()
                {
                    Name = "Task C",
                    Description = "Task C Description",
                    Complexity = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Story = s1
                };
                Task t4 = new Task()
                {
                    Name = "Task D",
                    Description = "Task D Description",
                    Complexity = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Story = s1
                };
                db.Tasks.Add(t1);
                db.Tasks.Add(t2);
                db.Tasks.Add(t3);
                db.Tasks.Add(t4);
                #endregion


                #region KanbanStory data

                KanboardStory ks1 = new KanboardStory()
                {
                    Kanboard = k1,
                    Story = s1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                KanboardStory ks2 = new KanboardStory()
                {
                    Kanboard = k1,
                    Story = s2,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                KanboardStory ks3 = new KanboardStory()
                {
                    Kanboard = k1,
                    Story = s3,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                KanboardStory ks4 = new KanboardStory()
                {
                    Kanboard = k1,
                    Story = s4,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };

                db.KanboardStories.Add(ks1);
                db.KanboardStories.Add(ks2);
                db.KanboardStories.Add(ks3);
                db.KanboardStories.Add(ks4);

                #endregion

                #region UserTask

                UserTask ut1 = new UserTask()
                {
                     User = u1,
                     Task = t1,
                     CreationDate = DateTime.Now,
                     ModifiedDate = DateTime.Now,
                     IsActive = true
                };
                UserTask ut2 = new UserTask()
                {
                    User = u2,
                    Task = t1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };

                db.UserTasks.Add(ut1);
                db.UserTasks.Add(ut2);
                #endregion

                #region VLog data
                Vlog v1 = new Vlog()
                {
                    Name = "VLog A",
                    IsActive = true,
                    Url = "http://www.youtube.com",
                    User = u1,
                    Product = p1,
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Score =1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                Vlog v2 = new Vlog()
                {
                    Name = "VLog B",
                    IsActive = true,
                    Url = "http://www.youtube.com",
                    User = u1,
                    Product = p1,
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Score = 1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                Vlog v3 = new Vlog()
                {
                    Name = "VLog C",
                    IsActive = true,
                    Url = "http://www.youtube.com",
                    User = u1,
                    Product = p1,
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Score = 1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                Vlog v4 = new Vlog()
                {
                    Name = "VLog D",
                    IsActive = true,
                    Url = "http://www.youtube.com",
                    User = u1,
                    Product = p1,
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Score = 1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                db.Vlogs.Add(v1);
                db.Vlogs.Add(v2);
                db.Vlogs.Add(v3);
                db.Vlogs.Add(v4);

                #endregion

                #region Asset data

                Asset a1 = new Asset()
                {
                    Name = "Asset A",
                    Description = "Asset A Description",
                    Url = "http://www.youtube.com",
                    Points = 5,
                    User = u1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                Asset a2 = new Asset()
                {
                    Name = "Asset B",
                    Description = "Asset B Description",
                    Url = "http://www.youtube.com",
                    Points = 5,
                    User = u1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                Asset a3 = new Asset()
                {
                    Name = "Asset C",
                    Description = "Asset C Description",
                    Url = "http://www.youtube.com",
                    Points = 5,
                    User = u1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                Asset a4 = new Asset()
                {
                    Name = "Asset D",
                    Description = "Asset D Description",
                    Url = "http://www.youtube.com",
                    Points = 5,
                    User = u1,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                db.Assets.Add(a1);
                db.Assets.Add(a2);
                db.Assets.Add(a3);
                db.Assets.Add(a4);
                #endregion

                db.SaveChanges();
            }
        }
    }
}
