#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser
{
	class AutoRowHeightViewModel : INotifyPropertyChanged, IDisposable
	{

		public AutoRowHeightViewModel ()
		{
			employeeInformation = new EmployeeInformationRepository ().GetEmployeeDetails (50);
		}

		private ObservableCollection<EmployeeInformation> employeeInformation;

		public ObservableCollection<EmployeeInformation> EmployeeInformation {
			get { return employeeInformation; }
			set {
				employeeInformation = value;
				OnPropertyChanged ("EmployeeInformation");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged (string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				var e = new PropertyChangedEventArgs (propertyName);
				handler (this, e);
			}
		}

		public void Dispose ()
		{
			EmployeeInformation.Clear ();
		}
	}
}
