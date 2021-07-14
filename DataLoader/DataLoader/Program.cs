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
                    CreatedDate = DateTime.Now

                };
                Group g2 = new Group()
                {
                    Name = "GroupB",
                    Institution = i1,
                    CreatedDate = DateTime.Now

                };
                Group g3 = new Group()
                {
                    Name = "GroupC",
                    Institution = i2,
                    CreatedDate = DateTime.Now

                };
                Group g4 = new Group()
                {
                    Name = "GroupD",
                    Institution = i2,
                    CreatedDate = DateTime.Now

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
                    Group = g1
                };
                User u2 = new User()
                {
                    Name = "Sreehari",
                    Email = "sree@email.com",
                    Institution = i1,
                    Password = "password",
                    Role = "Student",
                    Group = g1
                };
                User u3 = new User()
                {
                    Name = "Srilakshmini",
                    Email = "lami@email.com",
                    Institution = i1,
                    Password = "password",
                    Role = "Student",
                    Group = g2
                };
                User u4 = new User()
                {
                    Name = "Aswath",
                    Email = "aswath@email.com",
                    Institution = i1,
                    Password = "password",
                    Role = "Student",
                    Group = g2
                };
                User u5 = new User()
                {
                    Name = "Rajesh",
                    Email = "rajesh@email.com",
                    Institution = i2,
                    Password = "password",
                    Role = "Student",
                    Group = g3
                };
                User u6 = new User()
                {
                    Name = "Leema",
                    Email = "leema@email.com",
                    Institution = i2,
                    Password = "password",
                    Role = "Student",
                    Group = g3
                };
                User u7 = new User()
                {
                    Name = "Praveena",
                    Email = "praveena@email.com",
                    Institution = i2,
                    Password = "password",
                    Role = "Student",
                    Group = g4
                };
                User u8 = new User()
                {
                    Name = "Subhashini",
                    Email = "suba@email.com",
                    Institution = i2,
                    Password = "password",
                    Role = "Student",
                    Group = g4
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

                


                #region Channel data

                Channel c1 = new Channel()
                {
                    Name = "Channel A",
                    Group = g1,
                    CreatedDate = DateTime.Now,
                };
                Channel c2 = new Channel()
                {
                    Name = "Channel B",
                    Group = g1,
                    CreatedDate = DateTime.Now,
                };
                Channel c3 = new Channel()
                {
                    Name = "Channel C",
                    Group = g2,
                    CreatedDate = DateTime.Now,
                };
                Channel c4 = new Channel()
                {
                    Name = "Channel D",
                    Group = g2,
                    CreatedDate = DateTime.Now,
                };

                db.Channels.Add(c1);
                db.Channels.Add(c2);
                db.Channels.Add(c3);
                db.Channels.Add(c4);
                #endregion

                #region Kanboard data

                Kanboard k1 = new Kanboard()
                {
                    Name = "Kanboard A",
                    Group = g1
                };
                Kanboard k2 = new Kanboard()
                {
                    Name = "Kanboard B",
                    Group = g2
                };

                Kanboard k3 = new Kanboard()
                {
                    Name = "Kanboard C",
                    Group = g3
                };
                Kanboard k4 = new Kanboard()
                {
                    Name = "Kanboard D",
                    Group = g4
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
                };
                Product p2 = new Product()
                {
                    Name = "Product B",
                    Description = "Product B Description",
                };
                Product p3 = new Product()
                {
                    Name = "Product C",
                    Description = "Product C Description",
                };
                Product p4 = new Product()
                {
                    Name = "Product D",
                    Description = "Product D Description",
                };
                db.Products.Add(p1);
                db.Products.Add(p2);
                db.Products.Add(p3);
                db.Products.Add(p4);
                #endregion

                #region Task data

                Task t1 = new Task()
                {
                    Name = "Task A",
                    Product = p1,
                    User = u1,
                    Kanboard = k1,
                    Description = "Task A Description",
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Technical = 1,
                    Score = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED"
                };
                Task t2 = new Task()
                {
                    Name = "Task B",
                    Product = p1,
                    User = u1,
                    Kanboard = k1,
                    Description = "Task B Description",
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Technical = 1,
                    Score = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED"
                };
                Task t3 = new Task()
                {
                    Name = "Task C",
                    Product = p1,
                    User = u1,
                    Kanboard = k1,
                    Description = "Task C Description",
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Technical = 1,
                    Score = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED"
                };
                Task t4 = new Task()
                {
                    Name = "Task D",
                    Product = p1,
                    User = u1,
                    Kanboard = k1,
                    Description = "Task D Description",
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Technical = 1,
                    Score = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED"
                };
                Task t5 = new Task()
                {
                    Name = "Task E",
                    Product = p1,
                    User = u1,
                    Kanboard = k1,
                    Description = "Task E Description",
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Technical = 1,
                    Score = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED"
                };
                Task t6 = new Task()
                {
                    Name = "Task F",
                    Product = p1,
                    User = u1,
                    Kanboard = k1,
                    Description = "Task F Description",
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Technical = 1,
                    Score = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED"
                };
                Task t7 = new Task()
                {
                    Name = "Task G",
                    Product = p1,
                    User = u1,
                    Kanboard = k1,
                    Description = "Task G Description",
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Technical = 1,
                    Score = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED"
                };
                Task t8 = new Task()
                {
                    Name = "Task H",
                    Product = p1,
                    User = u1,
                    Kanboard = k1,
                    Description = "Task H Description",
                    Complexity = 1,
                    Innovation = 1,
                    Presentation = 1,
                    Technical = 1,
                    Score = 1,
                    StartDate = DateTime.Now,
                    CompletionDate = DateTime.Now,
                    Status = "NOTSTARTED"
                };
                db.Tasks.Add(t1);
                db.Tasks.Add(t2);
                db.Tasks.Add(t3);
                db.Tasks.Add(t4);
                db.Tasks.Add(t5);
                db.Tasks.Add(t6);
                db.Tasks.Add(t7);
                db.Tasks.Add(t8);
                #endregion

                #region Message data

                Message m1 = new Message()
                {
                    MessageContent = "Message Content A",
                    MessageLike = 4,
                    BraveiorLike = true,
                    Channel = c1,
                    User=u1,
                    CreatedDate = DateTime.Now
                };
                Message m2 = new Message()
                {
                    MessageContent = "Message Content B",
                    MessageLike = 2,
                    BraveiorLike = false,
                    Channel = c1,
                    User = u2,
                    CreatedDate = DateTime.Now
                };
                Message m3 = new Message()
                {
                    MessageContent = "Message Content C",
                    MessageLike = 6,
                    BraveiorLike = false,
                    Channel = c1,
                    User = u1,
                    CreatedDate = DateTime.Now
                };
                Message m4 = new Message()
                {
                    MessageContent = "Message Content D",
                    MessageLike = 8,
                    BraveiorLike = false,
                    Channel = c1,
                    User = u2,
                    CreatedDate = DateTime.Now
                };
                Message m5 = new Message()
                {
                    MessageContent = "Message Content E",
                    MessageLike = 4,
                    BraveiorLike = false,
                    Channel = c1,
                    User = u1,
                    CreatedDate = DateTime.Now
                };
                Message m6 = new Message()
                {
                    MessageContent = "Message Content F",
                    MessageLike = 4,
                    BraveiorLike = true,
                    Channel = c1,
                    User = u2,
                    CreatedDate = DateTime.Now
                };
                Message m7 = new Message()
                {
                    MessageContent = "Message Content G",
                    MessageLike = 4,
                    BraveiorLike = false,
                    Channel = c1,
                    User = u1,
                    CreatedDate = DateTime.Now
                };
                Message m8 = new Message()
                {
                    MessageContent = "Message Content H",
                    MessageLike = 4,
                    BraveiorLike = false,
                    Channel = c1,
                    User = u1,
                    CreatedDate = DateTime.Now
                };
                db.Messages.Add(m1);
                db.Messages.Add(m2);
                db.Messages.Add(m3);
                db.Messages.Add(m4);
                db.Messages.Add(m5);
                db.Messages.Add(m6);
                db.Messages.Add(m7);
                db.Messages.Add(m8);

                #endregion


                #region VLog data
                Vlog v1 = new Vlog()
                {
                    Name = "VLog A",
                    IsActive = true,
                    Url = "http://www.youtube.com",
                    User = u1,
                    Task = t1
                };
                Vlog v2 = new Vlog()
                {
                    Name = "VLog B",
                    IsActive = true,
                    Url = "http://www.youtube.com",
                    User = u1,
                    Task = t2
                };
                Vlog v3 = new Vlog()
                {
                    Name = "VLog C",
                    IsActive = true,
                    Url = "http://www.youtube.com",
                    User = u1,
                    Task = t3
                };
                Vlog v4 = new Vlog()
                {
                    Name = "VLog D",
                    IsActive = true,
                    Url = "http://www.youtube.com",
                    User = u1,
                    Task = t4
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
                    User=u1
                };
                Asset a2 = new Asset()
                {
                    Name = "Asset B",
                    Description = "Asset B Description",
                    Url = "http://www.youtube.com",
                    Points = 5,
                    User = u1
                };
                Asset a3 = new Asset()
                {
                    Name = "Asset C",
                    Description = "Asset C Description",
                    Url = "http://www.youtube.com",
                    Points = 5,
                    User = u1
                };
                Asset a4 = new Asset()
                {
                    Name = "Asset D",
                    Description = "Asset D Description",
                    Url = "http://www.youtube.com",
                    Points = 5,
                    User = u1
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
