#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfCircularGauge;
using System.Collections.ObjectModel;
using Android.Graphics;
using Com.Syncfusion.Gauges.SfCircularGauge.Enums;
using Android.Renderscripts;

namespace SampleBrowser
{
    public class CircularGauge: SamplePage
    {
        public static double pointerValue = 60;
        public static double ticksOffset = 0.04;
        public static double labelsOffset = 0.1;
        SfCircularGauge circularGauge;
        TickSetting majorTickstings;
        NeedlePointer needlePointer;
        RangePointer rangePointer;
        CircularScale circularScale;

        public override View GetSampleContent (Context con)
		{
            circularGauge = new SfCircularGauge(con);

            ObservableCollection<CircularScale> _circularScales = new ObservableCollection<CircularScale>();
            ObservableCollection<CircularPointer> _circularPointers = new ObservableCollection<CircularPointer>();
            ObservableCollection<Header> _gaugeHeaders = new ObservableCollection<Header>();
            // adding  new CircularScale
            circularScale = new CircularScale();
            circularScale.StartValue = 0;
            circularScale.EndValue = 100;
            circularScale.StartAngle = 130;
            circularScale.SweepAngle = 280;
            circularScale.RimWidth = 10;
            circularScale.RimColor = Color.ParseColor("#D14646");
            circularScale.MinorTicksPerInterval = 0;
            circularScale.LabelOffset = labelsOffset;
            circularScale.LabelTextSize = 18;

            //adding major ticks
            majorTickstings = new TickSetting();
            majorTickstings.Color = Color.ParseColor("#444444");
            majorTickstings.Size = 15;
            majorTickstings.Offset = ticksOffset;
            circularScale.MajorTickSettings = majorTickstings;

            //adding minor ticks
            TickSetting minorTickstings = new TickSetting();
            minorTickstings.Color = Color.Gray;
            circularScale.MinorTickSettings = minorTickstings;

            // adding needle Pointer
            needlePointer = new NeedlePointer();
            needlePointer.Value = pointerValue;
            needlePointer.KnobColor = Color.ParseColor("#2BBFB8");
            needlePointer.KnobRadius = 20;
            needlePointer.Type = NeedleType.Bar;
            needlePointer.LengthFactor = 0.8;
            needlePointer.Width = 3;
            needlePointer.Color = Color.Gray;
            _circularPointers.Add(needlePointer);

            // adding range Pointer
            rangePointer = new RangePointer();
            rangePointer.Value = pointerValue;
            rangePointer.Color = Color.ParseColor("#2BBFB8");
            rangePointer.Width = 10;
            _circularPointers.Add(rangePointer);

            circularScale.CircularPointers = _circularPointers;
            _circularScales.Add(circularScale);

            //adding header
            Header circularGaugeHeader = new Header();
            circularGaugeHeader.Text = "Speedometer";
            circularGaugeHeader.TextColor = Color.Gray;
            circularGaugeHeader.Position = new PointF((float)0.38, (float)0.7);
            circularGaugeHeader.TextSize = 20;
            _gaugeHeaders.Add(circularGaugeHeader);
            circularGauge.Headers = _gaugeHeaders;
            circularGauge.CircularScales = _circularScales;
            circularGauge.SetBackgroundColor(Color.White);

            LinearLayout linearLayout = new LinearLayout(con);
            linearLayout.AddView(circularGauge);
            linearLayout.SetPadding(30, 30, 30, 30);
            linearLayout.SetBackgroundColor(Color.White);
            return linearLayout;
		}

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            TextView pointervalue = new TextView(context);
            pointervalue.Text = "Pointer Value";
            pointervalue.Typeface = Typeface.DefaultBold;
            pointervalue.SetTextColor(Color.ParseColor("#262626"));
            pointervalue.TextSize = 20;

            SeekBar pointerSeek = new SeekBar(context);
            pointerSeek.Max = 100;
            pointerSeek.Progress = 60;
            pointerSeek.ProgressChanged += pointerSeek_ProgressChanged;

            TextView tickOffsetvalue = new TextView(context);
            tickOffsetvalue.Text = "Ticks Offset";
            tickOffsetvalue.Typeface = Typeface.DefaultBold;
            tickOffsetvalue.SetTextColor(Color.ParseColor("#262626"));
            tickOffsetvalue.TextSize = 20;

            SeekBar ticksSeek = new SeekBar(context);
            ticksSeek.Max = 10;
            ticksSeek.ProgressChanged += ticksSeek_ProgressChanged;

            TextView labelOffsetvalue = new TextView(context);
            labelOffsetvalue.Text = "Label Offset";
            labelOffsetvalue.Typeface = Typeface.DefaultBold;
            labelOffsetvalue.SetTextColor(Color.ParseColor("#262626"));
            labelOffsetvalue.TextSize = 20;

            SeekBar labelSeek = new SeekBar(context);
            labelSeek.Max = 10;
            labelSeek.ProgressChanged += labelSeek_ProgressChanged;

            LinearLayout optionsPage = new LinearLayout(context);

            optionsPage.Orientation = Orientation.Vertical;
            optionsPage.AddView(pointervalue); 
            optionsPage.AddView(pointerSeek);
            optionsPage.AddView(tickOffsetvalue);
            optionsPage.AddView(ticksSeek);
            optionsPage.AddView(labelOffsetvalue);
            optionsPage.AddView(labelSeek);
            
            optionsPage.SetPadding(10,10,10,10);
            optionsPage.SetBackgroundColor(Color.White);
            return optionsPage;
        }

        void labelSeek_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            circularScale.LabelOffset = ((double)e.Progress / 10);
        }

        void ticksSeek_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            majorTickstings.Offset = ((double)e.Progress / 10);
        }

        void pointerSeek_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            needlePointer.Value = e.Progress;
            rangePointer.Value = e.Progress;
        }

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
        }

	}
}
