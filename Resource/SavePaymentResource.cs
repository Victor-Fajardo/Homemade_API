using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class SavePaymentResource
    {
        [Required]
        public int CardNumber { get; set; }
        public string CardName { get; set; }
        public string PaymentDetail { get; set; }
        public DateTime Date { get; set; }
        public float Total { get; set; }
    }
}
