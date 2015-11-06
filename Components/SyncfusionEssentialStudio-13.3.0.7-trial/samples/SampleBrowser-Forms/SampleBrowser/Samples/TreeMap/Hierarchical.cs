#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Syncfusion.SfTreeMap.XForms;

namespace SampleBrowser
{
	public class Hierarchical : SamplePage
	{
		SfTreeMap tree;
		public Hierarchical ()
		{
			Title = "Hierarchical";
			tree = new SfTreeMap ();
			tree.WeightValuePath = "Sales";
			this.BackgroundColor = Device.OnPlatform(iOS: Color.White, Android: Color.White, WinPhone: Color.Black);
			DesaturationColorMapping desat = new DesaturationColorMapping ();
			desat.Color = Color.FromHex ("#41B8C4");
			desat.From = 1;
			desat.To = 0.2;
			tree.ColorValuePath = "Expense";
			tree.LeafItemColorMapping = desat;
			TreeMapHierarchicalLevel level = new TreeMapHierarchicalLevel() { ChildPadding=4, HeaderStyle = new Syncfusion.SfTreeMap.XForms.Style() { Color = Device.OnPlatform(iOS: Color.Gray, Android: Color.Gray, WinPhone: Color.White) }, ShowHeader = true, HeaderHeight = 20, HeaderPath = "Name", ChildPath = "RegionalSales" };
			level.ChildBackground = Device.OnPlatform(iOS: Color.White, Android: Color.White, WinPhone: Color.Black);
			tree.Levels.Add (level);
			tree.LeafItemSettings.LabelPath ="Name";
			tree.DataSource = new CountrySalesCollection ();
			//double labelHeight = Device.OnPlatform(iOS: 20, Android: 25, WinPhone: 35);

            this.ContentView = tree;
            this.ContentView.BackgroundColor = Color.White;

		}


	}

	public class CountrySalesCollection : ObservableCollection<CountrySale>
	{
		public CountrySalesCollection()
		{
			this.Add(new CountrySale() { Name = "United States", Sales = 98456, Expense = 87000 });
			this.Add(new CountrySale() { Name = "Canada", Sales = 43523, Expense = 40000 });
			this.Add(new CountrySale() { Name = "Mexico", Sales = 45634, Expense = 46000 });

			this[0].RegionalSales.Add(new RegionSale() { Country = "United States", Name = "New York", Sales = 2353, Expense = 2000 });
			this[0].RegionalSales.Add(new RegionSale() { Country = "United States", Name = "Los Angeles", Sales = 3453, Expense = 3000 });
			this[0].RegionalSales.Add(new RegionSale() { Country = "United States", Name = "San Francisco", Sales = 8456, Expense = 8000 });
			this[0].RegionalSales.Add(new RegionSale() { Country = "United States", Name = "Chicago", Sales = 6785, Expense = 7000 });
			this[0].RegionalSales.Add(new RegionSale() { Country = "United States", Name = "Miami", Sales = 7045, Expense = 6000 });


			this[1].RegionalSales.Add(new RegionSale() { Country = "Canada", Name = "Toronto", Sales = 7045, Expense = 7000 });
			this[1].RegionalSales.Add(new RegionSale() { Country = "Canada", Name = "Vancouver", Sales = 4352, Expense = 4000 });
			this[1].RegionalSales.Add(new RegionSale() { Country = "Canada", Name = "Winnipeg", Sales = 7843, Expense = 7500 });


			this[2].RegionalSales.Add(new RegionSale() { Country = "Mexico", Name = "Mexico City", Sales = 7843, Expense = 6500 });
			this[2].RegionalSales.Add(new RegionSale() { Country = "Mexico", Name = "Cancun", Sales = 6683, Expense = 6000 });
			this[2].RegionalSales.Add(new RegionSale() { Country = "Mexico", Name = "Acapulco", Sales = 2454, Expense = 2000 });
		}
	}

	public class CountrySale 
	{
		public string Name { get; set; }
		private double _sales = 0;
		public double Sales
		{
			get { return _sales; }
			set
			{
				if (_sales != value)
				{
					_sales = value;

				}
			}
		}

		private double _expense = 0;
		public double Expense
		{
			get { return _expense; }
			set
			{
				if (_expense != value)
				{
					_expense = value;

				}
			}
		}

		public ObservableCollection<RegionSale> RegionalSales { get; set; }

		public CountrySale()
		{
			this.RegionalSales = new ObservableCollection<RegionSale>();
		}


	}

	public class RegionSale 
	{
		public string Name { get; set; }

		public string Country { get; set; }

		private double _sales = 0;
		public double Sales
		{
			get { return _sales; }
			set
			{
				if (_sales != value)
				{
					_sales = value;

				}
			}
		}
		public double Expense { get; set; }


	}

}

