using System;
using System.Collections.Generic;

namespace explorest
{
	public interface IMainView
	{
		string RequestEndpoint { get; }
		IList<string> RequestMethods { set; }
        string RequestMethod { get; set; }
		IDictionary<string, string> ResponseHeaders { set; }
		string ResponseStatusText { set; }
		string ResponseText { set; }
        string Message { set; }
	}
}
