using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models
{
    public class Payment
    {

        public int PaymentId { get; set; }

        //nav
        public string MemberId { get; set; }
        public virtual Member Member { get; set; }

         //nav end

         [Required]
        public decimal AmountPaid { get; set; }

        [DisplayName("Teller Id or Transction ID")]
        public string TellerID_TransactionID { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfPayment { get; set; }

        [DisplayName("Depositor's Name")]
        [Required]
        public string DepositorName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DateCreated
        {
            get { return DateTime.Now; }

            set { }
        }

        [ScaffoldColumn(false)]
        public bool Active { get; set; }

        public bool IsApproved { get; set; } = false;
    }
}