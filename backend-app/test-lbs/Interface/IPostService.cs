using System;
using test_lbs.DB;
using test_lbs.dto;

namespace test_lbs.Interface
{
    public interface IPostService
    {
        Task<List<postDto>> getComment();
        Task<Users> getUserById(int createBy);
        Task<PostDetail> insertComment(postRequest data);
    }
}

