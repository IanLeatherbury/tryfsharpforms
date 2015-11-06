#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace SampleBrowser
{
	public class AgricultureData
	{
		public AgricultureData(string name,string type,double count)
		{
			Name = name;
			Type = type;
			Count = count;
		}

		public string Name {
			get;
			set;
		}

		public string Type {
			get;
			set;
		}

		public double Count {
			get;
			set;
		}
	}
}

