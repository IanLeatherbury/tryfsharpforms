using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;

namespace tryfsharpforms
{
	public partial class ChartPage : ContentPage
	{
		public ChartPage (IEnumerable<Tuple<DateTime, decimal>> priceList1, IEnumerable<Tuple<DateTime, decimal>> priceList2)
		{
			InitializeComponent ();

			var svm = new StocksViewModel (priceList1, priceList2);
			BindingContext = svm;

//			SfChart chart = new SfChart ();
//			chart.Title = new ChartTitle { Text = "Compare Stocks" };
//
//			//Initializing Primary Axis
//			DateTimeAxis primaryAxis = new DateTimeAxis();
//			primaryAxis.Title = new ChartAxisTitle() { Text = "Month" };
//			chart.PrimaryAxis = primaryAxis;
//
//			//Initializing Secondary Axis
//			NumericalAxis secondaryAxis = new NumericalAxis();
//			secondaryAxis.Title = new ChartAxisTitle() { Text = "Price" };
//			chart.SecondaryAxis = secondaryAxis;
//
//			DataModel data = new DataModel ();
//
//			chart.Series.Add (
//				new ColumnSeries()
//				{
//					ItemsSource = data.TestData,
//					Label = "Precipitation",
//					YAxis = new NumericalAxis()
//					{
//						OpposedPosition = true,
//						ShowMajorGridLines = false
//					}
//				});
//
//			//Adding Chart Legend for the Chart
//			chart.Legend = new ChartLegend() { IsVisible = true };
//
//			this.Content = chart;
//		}
//
//		public class DataModel
//		{
//			public ObservableCollection<DataPoints> TestData;
//
//			public DataModel ()
//			{
//				TestData = new ObservableCollection<DataPoints> ();
//
//				TestData.Add (new DataPoints (40, new DateTime (2019, 1, 1)));
//				TestData.Add (new DataPoints (41, new DateTime (2018, 1, 1)));
//				TestData.Add (new DataPoints (42, new DateTime (2017, 1, 1)));
//				TestData.Add (new DataPoints (43, new DateTime (2016, 1, 1)));
//				TestData.Add (new DataPoints (44, new DateTime (2015, 1, 1)));
//				TestData.Add (new DataPoints (45, new DateTime (2014, 1, 1)));
//				TestData.Add (new DataPoints (46, new DateTime (2013, 1, 1)));
//				TestData.Add (new DataPoints (47, new DateTime (2012, 1, 1)));
//				TestData.Add (new DataPoints (48, new DateTime (2011, 1, 1)));
//				TestData.Add (new DataPoints (49, new DateTime (2010, 1, 1)));
//			}
//
		}
	}
}
