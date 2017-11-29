using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TFMCooperativeSociety.Models
{
    public class MemberBankDetail : BankDetail
    {
        public int MemberBankDetailId { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;

        // nav props

        public string MemberId { get; set; }
        public virtual Member Member { get; set; }

    }

    public class CooperativeBankDetail : BankDetail
    {
        public int CooperativeBankDetailId { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool Active { get; set; } = true;
    }

}