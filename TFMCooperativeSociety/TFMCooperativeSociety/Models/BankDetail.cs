using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models
{
    public abstract class BankDetail
    {      
                    [NotMapped]
                    public DropDown.BankName BankNameList { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Account Number")]
        [StringLength(60, ErrorMessage = "Use the 10 digit account number")]
        public string AccountNumber { get; set; }


        [StringLength(60, ErrorMessage = "Account Name not More 60 characters")]
        [DisplayName("Account Name")]
        public string AccounName { get; set; }

                [Phone]
                [StringLength(12, ErrorMessage = "Fill the 11 digit BVN Number")]
                public string BVN { get; set; }

        public string SortCode { get; set; }

      
    }
}