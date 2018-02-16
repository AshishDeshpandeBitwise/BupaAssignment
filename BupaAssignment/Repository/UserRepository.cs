using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BupaAssignment.Data;
using System.Data.Entity;

namespace BupaAssignment.Repository
{
    public class UserRepository : IUserRepository
    {
        BupaEntities context = new BupaEntities();

        public BupaUser GetUserByUserName(string userName)
        {
            return context.BupaUsers.Where(u => u.UserName == userName).First();
        }

        public void Insert(BupaUser bupaUser)
        {
            context.BupaUsers.Add(bupaUser);
        }

        public void Update(BupaUser bupaUser)
        {
            context.Entry(bupaUser).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public bool IsUserNameExist(string userName)
        {
            var user = context.BupaUsers.Any(u => u.UserName == userName);
            if (user)
                return true;
            else
                return false;
        }

        public bool IsValidCredentials(BupaUser bupaUser)
        {
            var user = context.BupaUsers
                              .Where(u => u.UserName == bupaUser.UserName)
                              .Where(u => u.Password == bupaUser.Password)
                              .Any();
            if (user)
                return true;
            else
                return false;
        }
    }
}