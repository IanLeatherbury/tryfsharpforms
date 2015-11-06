#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public class ViewModel
    {
        DateTime time = DateTime.Now;

        Random random = new Random();

        private int count;

        private int wave1;

        private int wave2 = 180;

        public ObservableCollection<Model> AreaData { get; set; }

        public ObservableCollection<Model> LineData { get; set; }

        public ObservableCollection<Model> LineData1 { get; set; }

        public ObservableCollection<Model> CircularData { get; set; }

        public ObservableCollection<Model> SemiCircularData { get; set; }

        public ObservableCollection<Model> BubbleData { get; set; }

        public ObservableCollection<Model> ScatterData { get; set; }

        public ObservableCollection<Model> Data1 { get; set; }
                                    
        public ObservableCollection<Model> Data2 { get; set; }

        public ObservableCollection<Model> datas1 { get; set; }
                                    
        public ObservableCollection<Model> Data3 { get; set; }

        public ObservableCollection<Model> CategoryData { get; set; }

        public ObservableCollection<RangeSeriesBaseModel> RangeColumnData { get; set; }

        public ObservableCollection<Model> FinancialData { get; set; }

        public ObservableCollection<Model> NumericData { get; set; }

        public ObservableCollection<Model> DateTimeData { get; set; }

        public ObservableCollection<Model> SelectionData { get; set; }

        public ObservableCollection<Model> data { get; set; }

        public ObservableCollection<Model> liveData1 { get; set; }

        public ObservableCollection<Model> liveData2 { get; set; }

        public ObservableCollection<Model> PieData { get; set; }

        public ObservableCollection<Model> StripLineData { get; set; }

        public ObservableCollection<Model> MultipleSeriesData1 { get; set; }

        public ObservableCollection<Model> MultipleSeriesData2 { get; set; }

        public ObservableCollection<Model> LineSeries1 { get; set; }
                                           
        public ObservableCollection<Model> LineSeries2 { get; set; }

        public ObservableCollection<Model> LineSeries3 { get; set; }

        public ObservableCollection<Model> TriangularData { get; set; }

        public ViewModel()
        {
            AreaData = new ObservableCollection<Model>
            {
                new Model("2010", 45),
                new Model("2011", 56),
                new Model("2012", 23),
                new Model("2013", 43),
                new Model("2014", Double.NaN),
                new Model("2015", 54),
                new Model("2016", 43),
                new Model("2017", 23),
                new Model("2018", 34)
            };

            StripLineData = new ObservableCollection<Model>
            {
                 new Model("Jan", 33),
                 new Model("Feb", 37),
                 new Model("Mar", 39),
                 new Model("Apr", 43),
                 new Model("May", 45),
                 new Model("Jun", 43),
                 new Model("Jul", 41),
                 new Model("Aug", 40),
                 new Model("Sep", 39),
                 new Model("Oct", 39),
                 new Model("Nov", 34),
                 new Model("Dec", 33)
            };

            LineData = new ObservableCollection<Model>
            {
                new Model("2010", 45),
                new Model("2011", 89),
                new Model("2012", 23),
                new Model("2013", 43),
                new Model("2014", 54)
            };

            LineData1 = new ObservableCollection<Model>
            {
                new Model("2010", 45.68),
                new Model("2011", 89.25),
                new Model("2012", 23.73),
                new Model("2013", 43.5),
                new Model("2014", 54.92)
            };

            CircularData = new ObservableCollection<Model>
            {
                new Model("2010", 8000),
                new Model("2011", 8100),
                new Model("2012", 8250),
                new Model("2013", 8600),
                new Model("2014", 8700)
            };

            SemiCircularData = new ObservableCollection<Model>
            {
                new Model("Product A", 14),
                new Model("Product B", 54),
                new Model("Product C", 23),
                new Model("Product D", 53),
            };

            BubbleData = new ObservableCollection<Model>
            {
                new Model("2010", 45, 30),
                new Model("2011", 86, 20),
                new Model("2012", 23, 15),
                new Model("2013", 43, 25),
                new Model("2014", 54, 20)
            };

            ScatterData = new ObservableCollection<Model>
            {
                new Model("2005", 54),
                new Model("2006", 34),
                new Model("2007", 53),
                new Model("2008", 64),
                new Model("2009", 35),
                new Model("2010", 27),
                new Model("2011", 13),
                new Model("2012", 40),
                new Model("2013", 25)
            };

            RangeColumnData = new ObservableCollection<RangeSeriesBaseModel>
            {
                new RangeSeriesBaseModel("Jan", 35, 17),
                new RangeSeriesBaseModel("Feb", 42, -11),
                new RangeSeriesBaseModel("Mar", 25, 5),
                new RangeSeriesBaseModel("Apr", 32, 10),
                new RangeSeriesBaseModel("May", 20, 3),
                new RangeSeriesBaseModel("Jun", 41, 30)              
            };

            FinancialData = new ObservableCollection<Model>
            {
                new Model("2010", 873.8, 878.85, 855.5, 860.5),
                new Model("2011", 861, 868.4, 835.2, 843.45),
                new Model("2012", 846.15, 853, 838.5, 847.5),
                new Model("2013", 846, 860.75, 841, 855),
                new Model("2014", 841, 845, 827.85, 838.65)
            };

            Data1 = new ObservableCollection<Model>
            {
                new Model("2010", 45),
                new Model("2011", 89),
                new Model("2012", 23),
                new Model("2013", 43),
                new Model("2014", 54)
            };

            Data2 = new ObservableCollection<Model>
            {
                new Model("2010", 54),
                new Model("2011", 24),
                new Model("2012", 53),
                new Model("2013", 63),
                new Model("2014", 35)
            };

            Data3 = new ObservableCollection<Model>
            {
                new Model("2010", 14),
                new Model("2011", 54),
                new Model("2012", 23),
                new Model("2013", 53),
                new Model("2014", 25)
            };

            CategoryData = new ObservableCollection<Model>
            {
                new Model("Bentley", 54),
                new Model("Audi", 24),
                new Model("BMW", 53),
                new Model("Jaguar", 63),
                new Model("Skoda", 35)
            };
            
            NumericData = new ObservableCollection<Model>
            {
                new Model(1, 54),
                new Model(2, 24),
                new Model(3, 53),
                new Model(4, 63),
                new Model(5, 35)
            };

            DateTimeData = new ObservableCollection<Model>
            {
                new Model(new DateTime(2012, 01, 1), 14),
                new Model(new DateTime(2012, 01, 2), 54),
                new Model(new DateTime(2012, 01, 3), 23),
                new Model(new DateTime(2012, 01, 4), 53),
                new Model(new DateTime(2012, 01, 5), 25)
            };

            datas1 = new ObservableCollection<Model>
            {
                new Model("2010", 6),
                new Model("2011", 15),
                new Model("2012", 35),
                new Model("2013", 65),
                new Model("2014", 75)
            };

            SelectionData = new ObservableCollection<Model>
            {
                new Model("Jan", 42),
                new Model("Feb", 44),
                new Model("Mar", 53),
                new Model("Apr", 64),
                new Model("May", 75),
                new Model("Jun", 83)
            };

            MultipleSeriesData1 = new ObservableCollection<Model>();

            for (var i = 1; i <= 12; i++)
            {
                MultipleSeriesData1.Add(new Model(new DateTime(2014, i, 1), random.Next(10, 100)));
            }

            MultipleSeriesData2 = new ObservableCollection<Model>();

            for (var i = 1; i <= 12; i++)
            {
                MultipleSeriesData2.Add(new Model(new DateTime(2014, i, 1), random.Next(10, 100)));
            }

            PieData = new ObservableCollection<Model>
            {
                new Model(new DateTime(2014, 1, 1), 48),
                new Model(new DateTime(2014, 2, 1), 38),
                new Model(new DateTime(2014, 3, 1), 28),
                new Model(new DateTime(2014, 4, 1), 33),
                new Model(new DateTime(2014, 5, 1), 25),
                new Model(new DateTime(2014, 6, 1), 34)
            };

            TriangularData = new ObservableCollection<Model>
            {
                new Model("Bentley", 800),
                new Model("Audi", 810),
                new Model("BMW", 825),
                new Model("Jaguar", 860),
                new Model("Skoda", 875)
            };

            data = new ObservableCollection<Model>();

            liveData1 = new ObservableCollection<Model>();

            liveData2 = new ObservableCollection<Model>();

            LineSeries1 = new ObservableCollection<Model>();
            LineSeries1.Add(new Model(1, 54));
            LineSeries1.Add(new Model(2, 24));
            LineSeries1.Add(new Model(3, 53));
            LineSeries1.Add(new Model(4, 63));
            LineSeries1.Add(new Model(5, 35));

            LineSeries2 = new ObservableCollection<Model>();
            LineSeries2.Add(new Model(1, 34));
            LineSeries2.Add(new Model(2, 20));
            LineSeries2.Add(new Model(3, 43));
            LineSeries2.Add(new Model(4, 53));
            LineSeries2.Add(new Model(5, 25));

            LineSeries3 = new ObservableCollection<Model>();
            LineSeries3.Add(new Model(1, 24));
            LineSeries3.Add(new Model(2, 14));
            LineSeries3.Add(new Model(3, 33));
            LineSeries3.Add(new Model(4, 43));
            LineSeries3.Add(new Model(5, 15));
            
        }

        public void LoadData()
        {
            for (var i = 0; i < 2; i++)
            {
                data.Add(new Model(time, random.Next(0, 100)));
                time = time.AddMilliseconds(500);
                count++;
            }
            count = data.Count;

            Device.StartTimer( new TimeSpan(0, 0, 0, 0, 500), () =>
            {
                data.Add(new Model(time, random.Next(0, 100)));
                time = time.AddMilliseconds(500);
                count++;
                return true;
            });
        }

        public async void LoadData1()
        {
            for (var i = 0; i < 180; i++)
            {
                liveData1.Add(new Model(i, Math.Sin(wave1 * (Math.PI / 180.0))));
                wave1++;
            }

            for (var i = 0; i < 180; i++)
            {
                liveData2.Add(new Model(i, Math.Sin(wave2 * (Math.PI / 180.0))));
                wave2++;
            }

            wave1 = liveData1.Count;

			await Task.Delay(200);

            Device.StartTimer( new TimeSpan(0, 0, 0, 0, 10), () =>
            {
                liveData1.RemoveAt(0);
                liveData1.Add(new Model(wave1, Math.Sin(wave1 * (Math.PI / 180.0))));
                wave1++;

                liveData2.RemoveAt(0);
                liveData2.Add(new Model(wave1, Math.Sin(wave2 * (Math.PI / 180.0))));
                wave2++;
                return true; 
            });
        }
    }
}
