using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Homemade.Domain.Models;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using Homemade.Resource;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homemade.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public  PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [SwaggerOperation(
             Summary = "List all Payments",
             Description = "List of Payments",
             OperationId = "ListAllPayments",
             Tags = new[] { "Payments" }
             )]
        [SwaggerResponse(200, "List of Payments", typeof(IEnumerable<PaymentResource>))]
        [ProducesResponseType(typeof(IEnumerable<PaymentResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<PaymentResource>> GetAllAsync()
        {
            var payments = await _paymentService.ListAsync();
            var resources =  _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Create a Payment",
            Description = "Create a Payment",
            OperationId = "CreatePayment",
            Tags = new[] { "Payments" }
        )]
        [SwaggerResponse(200, "Payment was created", typeof(PaymentResource))]
        [HttpPost("userCommonId")]
        public async Task<IActionResult> PostAsync([FromBody] SavePaymentResource resource, int userCommonId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Input");

            var payment = _mapper.Map<SavePaymentResource, Payment>(resource);

            var result = await _paymentService.SaveAsync(payment, userCommonId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);
            return Ok(paymentResource);
        }

        [SwaggerOperation(
           Summary = "Update a Payment",
           Description = "Update a Payment",
           OperationId = "UpdatePayment",
           Tags = new[] { "Payments" }
       )]
        [SwaggerResponse(200, "Payment was updated", typeof(PaymentResource))]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentResource resource)
        {
            var payment = _mapper.Map<SavePaymentResource, Payment>(resource);
            var result = await _paymentService.UpdateAsync(id, payment);
            if (!result.Succes)
                return BadRequest(result.Message);
            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);
            return Ok(paymentResource);
        }

        // DELETE api/<IngredientController>/5
        [SwaggerOperation(
            Summary = "Delete a Payment",
            Description = "Delete a Payment",
            OperationId = "DeletePayment",
            Tags = new[] { "Payments" }
        )]
        [SwaggerResponse(200, "Payment was delete", typeof(PaymentResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _paymentService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);
            return Ok(paymentResource);
        }
    }
}
