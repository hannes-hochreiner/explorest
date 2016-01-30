using System;
using System.Collections.Generic;

namespace explorest
{
	public interface IWebRequestService
	{
		WebResponse request(string method, string url);
	}

	public class WebResponse
	{
		public string StatusText { get; set; }
		public string Text { get; set; }
		public IDictionary<string, string> Headers { get; set; }
	}
}
