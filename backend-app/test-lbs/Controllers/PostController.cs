using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test_lbs.DB;
using test_lbs.dto;
using test_lbs.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test_lbs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetComment")]
        public async Task<ActionResult> GetComment()
        {
            //Todo: Implement this method
            List<postDto> listComment = await _postService.getComment();

            return Ok(listComment);
        }

        [HttpPost("PostComment")]
        public async Task<ActionResult> PostComment([FromBody] postRequest data)
        {
            //Todo: Implement this method

            PostDetail comment = await _postService.insertComment(data);
            Users user = await _postService.getUserById(comment.createBy);

            var result = new postDto
            {
                NameUser = user.username,
                Comment = new PostDetail
                {
                    Id = comment.Id,
                    comment = data.comment,
                    createBy = (int)data.createBy,
                    createDate = DateTime.Now
                }
            };

            return Ok(result);
        }
    }
}

