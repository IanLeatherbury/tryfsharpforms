#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleBrowser
{
	public class DealerRepository
	{

		#region private variables

		private Random random = new Random ();

		#endregion

        #region GetDealerDetails

        public ObservableCollection<DealerInfo> GetDealerDetails (int count)
		{
			ObservableCollection<DealerInfo> dealerDetails = new ObservableCollection<DealerInfo> (); 

			for (int i = 1; i <= count; i++) {
				var ord = new DealerInfo () {
					ProductID = i,
					ProductNo = ProductNo [random.Next (15)],
					DealerName = Customers [random.Next (15)],
					ProductPrice = random.Next(2000,10000),
					IsOnline = ((i % random.Next (1, 10) > 2) ? true : false),
                    DealerImage = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Image" + (i % 10) + ".png"),
				};
				dealerDetails.Add (ord);
			}

			return dealerDetails;
		}

		#endregion

		int[] ProductNo = new int[] {
			1803,
			1345,
			4523,
			4932,
			9475,
			5243,
			4263,
			2435,
			3527,
			3634,
			2523,
			3652,
			3524,
			6532,
			2123
		};

		string[] Customers = new string[] {
			"Adams",
			"Crowley",
			"Ellis",
			"Gable",
			"Irvine",
			"Keefe",
			"Mendoza",
			"Owens",
			"Rooney",
			"Waddell",
			"Thomas",
			"Betts",
			"Doran",
			"Fitzgerald",
			"Holmes",
			"Jefferson",
			"Landry",
			"Newberry",
			"Perez",
			"Spencer",
			"Vargas",
			"Grimes",
			"Edwards",
			"Stark",
			"Cruise",
			"Fitz",
			"Chief",
			"Blanc",
			"Perry",
			"Stone",
			"Williams",
			"Lane",
			"Jobs"
		};
	}
}

