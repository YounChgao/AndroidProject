/*using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyAndroidProject
{
	public partial class MainPage : ContentPage
	{
		public ObservableCollection<string> Linqs { get; set; } = new ObservableCollection<string>();

		public MainPage()
		{
			InitializeComponent();
			Load();
		}

		private void Load()
		{
			listView.ItemsSource = Linqs;
			entry.Text = string.Empty;
		}

		private void OnAddClicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(entry.Text))
				return;
			Linqs.Add(entry.Text);
			Load();
		}

		private void OpenLinq_Tapped(object sender, EventArgs e)
		{
			string url = listView.SelectedItem.ToString();
			var newPage = new WebViewPage(url);

			var tabbedPage = Application.Current.MainPage as TabbedPage;
			if (tabbedPage != null && tabbedPage.Children.Count > 0)
			{
				
				newPage.Title = TrimStartLinks(url, "https://www.google.com/");
				//tabbedPage.Children.RemoveAt(tabbedPage.Children.IndexOf(tabbedPage.CurrentPage));
				tabbedPage.Children.Insert(tabbedPage.Children.IndexOf(tabbedPage.CurrentPage), newPage);
				tabbedPage.CurrentPage = newPage;
			}
		}

		private string TrimStartLinks(string link, string prefix)
		{
			return link.Replace(prefix, string.Empty);
		}
	}
}*/

using MyAndroidProject.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyAndroidProject
{
	public partial class MainPage : ContentPage
	{
		public ObservableCollection<LinkItem> Linqs { get; set; } = new ObservableCollection<LinkItem>();
		public LinkItem SelectedLink { get; set; }

		public MainPage()
		{
			InitializeComponent();
			Load();
		}

		private void Load()
		{
			listView.ItemsSource = Linqs;
			entry.Text = string.Empty;
		}

		private void OnAddClicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(entry.Text))
				return;
			string url = entry.Text;
			Linqs.Add(new LinkItem() { Url = url, IsSelected = false });
			Load();
		}

		private void OpenLinq_Tapped(object sender, EventArgs e)
		{
			if (listView.SelectedItem is LinkItem selectedLink)
			{
				SelectedLink = selectedLink;

				// Устанавливаем свойство IsSelected для каждой ссылки в списке
				foreach (var link in Linqs)
				{
					link.IsSelected = link == SelectedLink;
				}

				string url = selectedLink.Url;
				var newPage = new WebViewPage(url);

				var tabbedPage = Application.Current.MainPage as TabbedPage;
				if (tabbedPage != null && tabbedPage.Children.Count > 0)
				{
					newPage.Title = TrimStartLinks(url, "https://www.google.com/");
					tabbedPage.Children.Insert(tabbedPage.Children.IndexOf(tabbedPage.CurrentPage), newPage);
					tabbedPage.CurrentPage = newPage;
				}
			}
		}

		private string TrimStartLinks(string link, string prefix)
		{
			return link.Replace(prefix, string.Empty);
		}
	}
}