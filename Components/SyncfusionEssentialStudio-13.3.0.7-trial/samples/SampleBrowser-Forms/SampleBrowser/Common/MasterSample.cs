#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class MasterSample
    {
		public string ImageID { get; set; }

		public string Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ObservableCollection<SampleDetails> Samples { get; set; }

		public List<string> SamplesName { get; set; }

        public MasterSample()
        {
			Samples = new ObservableCollection<SampleDetails>();
			SamplesName = new List<string> ();

			Samples.CollectionChanged+= (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				SamplesName.Add((e.NewItems[0] as SampleDetails).Title);
			};
        }
    }
}