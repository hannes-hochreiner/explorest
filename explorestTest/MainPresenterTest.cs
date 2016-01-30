using NUnit.Framework;
using System;
using explorest;
using System.Collections.Generic;

namespace explorestTest
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void Initialize()
        {
            var wrsf = new WebRequestServiceFake();
            var pres = new MainPresenter(wrsf);
            var mvf = new MainViewFake();

            pres.View = mvf;
            pres.Initialize();

            Assert.AreEqual(9, mvf.RequestMethods.Count);
            Assert.AreEqual("GET", mvf.RequestMethod);
        }

        [Test()]
        public void SendRequest()
        {
            var wrsf = new WebRequestServiceFake();
            var pres = new MainPresenter(wrsf);
            var mvf = new MainViewFake();

            pres.View = mvf;
            pres.Initialize();

            mvf.RequestMethod = "OPTIONS";
            mvf.RequestEndpoint = "127.0.0.1";
            wrsf.Response = new WebResponse
            {
                StatusText = "OK",
                Text = "<html></html>",
                Headers = new Dictionary<string, string>
                {
                        { "x-response", "response-content" }
                }
            };

            pres.SendRequest();

            Assert.AreEqual(mvf.RequestMethod, wrsf.Method);
            Assert.AreEqual(mvf.RequestEndpoint, wrsf.Url);
            Assert.AreEqual(wrsf.Response.StatusText, mvf.ResponseStatusText);
            Assert.AreEqual(wrsf.Response.Text, mvf.ResponseText);
            Assert.AreEqual(wrsf.Response.Headers, mvf.ResponseHeaders);
            Assert.IsTrue(string.IsNullOrEmpty(mvf.Message));
        }
    }
}
