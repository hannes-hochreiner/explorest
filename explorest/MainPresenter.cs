using System;
using System.Collections.Generic;

namespace explorest
{
	public class MainPresenter
	{
		private IWebRequestService _service;
		private IMainView _view;

		public MainPresenter(IWebRequestService service)
		{
			_service = service;
		}

        public void Initialize()
        {
            _view.RequestMethods = new List<string>
            {
              "GET",
              "POST",
              "HEAD",
              "PUT",
              "DELETE",
              "TRACE",
              "OPTIONS",
              "CONNECT",
              "PATCH"
            };
            _view.RequestMethod = "GET";
        }

        public void SendRequest()
        {
            try
            {
                var resp = _service.request(_view.RequestMethod, _view.RequestEndpoint);

                _view.ResponseStatusText = resp.StatusText;
                _view.ResponseText = resp.Text;
                _view.ResponseHeaders = resp.Headers;
            }
            catch(Exception ex)
            {
                _view.Message = ex.Message;
            }
        }

		public IMainView View {
			set {
				_view = value;
			}
		}
	}
}

