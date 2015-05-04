using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PracticeForums.Models
{
    public class Thread
    {
        public Thread()
        {
            this.Comments = new List<Comment>();
        }

        [Key, Column(Order=0)]
        public int ThreadID { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime PostTime { get; set; }

        [Key, Column(Order=1)]
        public string Username { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}