using System;
using System.Net;
using System.Collections.Generic;
using System.IO;

namespace explorest
{
	public class WebRequestService : IWebRequestService
	{
		public WebResponse request(string method, string url) {
			WebRequest request = WebRequest.Create(url);
			request.Method = method;

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var respHeaders = new Dictionary<string, string>();

            foreach (var key in response.Headers.AllKeys)
            {
                respHeaders.Add(key, response.Headers[key]);
            }

			return new WebResponse() {
				StatusText = response.StatusDescription,
                Text = (new StreamReader(response.GetResponseStream())).ReadToEnd(),
                Headers = respHeaders
			};
		}
	}
}
