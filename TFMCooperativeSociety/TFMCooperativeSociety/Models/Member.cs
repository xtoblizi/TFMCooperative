using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models
{
    public class Member : Person
    {
        public string MemberId { get; set; }

        [DisplayName("Are you a TCWC Member")]
        public bool ISTCWC { get; set; } = false;

        [DisplayName("#TCWC MembershipCode")]
        public int? TCWCIDCode { get; set; }

        [DisplayName("Business Street")]
        public string BusinessStreet { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

        [DisplayName("Business City")]
        public string BusinessCity { get; set; }

        [DisplayName("Business State")]
        public string BusinessState { get; set; }

        [ScaffoldColumn(false)]
        public bool IsCompleted { get; set; } = false;

        public bool Active { get; set; } = true;
        //nav links
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<MemberBankDetail> MemberBankDetails { get; set; }

      
        public string BusinesFullAdress

        {
            get { return BusinessStreet + "," + ""+ BusinessCity +"," + "" + BusinessState + "," + ""+ "Nigeria."; }
            set { }
        }

        public string ResidentialFullAddress

        {
            get { return Street + ","+""+ Bus_stop +","+ "" + City + "," +""+ State + "," +""+ "Nigeria."; }
            set { }
        }
     
    }
}