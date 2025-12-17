using System;
using test_lbs.DB;
using test_lbs.dto;
using test_lbs.Interface;

namespace test_lbs.Services
{
	public class PostService : IPostService
    {
		private readonly IRepository<PostDetail> _postDetailRepository;
        private readonly IRepository<Users> _userRepository;

        public PostService(
            IRepository<PostDetail> postDetailRepository,
            IRepository<Users> userRepository)
		{
            _postDetailRepository = postDetailRepository;
            _userRepository = userRepository;
        }

        public async Task<List<postDto>> getComment()
        {
            var postDetailsQuery = await _postDetailRepository.GetAllAsQueryable();
            var userQuery = await _userRepository.GetAllAsQueryable();

            //var postDetail = postDetailsQuery.ToList();

            var query = from post in postDetailsQuery
                        join user in userQuery on post.createBy equals user.Id into userGroup
                        from u in userGroup.DefaultIfEmpty()
                        select new postDto
                        {
                            Comment = post,
                            NameUser = u != null ? u.username : "Unknown User"
                        };

            var result = query.ToList();


            return result;

        }

        public async Task<Users> getUserById(int createBy)
        {
            var userQuery = await _userRepository.GetAllAsQueryable();


            var result = userQuery.Where(x => x.Id == createBy).FirstOrDefault();


            return result;

        }

        public async Task<PostDetail> insertComment(postRequest data)
        {
            var newPost = new PostDetail
            {
                comment = data.comment,
                createBy = (int)data.createBy,
                createDate = DateTime.Now
            };

            await _postDetailRepository.AddAsync(newPost);

            await _postDetailRepository.SaveChangesAsync();

            return newPost;

        }
    }
}

