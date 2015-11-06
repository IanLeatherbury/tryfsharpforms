#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Graphics;
using Com.Syncfusion.Charts;
using Java.Util;
using System;

namespace SampleBrowser
{
    public class MainPage 
    {
        public static ObservableArrayList GetAreaData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 45));
            datas.Add(new ChartDataPoint("2011", 56));
            datas.Add(new ChartDataPoint("2012", 23));
            datas.Add(new ChartDataPoint("2013", 43));
            datas.Add(new ChartDataPoint("2014", Double.NaN));
            datas.Add(new ChartDataPoint("2015", 54));
            datas.Add(new ChartDataPoint("2016", 43));
            datas.Add(new ChartDataPoint("2017", 23));
            datas.Add(new ChartDataPoint("2018", 34));
            return datas;
        }

        public static ObservableArrayList GetStripLineData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("Jan", 33));
            datas.Add(new ChartDataPoint("Feb", 37));
            datas.Add(new ChartDataPoint("Mar", 39));
            datas.Add(new ChartDataPoint("Apr", 43));
            datas.Add(new ChartDataPoint("May", 45));
            datas.Add(new ChartDataPoint("Jun", 43));
            datas.Add(new ChartDataPoint("Jul", 41));
            datas.Add(new ChartDataPoint("Aug", 40));
            datas.Add(new ChartDataPoint("Sep", 39));
            datas.Add(new ChartDataPoint("Oct", 39));
            datas.Add(new ChartDataPoint("Nov", 34));
            datas.Add(new ChartDataPoint("Dec", 33));
            return datas;
        }

        public static ObservableArrayList GetData1()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 45));
            datas.Add(new ChartDataPoint("2011", 89));
            datas.Add(new ChartDataPoint("2012", 23));
            datas.Add(new ChartDataPoint("2013", 43));
            datas.Add(new ChartDataPoint("2014", 54));
            return datas;
        }

        public static ObservableArrayList GetLineData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 45.68));
            datas.Add(new ChartDataPoint("2011", 89.25));
            datas.Add(new ChartDataPoint("2012", 23.73));
            datas.Add(new ChartDataPoint("2013", 43.5));
            datas.Add(new ChartDataPoint("2014", 54.92));
            return datas;
        }

        public static ObservableArrayList GetCategoryData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("Bentley", 54));
            datas.Add(new ChartDataPoint("Audi", 24));
            datas.Add(new ChartDataPoint("BMW", 53));
            datas.Add(new ChartDataPoint("Jaguar", 63));
            datas.Add(new ChartDataPoint("Skoda", 35));
            return datas;
        }

        public static ObservableArrayList GetNumericalData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint(1, 54));
            datas.Add(new ChartDataPoint(2, 24));
            datas.Add(new ChartDataPoint(3, 53));
            datas.Add(new ChartDataPoint(4, 63));
            datas.Add(new ChartDataPoint(5, 35));
            return datas;
        }

        public static ObservableArrayList GetData2()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 54));
            datas.Add(new ChartDataPoint("2011", 24));
            datas.Add(new ChartDataPoint("2012", 53));
            datas.Add(new ChartDataPoint("2013", 63));
            datas.Add(new ChartDataPoint("2014", 35));
            return datas;
        }

        public static ObservableArrayList GetData3()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 14));
            datas.Add(new ChartDataPoint("2011", 54));
            datas.Add(new ChartDataPoint("2012", 23));
            datas.Add(new ChartDataPoint("2013", 53));
            datas.Add(new ChartDataPoint("2014", 25));
            return datas;
        }

        public static ObservableArrayList GetFinancialData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 873.8, 878.85, 855.5, 860.5));
            datas.Add(new ChartDataPoint("2011", 861, 868.4, 835.2, 843.45));
            datas.Add(new ChartDataPoint("2012", 846.15, 853, 838.5, 847.5));
            datas.Add(new ChartDataPoint("2013", 846, 860.75, 841, 855));
            datas.Add(new ChartDataPoint("2014", 841, 845, 827.85, 838.65));
            return datas;
        }

        public static ObservableArrayList GetSelectionData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("Jan", 42));
            datas.Add(new ChartDataPoint("Feb", 44));
            datas.Add(new ChartDataPoint("Mar", 53));
            datas.Add(new ChartDataPoint("Apr", 64));
            datas.Add(new ChartDataPoint("May", 75));
            datas.Add(new ChartDataPoint("Jun", 83));
            return datas;
        }

        public static ObservableArrayList GetDateTimValue()
        {
            Calendar calendar = new GregorianCalendar(2014, 1, 1);
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint(calendar.Time, 10d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 23d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 22d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 32d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 31d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 12d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 26d));

            return datas;
        }

        public static ObservableArrayList GetSeriesData1()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint(1, 54));
            datas.Add(new ChartDataPoint(2, 24));
            datas.Add(new ChartDataPoint(3, 53));
            datas.Add(new ChartDataPoint(4, 63));
            datas.Add(new ChartDataPoint(5, 35));
            return datas;
        }

        public static ObservableArrayList GetSeriesData2()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint(1, 34));
            datas.Add(new ChartDataPoint(2, 20));
            datas.Add(new ChartDataPoint(3, 43));
            datas.Add(new ChartDataPoint(4, 53));
            datas.Add(new ChartDataPoint(5, 25));
            return datas;
        }

        public static ObservableArrayList GetSeriesData3()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint(1, 24));
            datas.Add(new ChartDataPoint(2, 14));
            datas.Add(new ChartDataPoint(3, 33));
            datas.Add(new ChartDataPoint(4, 43));
            datas.Add(new ChartDataPoint(5, 15));
            return datas;
        }

        public static ObservableArrayList GetTriangularData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("Bentley", 800));
            datas.Add(new ChartDataPoint("Audi", 810));
            datas.Add(new ChartDataPoint("BMW", 825));
            datas.Add(new ChartDataPoint("Jaguar", 860));
            datas.Add(new ChartDataPoint("Skoda", 875));
            return datas;
        }

        static void AddDate(Calendar calendar)
        {
            calendar.Add(Java.Util.CalendarField.Date, 1);
        }

        public static Color ConvertHexaToColor(uint hex)
        {
            var alpha = (hex & 0xFF000000) >> 24;
            var red = (hex & 0xFF0000) >> 16;
            var green = (hex & 0xFF00) >> 8;
            var blue = (hex & 0xFF);
            return Color.Argb((int) alpha, (int) red, (int) green, (int) blue);
        }
    }

    public class Data
    {
        public static ObservableArrayList GetDateTimValue()
        {
            Calendar calendar = new GregorianCalendar(2014, 1, 1);
            var datas = new ObservableArrayList();
            
            datas.Add(new ChartDataPoint(calendar.Time, 10d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 23d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 22d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 32d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 31d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 12d));
            AddDate(calendar);
            datas.Add(new ChartDataPoint(calendar.Time, 26d));

            return datas;
        }

        static void AddDate(Calendar calendar)
        {
            calendar.Add(Java.Util.CalendarField.Date, 1);
        }

        public static ObservableArrayList GetAreaData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 45));
            datas.Add(new ChartDataPoint("2011", 56));
            datas.Add(new ChartDataPoint("2012", 23));
            datas.Add(new ChartDataPoint("2013", 43));
            datas.Add(new ChartDataPoint("2014", Double.NaN));
            datas.Add(new ChartDataPoint("2015", 54));
            datas.Add(new ChartDataPoint("2016", 43));
            datas.Add(new ChartDataPoint("2017", 23));
            datas.Add(new ChartDataPoint("2018", 34));
            return datas;
        }

        public static ObservableArrayList GetData1()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 45));
            datas.Add(new ChartDataPoint("2011", 86));
            datas.Add(new ChartDataPoint("2012", 23));
            datas.Add(new ChartDataPoint("2013", 43));
            datas.Add(new ChartDataPoint("2014", 54));
            return datas;
        }
        public static ObservableArrayList GetCategoryData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("Bentley", 54));
            datas.Add(new ChartDataPoint("Audi", 24));
            datas.Add(new ChartDataPoint("BMW", 53));
            datas.Add(new ChartDataPoint("Jaguar", 63));
            datas.Add(new ChartDataPoint("Skoda", 35));
            return datas;
        }

        public static ObservableArrayList GetNumericalData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint(1, 54));
            datas.Add(new ChartDataPoint(2, 24));
            datas.Add(new ChartDataPoint(3, 53));
            datas.Add(new ChartDataPoint(4, 63));
            datas.Add(new ChartDataPoint(5, 35));
            return datas;
        }

        public static ObservableArrayList GetData2()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 54));
            datas.Add(new ChartDataPoint("2011", 24));
            datas.Add(new ChartDataPoint("2012", 53));
            datas.Add(new ChartDataPoint("2013", 63));
            datas.Add(new ChartDataPoint("2014", 35));
            return datas;
        }

        public static ObservableArrayList GetData3()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 14));
            datas.Add(new ChartDataPoint("2011", 54));
            datas.Add(new ChartDataPoint("2012", 23));
            datas.Add(new ChartDataPoint("2013", 53));
            datas.Add(new ChartDataPoint("2014", 25));
            return datas;
        }

        public static ObservableArrayList GetFinancialData()
        {
            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 873.8, 878.85, 855.5, 860.5));
            datas.Add(new ChartDataPoint("2011", 861, 868.4, 835.2, 843.45));
            datas.Add(new ChartDataPoint("2012", 846.15, 853, 838.5, 847.5));
            datas.Add(new ChartDataPoint("2013", 846, 860.75, 841, 855));
            datas.Add(new ChartDataPoint("2014", 841, 845, 827.85, 838.65));
            return datas;
        }        
    }
}