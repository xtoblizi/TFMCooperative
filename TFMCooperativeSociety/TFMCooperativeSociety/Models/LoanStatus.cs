using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models
{
    public class LoanStatus
    {
        public int LoanStatusId { get; set; }

        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public string MessageContent { get; set; }


    }
}