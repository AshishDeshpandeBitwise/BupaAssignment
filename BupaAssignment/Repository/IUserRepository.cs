using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BupaAssignment.Data;

namespace BupaAssignment.Repository
{
    public interface IUserRepository
    {
        BupaUser GetUserByUserName(string userName);
        void Insert(BupaUser bupaUser);

        void Update(BupaUser bupaUser);

        void SaveChanges();

        bool IsUserNameExist(string Username);

        bool IsValidCredentials(BupaUser bupaUser);
    }
}