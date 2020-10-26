using Homemade.Domain.Models;
using Homemade.Domain.Persistence.Contexts;
using Homemade.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Persistence.Repositories
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        } 

        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _context.Payments.ToListAsync();
        }
    }
}
