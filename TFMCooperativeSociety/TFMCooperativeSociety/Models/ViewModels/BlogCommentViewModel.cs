using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models.ViewModels
{
    public class BlogCommentViewModel
    {
        public Blog Blog { get; set; }

        public List<Comment> Comments { get; set; }
    }
}