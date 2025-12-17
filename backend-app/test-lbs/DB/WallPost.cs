using System;
namespace test_lbs.DB
{
	public class WallPost
	{
		public int Id { get; set; }
        public string? postText { get; set; }
		public string? postUrlImg { get; set; }
		public DateTime createDate { get; set; }
		public int createBy { get; set; }
	}
}

