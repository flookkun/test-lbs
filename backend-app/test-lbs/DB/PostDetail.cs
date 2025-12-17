using System;
namespace test_lbs.DB
{
	public class PostDetail
	{
		public int Id { get; set; }
		public string? comment { get; set; }
		public DateTime? createDate { get; set; }
		public int createBy { get; set; }
	}
}

