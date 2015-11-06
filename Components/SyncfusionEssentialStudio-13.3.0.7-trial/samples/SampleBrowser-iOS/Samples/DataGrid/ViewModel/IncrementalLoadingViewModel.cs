#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfDataGrid;
using CoreFoundation;
using IncrementalLoading.NorthwindService;
using System.Data.Services.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using UIKit;
using CoreGraphics;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;
using Syncfusion.Linq;

namespace SampleBrowser
{
	public class IncrementalLoadingViewModel : INotifyPropertyChanged
	{
		#region Members

		NorthwindEntities northwindEntity;

		#endregion

		#region Ctor

		public UIActivityIndicatorView loaderindicator;
		public UILabel lable;
		public UIView border;

		public IncrementalLoadingViewModel ()
		{
			border = new UIView ();
			this.lable = new UILabel ();
			this.loaderindicator = new UIActivityIndicatorView ();
			this.loaderindicator.Color = UIColor.FromRGB (255, 255, 255);
            border.BackgroundColor = UIColor.FromRGB(70, 183, 118);
			border.Add (lable);
			border.Add (loaderindicator);

			string uri = "http://services.odata.org/Northwind/Northwind.svc/";
			if (CheckConnection (uri).Result) {
				gridSource = new IncrementalList<Order> (LoadMoreItems) { MaxItemCount = 1000 };
				northwindEntity = new NorthwindEntities (new Uri (uri));
			} else {
				NoNetwork = true;
				IsBusy = false;
			}
		}

		#endregion

		#region Properties

		private IncrementalList<Order> gridSource;

		public IncrementalList<Order> GridSource {
			get { return gridSource; }
			set {
				gridSource = value;
				RaisePropertyChanged ("GridSource");
			}
		}

		private bool isBusy;

		public bool IsBusy {
			get { return isBusy; }
			set {
				isBusy = value;
				if (isBusy) {
					this.lable.Text = "Fetching Data... ";
				} else {
					if (noNetwork) {
						lable.LineBreakMode = UILineBreakMode.WordWrap;
						lable.Lines = 0;
						this.lable.Text = "No Network Found..! \nSearching for a network...";
					}
				}
				RaisePropertyChanged ("IsBusy");
			}
		}

		private bool noNetwork;

		public bool NoNetwork {
			get { return noNetwork; }
			set {
				noNetwork = value;
				RaisePropertyChanged ("NoNetwork");
			}
		}


		#endregion

		#region INotifyPropertyChanged Member

		public event PropertyChangedEventHandler PropertyChanged;

		void RaisePropertyChanged (string propertyName)
		{
			if (PropertyChanged != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
			}
		}

		#endregion

		#region Methods

		void LoadMoreItems (uint count, int baseIndex)
		{
			BackgroundWorker worker = new BackgroundWorker ();

			worker.DoWork += (o, ae) => {
				DataServiceQuery<Order> query = northwindEntity.Orders.Expand ("Customer");
				query = query.Skip<Order> (baseIndex).Take<Order> (15) as DataServiceQuery<Order>;
				IAsyncResult ar = query.BeginExecute (null, null);
				var items = query.EndExecute (ar);
				var list = items.ToList ();

				DispatchQueue.MainQueue.DispatchAsync (new Action (() => {
					GridSource.LoadItems (list);
				}));
			};

			worker.RunWorkerCompleted += (o, ae) => {
				IsBusy = false;
				UIView.Animate (2, () => {
					for (int i = 5; i < 0; i--) {
						border.Alpha = i - 0.1f;
					}

					border.Hidden = true;
				});
				this.loaderindicator.StopAnimating ();
				this.loaderindicator.HidesWhenStopped = true;
				this.lable.Hidden = true;
			};
            
			IsBusy = true;
			{
				this.lable.Hidden = false;
				border.Hidden = false;
				UIView.Animate (2, () => {

					this.loaderindicator.StartAnimating ();
				});

			}
			worker.RunWorkerAsync ();
		}

		private async Task<bool> CheckConnection (String url)
		{
			try {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);
				request.Timeout = 5000;
				request.Credentials = CredentialCache.DefaultNetworkCredentials;
				HttpWebResponse response = (HttpWebResponse)request.GetResponse ();

				if (response.StatusCode == HttpStatusCode.OK)
					return true;
				else
					return false;
			} catch {
				return false;
			}
		}

