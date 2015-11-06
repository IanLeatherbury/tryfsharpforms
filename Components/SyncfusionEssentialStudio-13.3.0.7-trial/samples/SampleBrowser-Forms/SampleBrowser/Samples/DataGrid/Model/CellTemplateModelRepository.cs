#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser
{
	public class CellTemplateModelRepository
	{
		public CellTemplateModelRepository ()
		{
		}

		public List<CellTemplateModel> GetEmployeeDetails()
		{
			List<CellTemplateModel> employeeDetails = new List<CellTemplateModel> ();

			employeeDetails.Add(new CellTemplateModel(){ 
				Name ="Nancy" , 
				Designation = "Sales Representative",
				DateOfBirth = new DateTime(1948,8,12),
				About= "Education includes a BA in psychology from Colorado State University in 1970.  She also completed The Art of the Cold Call. Nancy is a member of Toastmasters International.",
				Country="USA",
				EmployeeID=4563,
				Telephone ="(206) 555 -9857",
				Image = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Davolio.png"),
				});

			employeeDetails.Add(new CellTemplateModel(){ 
				Name ="Andrew" , 
				Designation = "Vice President",
				DateOfBirth = new DateTime(1952,2,19),
				About= "Andrew received his BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.He joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.",
				Country="USA",
				EmployeeID=4362,
				Telephone ="(206) 555 -9482",
				Image = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Fuller.png"),
			});

			employeeDetails.Add(new CellTemplateModel(){ 
				Name ="Janet" , 
				Designation = "Sales Representative",
				DateOfBirth = new DateTime(1963,8,30),
				Country="USA",
				EmployeeID=4134,
				About= "Janet has a BS degree in chemistry from Boston College (1984).  She has also completed a certificate program in food retailing management.  Janet was hired as a sales associate in 1991 and promoted to sales representative in February 1992.",
				Telephone ="(206) 555 -9356",
				Image = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Leverling.png"),
			});
			employeeDetails.Add(new CellTemplateModel(){ 
				Name ="Margaret" , 
				Designation = "Sales Representative",
				DateOfBirth = new DateTime(1937,9,19),
				Country="UK",
				EmployeeID=4834,
				About="Margaret holds a BA in English literature from Concordia College (1958) and an MA from the American Institute of Culinary Arts (1966).  She was assigned to the London office temporarily from July through November 1992.",
				Telephone ="(71) 555 -4766",
				Image = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Peacock.png"),
			});
			employeeDetails.Add(new CellTemplateModel(){ 
				Name ="Steven" , 
				Designation = "Sales Manager",
				DateOfBirth = new DateTime(1955,4,3),
				Country="UK",
				EmployeeID=4267,
				About="Steven Buchanan graduated from St. Andrews University, Scotland, with a BSC degree in 1976.  Upon joining the company as a sales representative in 1992, he spent 6 months in an orientation program at the Seattle office and then returned to his permanent post in London.",
				Telephone ="(71) 555 -4567",
				Image = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Buchanan.png"),
			});
			employeeDetails.Add(new CellTemplateModel(){ 
				Name ="Michale" , 
				Designation = "Sales Representative",
				DateOfBirth = new DateTime(1963,7,2),
				Country="London",
				EmployeeID=4553,
				About="Michael is a graduate of Sussex University (MA, economics, 1983) and the University of California at Los Angeles (MBA, marketing, 1986).  He has also taken the courses  Multi-Cultural Selling and Time Management for the Sales Professional.",
				Telephone ="(71) 555 -7777",
				Image = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Suyama.png"),
			});
			employeeDetails.Add(new CellTemplateModel(){ 
				Name ="Robert" , 
				Designation = "Sales Representative",
				DateOfBirth = new DateTime(1960,5,27),
				Country="London",
				EmployeeID=4423,
				About="Robert King served in the Peace Corps and traveled extensively before completing his degree in English at the University of Michigan in 1992, the year he joined the company.  After completing a course entitled Selling in Europe, he was transferred to the London office in March 1993.",
			    Telephone ="(71) 555 -7856",
				Image = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.King.png"),
			});

			employeeDetails.Add(new CellTemplateModel(){ 
				Name ="Laura" , 
				Designation = "Inside Sales Cordinator",
				DateOfBirth = new DateTime(1958,9,1),
				Country="Seattle",
				EmployeeID=4265,
				About="Laura received a BA in psychology from the University of Washington.  She has also completed a course in business French.  She reads and writes French.",
				Telephone ="(71) 555 -1189",
				Image = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Callahan.png"),
			});

			employeeDetails.Add(new CellTemplateModel(){ 
				Name ="Anne" , 
				Designation = "Sales Representative",
				DateOfBirth = new DateTime(1966,1,27),
				Country="London",
				EmployeeID=3563,
				About="Anne has a BA degree in English from St. Lawrence College.  She is fluent in French and German.She has also completed a course in business French.  She reads and writes French.",
				Telephone ="(71) 555 -7856",
				Image = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Dodsworth.png"),
			});

			return employeeDetails;
	}
}
}
