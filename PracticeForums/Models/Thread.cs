using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeForums.Models
{
    public class Thread
    {
        [Key]
        public int ThreadID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        //Foreign Key
        //User can have mutliple posts, thread can only have one user making it
        public string UserID { get; set; }
        public DateTime PostTime { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}