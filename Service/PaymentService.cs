using Homemade.Domain.Models;
using Homemade.Domain.Repositories;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Homemade.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserCommonRepository _userCommonRepository;

        public PaymentService(IPaymentRepository paymentRepository, IUserCommonRepository userCommonRepository, IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _userCommonRepository = userCommonRepository;
        }

        public async Task<PaymentResponse> DeleteAsync(int id)
        {
            var existingPayment = await _paymentRepository.FindById(id);

            if (existingPayment == null)
                return new PaymentResponse("Payment not found");
            try
            {
                _paymentRepository.Remove(existingPayment);
                await _unitOfWork.CompleteAsync();
                return new PaymentResponse(existingPayment);
            }
            catch (Exception ex)
            {
                return new PaymentResponse($"An error ocurred while deleting Payment: {ex.Message}");
            }

        }

        public async Task<PaymentResponse> GetByIdAsync(int id)
        {
            var existingPayment = await _paymentRepository.FindById(id);
            if (existingPayment == null)
                return new PaymentResponse("Payment not Found");
            return new PaymentResponse(existingPayment);
        }

        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _paymentRepository.ListAsync();
        }

        public async Task<PaymentResponse> SaveAsync(Payment payment, int userCommontId)
        {
            var existingUser = await _userCommonRepository.FindById(userCommontId);
            if (existingUser == null)
            {
                return new PaymentResponse("User not found");
            }
            payment.UserCommon = existingUser;
            try
            {
                await _paymentRepository.AddAsync(payment);
                await _unitOfWork.CompleteAsync();
                return new PaymentResponse(payment);
            }
            catch(Exception ex)
            {
                return new PaymentResponse($"An error ocurred while saving the payment: {ex.Message}");
            }
        }

        public async Task<PaymentResponse> UpdateAsync(int id, Payment payment)
        {
            var existingPayment = await _paymentRepository.FindById(id);

            if (existingPayment == null)
                return new PaymentResponse("Payment Not Found");
            existingPayment.CardName = payment.CardName;

            try
            {
                _paymentRepository.Update(existingPayment);
                await _unitOfWork.CompleteAsync();
                return new PaymentResponse(existingPayment);
            }
            catch(Exception ex)
            {
                return new PaymentResponse($"An error ocurred while updating Payment: {ex.Message}");
            }
        }
    }
}
