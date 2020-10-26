using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> ListAsync();
        Task<PaymentResponse> GetByIdAsync(int id);
        Task<PaymentResponse> SaveAsync(Payment payment, int userCommontId);
        Task<PaymentResponse> UpdateAsync(int id, Payment payment);
        Task<PaymentResponse> DeleteAsync(int id);
    }
}
