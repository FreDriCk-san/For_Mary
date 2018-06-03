using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurity.Methods
{
    public class Admin
    {
        //Add User
        public static bool Registration(string login, string password, string roleName, string levelName)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var roleId = db.Roles.FirstOrDefault(r => r.Name == roleName).Id;
                    var levelId = db.Levels.FirstOrDefault(l => l.Name == levelName).Id;
                    db.Subjects.Add(new Models.Subject { Login = login, Password = password, AuthCount = 0, RoleId = roleId, LevelId = levelId });
                    var sub = db.UnregSubjects.FirstOrDefault(u => u.Login == login);
                    db.UnregSubjects.Remove(sub);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        //Add level
        public static bool AddLevel(string name, int countOfEnter, TimeSpan startTime, TimeSpan endTime)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var query = db.Levels.Add(new Models.Level { Name = name, CountOfEnter = countOfEnter, StartTime = startTime, EndTime = endTime });
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        
        //Update level
        public static bool UpdateLevel(Models.Level level)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var query = db.Levels.FirstOrDefault(q => (q.Id == level.Id));
                        query.Name = level.Name;
                        query.CountOfEnter = level.CountOfEnter;
                        query.StartTime = level.StartTime;
                        query.EndTime = level.EndTime;
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }


        //Delete level
        public static bool DeleteLevel(Models.Level level)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var toRemove = db.Levels.FirstOrDefault(t => t.Id == level.Id);
                    var query = db.Levels.Remove(toRemove);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        //Add role
        public static bool AddRole(string name, int priority, string allowedDays, TimeSpan allowedTime)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var query = db.Roles.Add(new Models.Role { Name = name, Priority = priority, AllowedDays = allowedDays, AllowedTime = allowedTime });
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        //Update role
        public static bool UpdateRole(Models.Role role)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var query = db.Roles.FirstOrDefault(q => q.Id == role.Id);
                        query.Name = role.Name;
                        query.Priority = role.Priority;
                        query.AllowedDays = role.AllowedDays;
                        query.AllowedTime = role.AllowedTime;
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        //Delete Role
        public static bool DeleteRole(Models.Role Role)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var toRemove = db.Roles.FirstOrDefault(t => t.Id == Role.Id);
                    var query = db.Roles.Remove(toRemove);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        //Update subject
        public static bool UpdateSubject(Models.Subject subject)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var query = db.Subjects.FirstOrDefault(q => q.Id == subject.Id);
                        query.Login = subject.Login;
                        query.Password = subject.Password;
                        query.BanId = subject.BanId;
                        query.LevelId = subject.LevelId;
                        query.RoleId = subject.RoleId;
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        //Delete Subject
        public static bool DeleteSubject(Models.Subject subject)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var toRemove = db.Subjects.FirstOrDefault(t => t.Id == subject.Id);
                    var query = db.Subjects.Remove(toRemove);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

    }
}
