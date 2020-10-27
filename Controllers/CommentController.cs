using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Homemade.Domain.Services;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Homemade.Resource;
using Homemade.Extensions;
using Homemade.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homemade.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Create a Comment",
            Description = "Create a Comment",
            OperationId = "CreateComment",
            Tags = new[] { "Comments" }
        )]
        [SwaggerResponse(200, "Comment was created", typeof(CommentResource))]
        [HttpPost("publicationId/userId")]
        public async Task<IActionResult> PostAsync([FromBody] SaveCommentResource resource, int publicationId, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);

            var result = await _commentService.SaveAsync(comment, publicationId, userId);

            if (!result.Succes)
                return BadRequest(result.Message);

            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);

            return Ok(commentResource);

        }

        [SwaggerOperation(
            Summary = "Update a Comment",
            Description = "Update a Comment",
            OperationId = "UpdateComment",
            Tags = new[] { "Comments" }
        )]
        [SwaggerResponse(200, "Comment was updated", typeof(CommentResource))]
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCommentResource resource)
        {
            var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
            var result = await _commentService.UpdateAsync(id, comment);

            if (!result.Succes)
                return BadRequest(result.Message);
            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }
        [SwaggerOperation(
            Summary = "Delete a Comment",
            Description = "Delete a Comment",
            OperationId = "DeleteComment",
            Tags = new[] { "Comments" }
        )]
        [SwaggerResponse(200, "Comment was delete", typeof(CommentResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _commentService.Delete(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
            return Ok(commentResource);
        }
    }
}
