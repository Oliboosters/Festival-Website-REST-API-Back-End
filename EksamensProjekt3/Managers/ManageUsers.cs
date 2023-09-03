using System;
using System.Collections.Generic;
using System.Linq;
using EksamensProjekt3.Controllers;

//using ModelLib.model;

namespace EksamensProjekt3.Managers
{
    public class ManageUsers:IManageUsers
    {
        //static int idnr = 1;

        DatabaseContext Context;
        
        //private static List<User> list = new List<User>()
        //{
        //    new User(idnr++,true, "mail@mail.dk","kode1","navn1","vej1",1234),
        //    new User(idnr++,false, "mail@gmail.com","kode2","navn2","vej2",4321),
        //    new User(idnr++,false, "mail@hotmail.dk","kode3","navn3","vej3",3241),
        //    new User(idnr++,false, "mail@mail.com","kode4","navn4","vej4",2314),
        //};

        public ManageUsers(DatabaseContext context)
        {
             Context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return Context.FestivalUsers;
        }

        public User Get(int id)
        {
            if (Context.FestivalUsers.FirstOrDefault(p => p.Id == id)!=null)
            {
                return Context.FestivalUsers.FirstOrDefault(p => p.Id == id);
            }

            throw new KeyNotFoundException($"Id {id} findes ikke");
        }

        public bool Create(User user)
        {
            User usercheck  = Context.FestivalUsers.FirstOrDefault(u => u.Email == user.Email);
          
            if (usercheck==null)
            {
                List<User> userlist = Context.FestivalUsers.ToList();
                user.Id = userlist.Last().Id + 1;
                Context.Add(user);
                Context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Email already in use");
            }
           
            return true;
        }

        public bool Update(int id, User user)
        {
            if (Get(id) != null)
            {
                Get(id).Email = user.Email;
                Get(id).Password = user.Password;
                Context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Id {id} findes ikke");
            }

            return true;
            
        }

        public User Delete(int id)
        {
            User p = Get(id);
            Context.FestivalUsers.Remove(p);
            Context.SaveChanges(); 

            return p;
        }
    }
}
