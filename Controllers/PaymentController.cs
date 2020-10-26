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

        [HttpGet]
        public async Task<IEnumerable<PaymentResource>> GetAllAsync()
        {
            var payments = await _paymentService.ListAsync();
            var resources =  _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePaymentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Input");

            var payment = _mapper.Map<SavePaymentResource, Payment>(resource);

            var result = await _paymentService.SaveAsync(payment);
            if (!result.Succes)
                return BadRequest(result.Message);
            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);
            return Ok(paymentResource);
        }

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
