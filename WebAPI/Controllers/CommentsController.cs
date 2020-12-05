using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers {
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase {

        private readonly ICommentRepository _commentRepository;

        public CommentsController(ICommentRepository commentRepository) {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments() {

            var comments = await _commentRepository.GetAllAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id) {

            var comment = await _commentRepository.GetByIdAsync(id);
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> InsertComment(Comment comment) {

            await _commentRepository.AddAsync(comment);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comment comment) {

            await _commentRepository.UpdateAsync(comment);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id) {

            await _commentRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
