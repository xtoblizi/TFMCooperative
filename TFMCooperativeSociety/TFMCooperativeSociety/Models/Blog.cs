using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }

        public string Message { get; set; }

        public string CommentBy { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}

