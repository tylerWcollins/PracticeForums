using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PracticeForums.Models
{
    public class Comment
    {
        [Key]
        [Column(Order = 0)]
        public string UserID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ThreadID { get; set; }
        public string Message { get; set; }
        public DateTime PostTime { get; set; }

        public virtual Thread Thread { get; set; }

        //Each Thread can have multiple comments, sorted by date time
        //One (Thread) to many relationship
    }
}