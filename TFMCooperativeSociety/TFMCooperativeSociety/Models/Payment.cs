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

        public decimal AmountPaid { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfPayment { get; set; }

        public bool ISApproved { get; set; }
        [DisplayName("Teller Id or Transction ID")]
        public string TellerID_TransactionID { get; set; }

        public string MemberID { get; set; }
        public virtual Member Member { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DateCreated
        {
            get { return DateTime.Now; }

            set { }
        }

        [ScaffoldColumn(false)]
        public bool Active { get; set; }
    }
}