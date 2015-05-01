using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForums.Services.Auth
{
    public interface IAuthService
    {
        void SetAuthCookie(string username, bool persist);
        void SignOut();
    }
}
