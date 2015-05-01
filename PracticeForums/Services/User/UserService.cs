using PracticeForums.Data;
using PracticeForums.Models;
using PracticeForums.Services.Encryptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeForums.Services.User
{
    public class UserService : IUserService
    {
        private PracticeForumsDbContext context;
        private IEncryptor encryptor;

        public UserService(IEncryptor encryptor)
        {
            this.encryptor = encryptor;
            this.context = new PracticeForumsDbContext();
        }

        public bool Authenticate(string username, string password)
        {
            // if username (case insensitive search) and password match
            // return true
            // otherwise return false

            string encryptedPassword = this.encryptor.Encrypt(password);

            Models.User user = this.context.Users.Where(x => x.Username.ToLower() == username.ToLower() 
                && x.Password == encryptedPassword).SingleOrDefault();

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public void Register(Models.User user)
        {
            user.Password = this.encryptor.Encrypt(user.Password);

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public bool Exists(string username)
        {
            Models.User user = null;

            try
            {
                user = this.context.Users.Where(x => x.Username.ToLower() == username.ToLower()).SingleOrDefault();
            }
            catch (Exception exception)
            {
                var e = exception;
            }

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}