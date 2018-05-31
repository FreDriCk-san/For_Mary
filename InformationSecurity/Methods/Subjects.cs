using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurity.Methods
{
    public class Subjects
    {

        public static Models.Subject Authorization(string login, string password)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var user = db.Subjects.FirstOrDefault(s => (s.Login == login) && (s.Password == password));
                    return user;
                }
            }

            catch { }

            return null;
        }


        public static bool RegisterTask(string login)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    db.UnregSubjects.Add(new Models.UnregisteredSubjects { Login = login });
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        public static bool ChangePassword(Models.Subject subject, string password)
        {
            try
            {
                using (var db = new Context.ContextDB())
                {
                    var user = db.Subjects.FirstOrDefault(u => (u.Id == subject.Id));
                    user.Password = password;
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        //public static bool Authorization(string login, string password)
        //{

        //    using (var db = new Context.ContextDB())
        //    {
        //        if (db.Subjects.Any(s => (s.Login == login) && (s.Password == password)))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}


        //public static async Task<Models.Subject> Auth(string login, string password)
        //{
        //    Models.Subject user = null;

        //    using (var db = new Context.ContextDB())
        //    {
        //        user = await (db.Subjects.Where(s => (s.Login == login) && (s.Password == password)).FirstOrDefaultAsync<Models.Subject>());
        //    }

        //    return user;
        //}

    }
}
