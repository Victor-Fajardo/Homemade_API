using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class PaymentResource
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string CardName { get; set; }
        public string PaymentDetail { get; set; }
        public DateTime Date { get; set; }
        public float Total { get; set; }
        public UserCommonResource UserCommon { get; set; }

    }
}
