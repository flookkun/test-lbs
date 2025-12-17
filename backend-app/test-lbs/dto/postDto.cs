using System;
using test_lbs.DB;

namespace test_lbs.dto
{
	public class postDto
	{
		public PostDetail? Comment { get; set; }
		public string? NameUser { get; set; }
	}

	public class postRequest
	{
		public string? comment { get; set; }
		public int? createBy { get; set; }
	}
}

