using PracticeForums.Data;
using PracticeForums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeForums.Services.ThreadServ
{
    public class ThreadService : IThreadService
    {
        private PracticeForumsDbContext context;

        public ThreadService()
        {
            this.context = new PracticeForumsDbContext();
        }

        public List<Thread> GetPostings()
        {
            var postings = this.context.Threads.ToList();

            return this.context.Threads.ToList();
        }

        public Thread GetPostingById(int id)
        {
            return this.context.Threads.Where(x => x.ThreadID == id).SingleOrDefault();
        }

        public void SaveThread(Thread thread)
        {
            this.context.Threads.Add(thread);
            this.context.SaveChanges();
        }

        public void DeletePosting(int id)
        {
            var thread = this.context.Threads.Where(x => x.ThreadID == id).SingleOrDefault();
            var comments = this.context.Comments.Where(x => x.Thread.ThreadID == id).SingleOrDefault();
            this.context.Threads.Remove(thread);
            this.context.Comments.Remove(comments);
            this.context.SaveChanges();
        }


        public Thread GetThreadById(int id)
        {
            throw new NotImplementedException();
        }
    }
}