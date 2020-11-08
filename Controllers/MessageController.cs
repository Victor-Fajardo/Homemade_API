using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Homemade.Domain.Services;
using Homemade.Resource;
using Homemade.Domain.Models;
using Homemade.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homemade.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Create a Message",
            Description = "Create a Message",
            OperationId = "CreateMessage",
            Tags = new[] { "Messages" }
        )]
        [SwaggerResponse(200, "Message was created", typeof(MessageResource))]
        [HttpPost("userId/chatId")]
        public async Task<IActionResult> PostAsync([FromBody] SaveMessageResource resource, int userId, int chatId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var message = _mapper.Map<SaveMessageResource, Message>(resource);

            var result = await _messageService.SaveAsync(message, chatId, userId);

            if (!result.Succes)
                return BadRequest(result.Message);

            var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);

            return Ok(messageResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Message",
            Description = "Delete a Message",
            OperationId = "DeleteMessage",
            Tags = new[] { "Messages" }
        )]
        [SwaggerResponse(200, "Message was delete", typeof(MessageResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _messageService.Delete(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);
            return Ok(messageResource);
        }

        [SwaggerOperation(
            Summary = "List all Message by Chat Id",
            Description = "List of Message for a Chat",
            OperationId = "ListAllMessagesByChat",
            Tags = new[] { "Messages" }
        )]
        [SwaggerResponse(200, "List of Messages for a Chat", typeof(IEnumerable<MessageResource>))]
        [HttpGet("chatId")]
        public async Task<IEnumerable<MessageResource>> GetAllByChatIdAsync(int chatId)
        {
            var messages = await _messageService.ListByChatIdAsync(chatId);
            var resources = _mapper
                .Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
            return resources;
        }

    }
}
