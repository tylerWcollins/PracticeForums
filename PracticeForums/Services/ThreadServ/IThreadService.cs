using PracticeForums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForums.Services.ThreadServ
{
    public interface IThreadService
    {
        //List<Comment> GetComments();

        Thread GetThreadById(int id);

        void SaveThread(Thread thread);

        void DeletePosting(int id);
    }
}
