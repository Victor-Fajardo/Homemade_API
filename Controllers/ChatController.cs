using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Homemade.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Homemade.Resource;
using Homemade.Extensions;
using Homemade.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homemade.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatController(IChatService chatService, IMapper mapper)
        {
            _chatService = chatService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Create a Chat",
            Description = "Create a Chat",
            OperationId = "CreateChat",
            Tags = new[] { "Chats" }
        )]
        [SwaggerResponse(200, "Chat was created", typeof(ChatResource))]
        [HttpPost("user1Id/user2Id")]
        public async Task<IActionResult> PostAsync([FromBody] SaveChatResource resource, int user1Id, int user2Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var chat = _mapper.Map<SaveChatResource, Chat>(resource);

            var result = await _chatService.SaveAsync(chat, user1Id, user2Id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var chatResource = _mapper.Map<Chat, ChatResource>(result.Resource);

            return Ok(chatResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Chat",
            Description = "Delete a Chat",
            OperationId = "DeleteChat",
            Tags = new[] { "Chats" }
        )]
        [SwaggerResponse(200, "Chat was delete", typeof(ChatResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _chatService.Delete(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var chatResource = _mapper.Map<Chat, ChatResource>(result.Resource);
            return Ok(chatResource);
        }

    }
}
