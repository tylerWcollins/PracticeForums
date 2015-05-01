using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForums.Services.User
{
    public interface IUserService
    {
        bool Authenticate(string username, string password);

        void Register(Models.User user);

        bool Exists(string username);
    }
}
