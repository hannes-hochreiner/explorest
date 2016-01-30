using System;
using explorest;
using System.Collections.Generic;

namespace explorestTest
{
    public class WebRequestServiceFake : IWebRequestService
    {
        public string Method { private set; get; }
        public string Url { private set; get; }
        public WebResponse Response { set; get; }

        public WebResponse request(string method, string url)
        {
            Method = method;
            Url = url;

            return Response;
        }
    }
}

