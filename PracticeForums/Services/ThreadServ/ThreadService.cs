﻿using PracticeForums.Data;
using PracticeForums.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        //public List<Comment> GetComments(int ID)
        //{
        //    List<Comment> comments = new List<Comment> { };

        //    string query = "SELECT * FROM Comment WHERE Thread.Id=ID";

        //    SqlCommand cmd = new SqlCommand(query);
        //    DataSet ds = GetData(cmd);
        //    DataTable dt = ds.Tables[0];
        //    foreach (DataRow item in ds.Tables[0].Rows)
        //    {
        //        Comment comm = new Comment();
        //        comm.CMessage = item["CMessage"].ToString();
        //        comm.CPostTime = item["CPostTime"].ToDateTime();
        //        comm.CUsername = item["CUsername"].ToString();
        //        comments.Add(comm);
        //    }

        //    return comments;
            
        //}

        public Thread GetPostingById(int id)
        {
            return this.context.Threads.Where(x => x.Id == id).SingleOrDefault();
        }

        public void SaveThread(Thread thread)
        {
            this.context.Threads.Add(thread);
            this.context.SaveChanges();
        }

        public void DeletePosting(int id)
        {
            var thread = this.context.Threads.Where(x => x.Id == id).SingleOrDefault();
            var comments = this.context.Comments.Where(x => x.Thread.Id == id).SingleOrDefault();
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