using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeForums.Models
{
    public class DiscussionViewModel
    {
        public string ThreadTitle { get; set; }
        public string ThreadUser { get; set; }
        public string ThreadMessage { get; set; }


        public string CommentUser { get; set; }
        public string CommentMessage { get; set; }

        public DateTime ThreadPostTime { get; set; }
        public DateTime CommentPostTime { get; set; }

    }
}