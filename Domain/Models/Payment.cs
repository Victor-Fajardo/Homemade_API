using Homemade.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string CardName { get; set; }
        public string PaymentDetail { get; set; }
        public DateTime Date { get; set; }
        public float Total { get; set; }
        public int UserCommonId { get; set; }
        public UserCommon UserCommon { get; set; }


    }
}
