using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PracticeForums.Services.Auth
{
    public class AuthService : IAuthService
    {
        public void SetAuthCookie(string username, bool persist)
        {
            FormsAuthentication.SetAuthCookie(username, persist);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}