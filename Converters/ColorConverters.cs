using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyAndroidProject.Converters
{
	public class ColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool isSelected && isSelected)
				return Color.Green;

			return Color.Black;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}