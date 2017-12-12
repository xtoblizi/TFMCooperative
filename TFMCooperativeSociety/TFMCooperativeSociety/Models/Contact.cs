using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [StringLength(100, ErrorMessage = "use a simpler email address")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "use a simpler email address")]
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(100, ErrorMessage = "use a simpler email address")]
        public string Email { get; set; }

        public bool IsSubsribed { get; set; } = false;

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}