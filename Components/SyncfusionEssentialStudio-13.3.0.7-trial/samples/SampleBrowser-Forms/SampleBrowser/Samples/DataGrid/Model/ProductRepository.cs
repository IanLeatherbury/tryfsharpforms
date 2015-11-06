#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class ProductRepository
	{
		public ProductRepository ()
		{
		}

		#region private variables

		private Random random = new Random ();

		#endregion

		#region GetOrderDetails

		public List<Product> GetProductDetails (int count)
		{
			List<Product> productDetails = new List<Product> ();

			for (int i = 1; i <= count; i++) {
				var ord = new Product () {
					SupplierID = i,
					ProductID = ProductID [random.Next (15)],
					ProductName = ProductNames [random.Next (15)],
					Quantity = random.Next (1, 20).ToString (),
					UnitPrice = random.Next (70, 200),
					UnitsInStock = random.Next (3, 12),
				};
				productDetails.Add (ord);
			}
			return productDetails;
		}

		#endregion

		#region MainGrid DataSource

		string[] ProductNames = new string[] {
			"Bag",
			"Syrup",
			"Crab Meat",
			"Camembert",
			"Carnarvon",
			"Chai",
			"Chang",
			"Chartreuse",
			"Cajun",
			"Gumb",
			"Chocolate",
			"Cote de",
			"lax",
			"Filo",
			"Geitost",
			"Flotemysost",
			"Ikura",
			"Longlife",
			"Maxilaku",
			"Mishi",
			"Ipoh",
			"Konbu",
			"Inlagd Sill",
			"Pavlova",
			"Cabrales"
		};

		int[] ProductID = new int[] {
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

		#endregion
	}
}

