using System;
using Newtonsoft.Json;

namespace NZ_Walks.Models.Dto
{
	public class Error
	{
		public int StatusCode { get; set; }
		public string Message { get; set; }
		public string Path { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}

