using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Data_Components
{
    public interface IUser
    {
        public bool userLogin(string email, string passsword);
        public void userRegister(User user);
        public void deleteAccount(string email);

        User getUser(string email);
    }
}