		#endregion
	}

	public class GridGettingStartedViewModel
	{
		public GridGettingStartedViewModel ()
		{
			OrderDetailsRepository order = new OrderDetailsRepository ();
			OrdersInfo = order.GetOrderDetails (200);
		}

		#region ItemsSource

		private List<OrderInfo> _ordersInfo;

		public List<OrderInfo> OrdersInfo {
			get { return _ordersInfo; }
			set { this._ordersInfo = value; }
		}

		#endregion
	}

	public class SortViewModel
	{
		public SortViewModel ()
		{
			ProductRepository product = new ProductRepository ();
			products = product.GetProductDetails (200);
		}

		#region ItemsSource

		private List<Products> products;

		public List<Products> Products {
			get { return products; }
			set { this.products = value; }
		}

		#endregion
	}

	public class FilterViewModel:INotifyPropertyChanged
	{
		public FilterViewModel ()
		{
			this.SetRowstoGenerate (100);
		}

		#region Filtering

		internal delegate void FilterChanged ();

		internal FilterChanged filtertextchanged;

		#region Fields

		private string filtertext;

		private string selectedcolumn = "All Columns";
		private string selectedcondition = "Equals";

		#endregion

		#region Property

		public  string FilterText {
			get{ return filtertext; }
			set { 
				filtertext = value;
				OnFilterTextChanged ();
				RaisePropertyChanged ("FilterText");

			}

		}

		public string SelectedCondition { 
			get { 
				return selectedcondition;
			}
			set { 
				selectedcondition = value;
			}
		}

		public string SelectedColumn { 
			get { 
				return selectedcolumn;
			}
			set {
				selectedcolumn = value;
			}

		}

		#endregion

		void OnFilterTextChanged ()
		{
			filtertextchanged ();
		}

		private bool MakeStringFilter (BookInfo o, string option, string condition)
		{
			var value = o.GetType ().GetProperty (option);
			var exactValue = value.GetValue (o, null);
			exactValue = exactValue.ToString ().ToLower ();
			string text = FilterText.ToLower ();
			var methods = typeof(string).GetMethods ();



			if (methods.Any()) {
				if (condition == "Contains") {
					var methodInfo = methods.FirstOrDefault (method => method.Name == condition);
					bool result1 = (bool)methodInfo.Invoke (exactValue, new object[] { text });
					return result1;
				} else if (exactValue.ToString () == text.ToString ()) {
					bool result1 = String.Equals (exactValue.ToString (), text.ToString ());
                    if (condition == "Equals")
                        return result1;
                    else if (condition == "NotEquals")
                        return false;
				} else if (condition == "Not Equals") {
					return true;
				}
				return  false;
			} else
				return false;
		}

		private bool MakeNumericFilter (BookInfo o, string option, string condition)
		{
			var value = o.GetType ().GetProperty (option);
			var exactValue = value.GetValue (o, null);
			double res;
			bool checkNumeric = double.TryParse (exactValue.ToString (), out res);
			if (checkNumeric) {
				switch (condition) {
				case "Equals":
					try {
						if (exactValue.ToString () == FilterText) {
							if (Convert.ToDouble (exactValue) == (Convert.ToDouble (FilterText)))
								return true;
						}
					} catch (Exception e) {
						Console.WriteLine (e);
					}
					break;
				case "Not Equals":
					try {
						if (Convert.ToDouble (FilterText) != Convert.ToDouble (exactValue))
							return true;
					} catch (Exception e) {
						Console.WriteLine (e);
					}
					break;
				}
			}
			return false;
		}

		public bool FilerRecords (object o)
		{
			double res;
			bool checkNumeric = double.TryParse (FilterText, out res);
			var item = o as BookInfo;
			if (item != null && FilterText.Equals ("")) {
				return true;
			} else {
				if (item != null) {
					if (checkNumeric && !SelectedColumn.Equals ("All Columns") && SelectedCondition != "Contains") {
						bool result = MakeNumericFilter (item, SelectedColumn, SelectedCondition);
						return result;
					} else if (SelectedColumn.Equals ("All Columns")) {
						if (item.BookName.ToLower ().Contains (FilterText.ToLower ()) ||
						    item.Country.ToLower ().Contains (FilterText.ToLower ()) ||
						    item.FirstName.ToString ().ToLower ().Contains (FilterText.ToLower ()) ||
						    item.CustomerID.ToString ().ToLower ().Contains (FilterText.ToLower ()) ||
						    item.Price.ToString ().ToLower ().Contains (FilterText.ToLower ()) ||
						    item.BookID.ToString ().ToLower ().Contains (FilterText.ToLower ()))
							return true;
						return false;
					} else {
						//					if (SelectedCondition == null || SelectedCondition.Equals("NotEquals") || SelectedCondition.Equals("Equals"))
						//						SelectedCondition = "Contains";
						bool result = MakeStringFilter (item, SelectedColumn, SelectedCondition);
						return result;
					}
				}
			}
			return false;
		}


		#endregion

		#region ItemsSource

		private List<BookInfo> bookInfo;

		public List<BookInfo> BookInfo {
			get { return bookInfo; }
			set { this.bookInfo = value; }
		}

		#endregion

		#region ItemSource Generator

		public void SetRowstoGenerate (int count)
		{
			BookRepository bookrepository = new BookRepository ();
			bookInfo = bookrepository.GetBookDetails (count);
		}

		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged (string propertyName)
		{
			if (PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}

		#endregion
		
	}

	public class OptionsTableSource : UITableViewSource
	{
		public List<string> tableItems;
		string cellIdentifier = "TableCell";
		string[] keys = new string[]{ };
		public string selectedItem = null;

		public OptionsTableSource (List<string>items)
		{
			tableItems = items;
			keys = new string[]{ "ColumnName" };
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			cell.TextLabel.Text = tableItems [indexPath.Row];
			cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;
			return cell;
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return  keys.Length;
		}

		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			selectedItem = tableItems [indexPath.Row];
		}

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return keys [section];
		}
	}

	public class FilterOptionsTableSource : UITableViewSource
	{
		public List<string> tableItems;
		string cellIdentifier = "TableCell";
		string[] keys = new string[]{ };
		public string selecteditem = null;

		public FilterOptionsTableSource (List<string>items)
		{
			tableItems = items;
			keys = new string[]{ "Filter Condition Type" };
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, cellIdentifier);
			cell.TextLabel.Text = tableItems [indexPath.Row];
			cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;
			return cell;
		}

		public override void WillDisplay (UITableView tableView, UITableViewCell cell, Foundation.NSIndexPath indexPath)
		{
			if (cell.Selected) {
				cell.BackgroundColor = UIColor.Red;
			}
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return  keys.Length;
		}

		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			selecteditem = tableItems [indexPath.Row];
		}

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return keys [section];
		}
	}

	public class StocksViewModel : INotifyPropertyChanged, IDisposable
	{
		#region Members

		ObservableCollection<StockData> data;
		Random r = new Random (123345345);
		internal Timer timer;
		private bool enableTimer = false;
		//private DelegateCommand<object> btonClick;
		private double timerValue;
		private string buttonContent;
		private int noOfUpdates = 500;
		List<string> StockSymbols = new List<string> ();
		string[] accounts = new string[] {
			"American Funds",
			"College Savings",
			"Day Trading",
			"Retirement Savings",
			"Mountain Ranges",
			"Fidelity Funds",
			"Mortages",
			"Housing Loans"
		};

		#endregion

		/// <summary>
		/// Gets the stocks.
		/// </summary>
		/// <value>The stocks.</value>
		public ObservableCollection<StockData> Stocks {
			get {
				return this.data;
			}
		}

		#region Constructor



		/// <summary>
		/// Initializes a new instance of the <see cref="StocksViewModel"/> class.
		/// </summary>
		public StocksViewModel ()
		{
			this.data = new ObservableCollection<StockData> ();
			this.AddRows (2000);
			this.timer = new Timer ();
			this.ResetRefreshFrequency (2500);
			timer.Interval = (double)TimeSpan.FromMilliseconds (200).Milliseconds;
			ButtonContent = "Start Timer";
			timer.Elapsed += timer_Tick;
			ButtonClicked ();
		}


		#endregion

		#region Timer and updating code

		/// <summary>
		/// Sets the interval.
		/// </summary>
		/// <param name="time">The time.</param>
		public void SetInterval (TimeSpan time)
		{
			this.timer.Interval = Convert.ToDouble (time);
		}

		/// <summary>
		/// Starts the timer.
		/// </summary>
		public void StartTimer ()
		{
			if (!this.timer.Enabled) {
				this.timer.Start ();
				this.ButtonContent = "Stop Timer";
			}
		}

		/// <summary>
		/// Gets or sets the timer value.
		/// </summary>
		/// <value>The timer value.</value>
		public double TimeSpanValue {
			get {
				return timerValue;
			}
			set {
				timerValue = value;
				this.timer.Interval = Convert.ToDouble (TimeSpan.FromMilliseconds (timerValue));
				RaisePropertyChanged ("TimeSpanValue");
			}
		}

		/// <summary>
		/// Gets or sets the button contnt.
		/// </summary>
		/// <value>The button contnt.</value>
		public string ButtonContent {
			get {
				return buttonContent;
			}
			set {
				buttonContent = value;
				RaisePropertyChanged ("ButtonContent");
			}
		}

		/// <summary>
		/// Gets the bton click.
		/// </summary>
		/// <value>The bton click.</value>
		//        public DelegateCommand<object> BtonClick
		//        {
		//            get { return btonClick; }
		//        }

		/// <summary>
		/// Determines whether this instance [can button click].
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if this instance [can button click]; otherwise, <c>false</c>.
		/// </returns>
		bool CanButtonClick (object param)
		{
			return true;
		}

		/// <summary>
		/// Buttons the clicked.
		/// </summary>
		/// <param name="param">The param.</param>
		/// 
		public void ButtonClicked ()
		{
			if (ButtonContent.Equals ("Start Timer")) {
				this.EnableTimer = true;

				this.StartTimer ();
				ButtonContent = "Stop Timer";
			} else {
				this.EnableTimer = false;

				this.StopTimer ();
				ButtonContent = "Start Timer";
			}
		}

		/// <summary>
		/// Stops the timer.
		/// </summary>
		public void StopTimer ()
		{
			this.timer.Stop ();
		}

		/// <summary>
		/// Handles the Tick event of the timer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void timer_Tick (object sender, object e)
		{
			int startTime = DateTime.Now.Millisecond;
			noOfUpdates = 100;
			ChangeRows (noOfUpdates);
		}

		/// <summary>
		/// Gets or sets a value indicating whether [enable timer].
		/// </summary>
		/// <value><c>true</c> if [enable timer]; otherwise, <c>false</c>.</value>
		public bool EnableTimer {
			get {
				return this.enableTimer;
			}
			set {
				this.enableTimer = value;
			}
		}

		/// <summary>
		/// Adds the rows.
		/// </summary>
		/// <param name="count">The count.</param>
		private void AddRows (int count)
		{
			for (int i = 0; i < count; ++i) {
				var newRec = new StockData ();
				newRec.Symbol = ChangeSymbol ();
				newRec.Account = ChangeAccount (i);
				newRec.Open = Math.Round (r.NextDouble () * 30, 2);
				newRec.LastTrade = Math.Round ((1 + r.NextDouble () * 50));
				double d = r.NextDouble ();
				if (d < .5)
					newRec.StockChange = Math.Round (d, 2);
				else
					newRec.StockChange = Math.Round (d, 2) * -1;

				newRec.PreviousClose = Math.Round (r.NextDouble () * 30, 2);
				newRec.Volume = r.Next ();
				data.Add (newRec);
			}
		}

		/// <summary>
		/// Changes the symbol.
		/// </summary>
		/// <returns></returns>
		private String ChangeSymbol ()
		{
			StringBuilder builder = new StringBuilder ();
			Random random = new Random ();
			char ch;

			do {
				builder = new StringBuilder ();
				for (int i = 0; i < 4; i++) {
					ch = Convert.ToChar (Convert.ToInt32 (Math.Floor (26 * random.NextDouble () + 65)));
					builder.Append (ch);
				}

			} while (StockSymbols.Contains (builder.ToString ()));

			StockSymbols.Add (builder.ToString ());
			return builder.ToString ();
		}

		/// <summary>
		/// Changes the account.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		private String ChangeAccount (int index)
		{
			return accounts [index % accounts.Length];
		}

		/// <summary>
		/// Resets the refresh frequency.
		/// </summary>
		/// <param name="changesPerTick">The changes per tick.</param>
		public void ResetRefreshFrequency (int changesPerTick)
		{
			if (this.timer == null) {
				return;
			}

			if (!this.noOfUpdates.Equals (changesPerTick)) {
				this.StopTimer ();
				this.noOfUpdates = changesPerTick;
				if (enableTimer)
					this.StartTimer ();
			}
		}

		public object SelectedItem {
			get {
				return noOfUpdates;
			}
			set {
				noOfUpdates = 2;
				RaisePropertyChanged ("SelectedItem");
			}
		}

		public List<int> ComboCollection {
			get {
				return new List<int> { 500, 5000, 50000, 500000 };
			}
		}

		/// <summary>
		/// Changes the rows.
		/// </summary>
		/// <param name="count">The count.</param>
		private void ChangeRows (int count)
		{
			if (data.Count < count)
				count = data.Count;
			for (int i = 0; i < count; ++i) {
				int recNo = r.Next (data.Count);
				StockData recRow = data [recNo];

				data [recNo].LastTrade = Math.Round ((1 + r.NextDouble () * 50));

				double d = r.NextDouble ();
				if (d < .5) {
					data [recNo].StockChange = Math.Round (d, 2);
				} else {
					data [recNo].StockChange = Math.Round (d, 2) * -1;
				}
				data [recNo].Open = Math.Round (r.NextDouble () * 50, 2);
				data [recNo].PreviousClose = Math.Round (r.NextDouble () * 30, 2);
				data [recNo].Volume = r.Next ();
			}
		}

		#endregion

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged (String Name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (Name));
		}

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose ()
		{
			if (this.timer != null) {
				this.timer.Elapsed -= timer_Tick;
				this.StopTimer ();
			}
		}

		#endregion
	}

	public class FormattingViewModel
	{
		public FormattingViewModel ()
		{
			SetRowstoGenerate (200);
		}

		#region ItemsSource

		private List<BankInfo> bankInfo;

		public List<BankInfo> BankInfo {
			get { return bankInfo; }
			set { this.bankInfo = value; }
		}

		#endregion

		#region ItemSource Generator

		public void SetRowstoGenerate (int count)
		{
			BankRepository bank = new BankRepository ();
			bankInfo = bank.GetBankDetails (200);
		}

		#endregion

	}

	public class DataVirtualizationViewModel
	{
		public DataVirtualizationViewModel ()
		{
			var repository = new EmployeeInfoRespository ();
			viewSource = new GridVirtualizingCollectionView (repository.GetEmployeesDetails (100000));
		}

		private VirtualizingCollectionView viewSource;

		public VirtualizingCollectionView ViewSource {
			get { return viewSource; }
			set { viewSource = value; }
		}
	}

	public class SelectionViewModel : NotificationObject
	{
		public SelectionViewModel ()
		{
			ProductInfoRespository products = new ProductInfoRespository ();
			ProductDetails = products.GetProductDetails (100);
		}

		private List<ProductInfo> productDetails;

		/// <summary>
		/// Gets or sets the product details.
		/// </summary>
		/// <value>The product details.</value>
		public List<ProductInfo> ProductDetails {
			get { return productDetails; }
			set {
				productDetails = value;
				RaisePropertyChanged ("ProductDetails");
			}
		}
	}

	public class GroupingViewModel : NotificationObject
	{
		public GroupingViewModel ()
		{
			ProductInfoRespository products = new ProductInfoRespository ();
			ProductDetails = products.GetProductDetails (100);
		}

		private List<ProductInfo> productDetails;

		/// <summary>
		/// Gets or sets the product details.
		/// </summary>
		/// <value>The product details.</value>
		public List<ProductInfo> ProductDetails {
			get { return productDetails; }
			set {
				productDetails = value;
				RaisePropertyChanged ("ProductDetails");
			}
		}
	}

    public class CustomerViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public CustomerViewModel()
        {
            CustomersRepository customerrep = new CustomersRepository ();
            customerInformation = customerrep.GetCutomerDetails (100);
        }

        #endregion

        #region ItemsSource

        private ObservableCollection<CustomerDetails> customerInformation;

        public ObservableCollection<CustomerDetails> CustomerInformation
        {
            get { return this.customerInformation; }
            set { this.customerInformation = value; }
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged (string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                var e = new PropertyChangedEventArgs (propertyName);
                handler (this, e);
            }
        }

        #endregion
    }

    public class SalesInfoViewModel
    {
        #region Constructor

        public SalesInfoViewModel()
        {

        }

        #endregion

        #region ItemsSource

        private ObservableCollection<SalesByDate> dailySalesDetails = null;

        public ObservableCollection<SalesByDate> DailySalesDetails
        {
            get {
                if (dailySalesDetails == null) {
                    dailySalesDetails = new SalesInfoRepository ().GetSalesDetailsByDay (60);
                }
                return dailySalesDetails;
            }
        }

        #endregion
    }

    public class FrozenViewViewModel
    {
        #region Constructor

        public FrozenViewViewModel()
        {
            SetRowstoGenerate (100);
        }

        #endregion

        #region ItemsSource

        private List<Products> products;

        public List<Products> Products
        {
            get { return products; }
            set { this.products = value; }
        }

        #endregion

        #region ItemsSource Generator

        public void SetRowstoGenerate (int count)
        {
            ProductRepository product = new ProductRepository ();
            products = product.GetProductDetails (count);
        }

        #endregion
    }

    public class ExportingViewModel
    {
        #region Constructor 

        public ExportingViewModel()
        {
            OrderDetailsRepository order = new OrderDetailsRepository();
            OrdersInfo = order.GetOrderDetails(200);
        }

        #endregion

        #region ItemsSource

        private List<OrderInfo> _ordersInfo;

        public List<OrderInfo> OrdersInfo
        {
            get { return _ordersInfo; }
            set { this._ordersInfo = value; }
        }

        #endregion
    }
}
