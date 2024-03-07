using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyAndroidProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebViewPage : ContentPage
	{
		public WebViewPage(string url)
		{
			InitializeComponent();
			Load();
			OpenLinq(url);
		}

		private void Load()
		{

		}

		private async void OpenLinq(string url)
		{
			string[] options = { "Браузер", "Приложение" };
			string action = await DisplayActionSheet("Открыть ссылку", "Отмена", null, options);

			if (action == "Браузер")
				Device.OpenUri(new Uri(url));
			else if (action == "Приложение")
				webView.Source = new UrlWebViewSource { Url = url };
		}
	}
}