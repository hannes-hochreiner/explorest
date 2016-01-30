using System;
using System.Windows.Forms;

namespace explorest
{
	class MainClass : Form
	{
		public static void Main (string[] args)
		{
            var win = new MainWindowForms(new MainPresenter(new WebRequestService()));
            Application.Run(win);
		}
	}
}
