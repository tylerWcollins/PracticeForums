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
        //Composite key prevents spammers
        [Key, Column(Order=1)]
        public string CMessage { get; set; }

        [Key, Column(Order=0)]
        public Thread Thread { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CPostTime { get; set; }

        //Each Thread can have multiple comments, sorted by date time
        //One (Thread) to many relationship
 
    }
}