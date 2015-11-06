#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using System.Globalization;
using Xamarin.Forms.Xaml;

namespace SampleBrowser
{
	internal class StyleConverterforQS2 : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double _value = (double)value;
				if (_value < 5000 && _value > 1000)
				return Color.FromRgb(0, 153, 0);
			return Color.Green;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	internal class StyleConverterforQS3 : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double _value = (double)value;
			if (_value < 5000 && _value > 1000)
					return Color.Yellow;
			return Color.White;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	internal class StyleConverterforQS4 : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double _value = (double)value;
			if (_value < 5000 && _value > 1000)
				return Color.Blue;
			return Color.Navy;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	internal class StyleConverterforQS1 : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double _value = (double)value;
			if (_value < 5000 && _value > 1000)
				return Color.Red;
			return Color.Black;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	[ContentProperty ("Source")]
	public class ImageResourceExtension : IMarkupExtension
	{
		public string Source { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;

			// Do your translation lookup here, using whatever method you require
			var imageSource = ImageSource.FromResource(Source);

			return imageSource;
		}
	}

	public class ImageConverter:IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			var data = value as double?;
			if (data != null && data > 0)
				return ImageSource.FromResource("SampleBrowser.Icons.DataGrid.GreenUp.png");
			else
				return ImageSource.FromResource("SampleBrowser.Icons.DataGrid.RedDown.png");
		}
		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
		
	}
}

