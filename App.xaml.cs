using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace MyAndroidProject
{
	public partial class App : Application
	{
		private Stopwatch stopwatch;
		public static TabbedPage MainTabbedPage { get; private set; }

		public App()
		{
			InitializeComponent();
			stopwatch = new Stopwatch();

			var firstTab = new NavigationPage(new MainPage());
			firstTab.Title = "Главная";

			MainTabbedPage = new TabbedPage();
			MainTabbedPage.Children.Add(firstTab);

			MainPage = MainTabbedPage;
		}

		protected override void OnStart()
		{
			base.OnStart();
			stopwatch.Start();
			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{
				TimeSpan timeElapsed = stopwatch.Elapsed;
				MainPage.BindingContext = timeElapsed;
				return true;
			});
		}

		protected override void OnSleep()
		{

		}

		protected override void OnResume()
		{

		}
	}
}
