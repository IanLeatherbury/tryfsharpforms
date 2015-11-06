#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfGauge.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class CircularGauge : SamplePage
    {
        SfCircularGauge circularGauge;
        Scale scale;
        NeedlePointer needlePointer;
        RangePointer rangePointer;
        TickSettings major;

        public CircularGauge()
        {
            InitializeComponent();
            StackLayout _layout = new StackLayout();
            _layout.Orientation = StackOrientation.Vertical;
            _layout.SizeChanged += _layout_SizeChanged;    
            _layout.VerticalOptions = LayoutOptions.FillAndExpand;
            _layout.Children.Add(getCircularGauge());
            this.ContentView = _layout;
            this.ContentView.BackgroundColor = Color.White;
            PropertyLayout();
        }

        void _layout_SizeChanged(object sender, EventArgs e)
        {
            circularGauge.WidthRequest = 330;
            circularGauge.HeightRequest = 330;
        }

        SfCircularGauge getCircularGauge()
        {
            if (this.ContentView == null)
            {
                circularGauge = new SfCircularGauge();
                ObservableCollection<Scale> scales = new ObservableCollection<Scale>();
                circularGauge.VerticalOptions = LayoutOptions.CenterAndExpand;
                //Scales
                scale = new Scale();
                scale.StartValue = 0;
                scale.EndValue = 100;
                scale.Interval = 10;
                scale.StartAngle = 135;
                scale.SweepAngle = 270;
                scale.RimThickness = 20;
                scale.RimColor = Color.FromHex("#d14646");
                scale.LabelColor = Color.Gray;
                scale.LabelOffset = 0.1;
                scale.MinorTicksPerInterval = 0;
                List<Pointer> pointers = new List<Pointer>();

                needlePointer = new NeedlePointer();
                needlePointer.Value = 60;
                needlePointer.Color = Color.Gray;
                needlePointer.KnobRadius = 20;
                needlePointer.KnobColor = Color.FromHex("#2bbfb8");
                needlePointer.Thickness = 5;
                needlePointer.LengthFactor = 0.8;
                needlePointer.Type = PointerType.Bar;

                rangePointer = new RangePointer();
                rangePointer.Value = 60;
                rangePointer.Color = Color.FromHex("#2bbfb8");
                rangePointer.Thickness = 20;
                pointers.Add(needlePointer);
                pointers.Add(rangePointer);

                TickSettings minor = new TickSettings();
                minor.Length = 4;
                minor.Color = Color.FromHex("#444444");
                minor.Thickness = 3;
                scale.MinorTickSettings = minor;

                major = new TickSettings();
                major.Length = 12;
                major.Color = Color.FromHex("#444444");
                major.Thickness = 3;
                major.Offset = Device.OnPlatform(0.05, 0.1,0.3);
                scale.MajorTickSettings = major;
                scale.Pointers = pointers;
                scales.Add(scale);
                circularGauge.Scales = scales;

                Header header = new Header();
                header.Text = "Speedmeter";
                header.TextSize = 20;
                header.Position = Device.OnPlatform(iOS: new Point(.3, .7), Android: new Point(0.38, 0.7), WinPhone: new Point(0.38, 0.7));
                header.ForegroundColor = Color.Gray;
                circularGauge.Headers.Add(header);
            }
            return circularGauge;
        }

        void PropertyLayout()
        {

            StackLayout stack = new StackLayout();
            stack.BackgroundColor = Color.White;
            stack.Padding = 10;
            Label pointer = new Label();
            pointer.Text = "Pointer Value";
            if (Device.OS == TargetPlatform.iOS)
            {
                pointer.FontSize = 15;
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                pointer.FontSize = 15;
            }
            else
            {
                pointer.FontSize = 20;
            }

            pointer.TextColor = Color.Black;
            pointer.FontAttributes = FontAttributes.Bold;

            Xamarin.Forms.Slider pointerSlider = new Xamarin.Forms.Slider();
            pointerSlider.Maximum = 100;
            if (Device.OS == TargetPlatform.WinPhone)
            {
                pointerSlider.BackgroundColor = Color.Gray;
            }
            pointerSlider.Value = 60;
            pointerSlider.ValueChanged += pointerSlider_ValueChanged;
            stack.Children.Add(pointer);
            stack.Children.Add(pointerSlider);
            this.PropertyView = stack;
        }

        void tickSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            major.Offset = ((double)e.NewValue);
        }

        void labelSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            scale.LabelOffset = ((double)e.NewValue);
        }

        void pointerSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            needlePointer.Value = e.NewValue;
            rangePointer.Value = e.NewValue;
        }
    }
}