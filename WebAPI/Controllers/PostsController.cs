using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase {

        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository) {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts() {

            var posts = await _postRepository.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id) {

            var post = await _postRepository.GetByIdAsync(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(Post post) {

            await _postRepository.AddAsync(post);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(Post post) {

            await _postRepository.UpdateAsync(post);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id) {

            await _postRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
