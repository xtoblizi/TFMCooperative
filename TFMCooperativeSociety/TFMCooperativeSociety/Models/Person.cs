using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models
{
    public abstract class Person
    {
        // [Required(ErrorMessage = "Your First name is required")]
        //[StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        // [Required]
       // [StringLength(100, ErrorMessage = "Middle name cannot be longer than 100 characters.")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        // [Required(ErrorMessage ="Your Last name is required")]
        //[StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Enter a peculiar username")]
        [StringLength(30,ErrorMessage ="Not more than 30 characters")]
        public string UserName { get; set; }

            public string Gender { get; set; }

            [NotMapped]
            public DropDown.Gender GenderList { get; set; }

       // [Required(ErrorMessage ="Your Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        // [Required(ErrorMessage = "Your Phone Number is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => LastName + " " + FirstName + " " + MiddleName;

        [Display(Name = "Town Of Birth")]
        public string TownOfBirth { get; set; }

            [NotMapped]
            [Display(Name = "State of Origin")]
            public DropDown.State StateOfOriginList { get; set; }

            public string StateOfOrigin { get; set; }

        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }=DateTime.Now;

        // REsential Address Details.........
            public string Street { get; set; }

            public string Bus_stop { get; set; }

            public string City { get; set; }

            public string State { get; set; }

        [ScaffoldColumn(false)]
        public bool CompletedRegistration { get; set; }
        // Image props
        public byte[] Passport { get; set; }

        [Display(Name = "Upload A Passport/Picture")]
        [ValidateFile(ErrorMessage = "Please select a PNG/JPEG image smaller than 20kb")]
        [NotMapped]
        public HttpPostedFileBase ImageFile
        {
            get
            {
                return null;
            }

            set
            {
                try
                {
                    var target = new MemoryStream();

                    if (value.InputStream == null)
                        return;

                    value.InputStream.CopyTo(target);
                    Passport = target.ToArray();

                    
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                }
            }
        }

        public string ImageUrl { get; set; }
    }
}