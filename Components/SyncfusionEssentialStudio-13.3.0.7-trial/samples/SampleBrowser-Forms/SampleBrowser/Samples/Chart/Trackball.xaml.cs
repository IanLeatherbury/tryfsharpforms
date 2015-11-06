#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class Trackball
    {
        public Trackball()
        {
            InitializeComponent();
            labelDisplayMode.SelectedIndex = 0;
            labelDisplayMode.SelectedIndexChanged += labelDisplayMode_SelectedIndexChanged;
        }

        void labelDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(labelDisplayMode.SelectedIndex)
            {
                case 0:
                    chartTrackball.LabelDisplayMode = TrackballLabelDisplayMode.FloatAllPoints;
                    break;
                case 1:
                    chartTrackball.LabelDisplayMode = TrackballLabelDisplayMode.NearestPoint;
                    break;
            }
        }
    }
}
