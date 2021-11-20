using PictureShare.Context;
using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PictureShare.Data_Components.implementation
{
    public class UserImpl : IUser
    {
        private ApplicationDatabaseContext dbContext;

        public UserImpl(ApplicationDatabaseContext a)
        {
            dbContext = a;
        }
        public void deleteAccount(string email)
        {
            User user = getUser(email);
            dbContext.user.Remove(user);
        }

        public User getUser(string email)
        {
            User user = dbContext.user.FromSqlRaw($"select * from [PictureShare].[dbo].[user] where email='" +email+"'").FirstOrDefault();
            return user;
        }

        public bool userLogin(string email, string passsword)
        {
            int count = dbContext.Database.ExecuteSqlRaw($"select count(*) from user where email='"+email+"' and password='"+passsword+"';");
            if (count == 1) {
                return true;
            }
            return false;
        }

        public void userRegister(User user)
        {
            user.user_id = new Guid();
            dbContext.user.Add(user);
        }
    }
}
