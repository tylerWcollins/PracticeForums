using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForums.Services.Encryptor
{
    public interface IEncryptor
    {
        string Encrypt(string input);
    }
}
