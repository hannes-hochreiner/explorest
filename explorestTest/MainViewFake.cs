using System;
using explorest;
using System.Collections.Generic;

namespace explorestTest
{
    public class MainViewFake : IMainView
    {
        public string RequestEndpoint { set; get; }
        public IList<string> RequestMethods { set; get; }
        public string RequestMethod { set; get; }
        public IDictionary<string, string> ResponseHeaders { set; get; }
        public string ResponseStatusText { set; get; }
        public string ResponseText { set; get; }
        public string Message { set; get; }
    }
}

