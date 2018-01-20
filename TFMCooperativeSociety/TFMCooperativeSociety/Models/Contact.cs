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

        [StringLength(100, ErrorMessage = "Name is too long")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "Name is too long")]
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(100, ErrorMessage = "Use a simpler email address")]
        public string Email { get; set; }
    
        public string Message { get; set; }
    }
}