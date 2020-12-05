using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers {
    [Route("api/postlikes")]
    [ApiController]
    public class PostLikesController : ControllerBase {

        private readonly IPostLikeRepository _postLikeRepository;

        public PostLikesController(IPostLikeRepository postLikeRepository) {
            _postLikeRepository = postLikeRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetPostLikes() {

        //    var posts = await _postLikeRepository.GetAllAsync();
        //    return Ok(posts);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostLike(int id) {

            var postLike = await _postLikeRepository.GetByIdAsync(id);
            return Ok(postLike);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPostLike(PostLike postLike) {

            await _postLikeRepository.AddAsync(postLike);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostLike(PostLike postLike) {

            await _postLikeRepository.UpdateAsync(postLike);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostLike(int id) {

            await _postLikeRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
