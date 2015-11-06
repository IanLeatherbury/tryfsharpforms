This section contains getting started tutorials that provide a quick overview for working with our components. The goal is to get you up and running as soon as possible.

**Grid**

  [__DataGrid For Forms__](#DataGrid)

  [__DataGrid For Android__](#DataGridAndroid)

  [__DataGrid For iOS__](#DataGridiOS)

**Data Visualization**

  [__Chart__](#Chart)

  [__Gauge__](#Gauge)
  
  [__Digital Gauge__](#DigitalGauge)
  
  [__Linear Gauge__](#LinearGauge)

  [__TreeMap__](#TreeMap)
  
  [__Barcode__](#Barcode)

**File Format**

  [__XlsIO__](#XlsIO)

  [__DocIO__](#DocIO)

  [__PDF__](#PDF)
  
**Notification**

  [__BusyIndicator__](#BusyIndicator)
  
**Editors**

  [__RangeSlider__](#RangeSlider)

  [__AutoComplete__](#AutoComplete)
  
  [__NumericTextBox__](#NumericTextBox)
 
#<a id="DataGrid"></a>DataGrid

This section provides a quick overview for working with Essential DataGrid for Xamarin.Forms. We will walk through the entire process of creating a real world datagrid.

This is how the final output will look like on iOS, Android and Windows Phone devices. You can also download the entire source code of this demo from [here](http://files2.syncfusion.com/Installs/v13.2.0.29/Samples/Xamarin/DataGrid_GettingStartedForms.zip).

![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/datagrid/gettingstarted/grouping.png)

**Getting started**
 
This section provides a quick overview of the working with Essential DataGrid for Xamarin.Forms.

After installing Essential Studio for Xamarin, you can find all the required assemblies in the following installation folders,

**{Syncfusion Essential Studio Installed location}\Essential Studio\13.2.0.29\lib**

***Note: Assemblies can be found in unzipped package location in Mac***

Add the following assemblies to the respective projects as follows:

**PCL project**
```
pcl\Syncfusion.Data.Portable.dll
pcl\Syncfusion.GridCommon.Portable.dll
pcl\Syncfusion.SfDataGrid.XForms.dll
```

**Android project**
```
android\Syncfusion.SfDataGrid.XForms.Android.dll
```

**iOS project**
```
pcl\Syncfusion.GridCommon.Portable.dll
ios\Syncfusion.SfDataGrid.XForms.iOS.dll
```

**WindowsPhone project**
```
wp8\Syncfusion.SfDataGrid.XForms.WinPhone.dll
```
Currently an additional step is required for Windows Phone and iOS projects. We need to initialize the DataGrid renderer as shown below.

Call the SfDataGridRenderer.Init() in MainPage constructor of the Windows Phone project as shown below
```
public MainPage()
{
    …
    SfDataGridRenderer.Init();
    …
}
```

Call the SfDataGridRenderer.Init() in the FinishedLaunching overridden method of the AppDelegate class in the iOS project as follows.
```
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
    …
    SfDataGridRenderer.Init();
    …
}
```

**Create your first DataGrid in Xamarin.Forms**

The DataGrid control can be configured entirely in C# code or by using XAML markup.

⦁ Create new BlankApp (Xamarin.Forms.Portable) application in Xamarin Studio or Visual Studio.

⦁ Now, create a simple data source as shown in the following code example. Add the following code example in a newly created class file and save it as OrderInfo.cs file.


```csharp
public class OrderInfo
{
    private int orderID;
    private string customerID;
    private string customer;
    private string shipCity;
    private string shipCountry;

    public int OrderID {
        get { return orderID; }
        set { this.orderID = value; }
    }

    public string CustomerID {
        get { return customerID; }
        set { this.customerID = value; }
    }

    public string ShipCountry {
        get { return shipCountry; }
        set { this.shipCountry = value; }
    }

    public string Customer {
        get { return this.customer; }
        set { this.customer = value; }
    }

    public string ShipCity {
        get { return shipCity; }
        set { this.shipCity = value; }
    }

    public OrderInfo (int orderId, string customerId, string country, string customer, string shipCity)
    {
        this.OrderID = orderId;
        this.CustomerID = customerId;
        this.Customer = customer;
        this.ShipCountry = country;
        this.ShipCity = shipCity;
    }
} 
```


⦁ Add the following code example in a newly created class file and save it as OrderInfoRepositiory.cs file.
	  
```csharp
public class OrderInfoRepository
{
    private ObservableCollection<OrderInfo> orderInfo;
    public ObservableCollection<OrderInfo> OrderInfoCollection {
        get { return orderInfo; }
        set { this.orderInfo = value; }
    }
	
    public OrderInfoRepository ()
    {
        orderInfo = new ObservableCollection<OrderInfo> ();
        this.GenerateOrders ();
    }
	
    private void GenerateOrders ()
    {
        orderInfo.Add (new OrderInfo (1001, "Maria Anders", "Germany", "ALFKI", "Berlin"));
        orderInfo.Add (new OrderInfo (1002, "Ana Trujilo", "Mexico", "ANATR", "México D.F."));
        orderInfo.Add (new OrderInfo (1003, "Ant Fuller", "Mexico", "ANTON", "México D.F."));
        orderInfo.Add (new OrderInfo (1004, "Thomas Hardy", "UK", "AROUT", "London"));
        orderInfo.Add (new OrderInfo (1005, "Tim Adams", "Sweden", "BERGS", "Luleå"));
        orderInfo.Add (new OrderInfo (1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim"));
        orderInfo.Add (new OrderInfo (1007, "Andrew Fuller", "France", "BLONP", "Strasbourg"));
        orderInfo.Add (new OrderInfo (1008, "Martin King", "Spain", "BOLID", "Madrid"));
        orderInfo.Add (new OrderInfo (1009, "Lenny Lin", "France", "BONAP", "Marseille"));
        orderInfo.Add (new OrderInfo (1010, "John Carter", "Canada", "BOTTM", "Tsawassen"));
        orderInfo.Add (new OrderInfo (1011, "Lauro King", "UK", "AROUT", "London"));
        orderInfo.Add (new OrderInfo (1012, "Anne Wilson", "Germany", "BLAUS", "Mannheim"));
		orderInfo.Add (new OrderInfo (1013, "Alfki Kyle", "France", "BLONP", "Strasbourg"));
        orderInfo.Add (new OrderInfo (1014, "Gina Irene", "UK", "AROUT", "London"));
    }
} 
```
⦁ You can set the data source of the DataGrid by using the SfDataGrid.ItemsSource property as follows.

**[C#]**
```csharp
public class App : Application
{
    SfDataGrid sfGrid;
    public App()
    {
        sfGrid = new SfDataGrid();
        sfGrid.ItemsSource = new OrderInfoRepository().OrderInfoCollection;
        MainPage = new ContentPage { Content = sfGrid; };
    }
} 
```

**[XAML]**
```xml
<xmlns:sfgrid="clr-namespace:Syncfusion.SfDataGrid.XForms;assembly=Syncfusion.SfDataGrid.XForms"

<sfgrid:SfDataGrid x:Name="dataGrid"
                   ItemsSource="{Binding OrderInfoCollection}" />  
```

⦁ By default, Essential DataGrid for Xamarin.Forms automatically creates columns for all the properties in the data source. 
⦁ Execute the application to render the following output.

![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/datagrid/gettingstarted/gettingstarted.png)

⦁ You can also define the columns manually by setting the SfDataGrid.AutoGenerateColumns property to false and by adding the GridColumn objects to the SfDataGrid.Columns collection. The following code example illustrates this.
	  
**[C#]**
```csharp
sfGrid.AutoGenerateColumns = false;

GridTextColumn orderIdColumn = new GridTextColumn ();
orderIdColumn.MappingName = "OrderID";
orderIdColumn.HeaderText = "Order ID";

GridTextColumn customerIdColumn = new GridTextColumn ();
customerIdColumn.MappingName = "CustomerID";
customerIdColumn.HeaderText = "Customer ID";

GridTextColumn customerColumn = new GridTextColumn ();
customerColumn.MappingName = "Customer";
customerColumn.HeaderText = "Customer";

GridTextColumn countryColumn = new GridTextColumn ();
countryColumn.MappingName = "ShipCountry";
countryColumn.HeaderText = "Ship Country";

sfGrid.Columns.Add (orderIdColumn);
sfGrid.Columns.Add (customerIdColumn);
sfGrid.Columns.Add (customerColumn);
sfGrid.Columns.Add (countryColumn);
```	

**[XAML]**
```xml
<sfgrid:SfDataGrid.Columns x:TypeArguments="sfgrid:Columns">

    <sfgrid:GridTextColumn HeaderText="Order ID" MappingName="OrderID" />
    <sfgrid:GridTextColumn HeaderText="Customer ID" MappingName="CustomerID" />
    <sfgrid:GridTextColumn MappingName="Customer" />
    <sfgrid:GridTextColumn HeaderText="Ship Country" MappingName="ShipCountry" />

</sfgrid:SfDataGrid.Columns>  
```  

⦁ Essential DataGrid for Xamarin.Forms allows you to apply sorting on its data by setting AllowSorting to true. The following code illustrates this.

**[C#]**
```csharp
sfGrid.AllowSorting = true; 
```

**[XAML]**
```xml
<sfgrid:SfDataGrid AllowSorting="True" />
```
	
⦁ Execute the application and touch the header cell to sort the data and the following output is displayed

 ![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/datagrid/gettingstarted/sorting.png)	 

⦁ You can also specify the column to be sorted from the code behind by adding the column to the SfDataGrid.SortColumnDescriptions collection. The following code illustrates this.

**[C#]**
```csharp
sfGrid.SortColumnDescriptions.Add (new SortColumnDescription () { ColumnName = "CustomerID" });
```

**[XAML]**
```xml
<sfgrid:SfDataGrid.SortColumnDescriptions>
    <sfgrid:SortColumnDescription ColumnName="CustomerID" />
</sfgrid:SfDataGrid.SortColumnDescriptions> 
```

⦁ You can group a column by adding the column to the SfDataGrid.GroupColumnDescriptions collection. Following code example illustrates this.

**[C#]**
```csharp
sfGrid.GroupColumnDescriptions.Add (new GroupColumnDescription (){ ColumnName = "ShipCountry" }); 
````

**[XAML]**
```xml
<sfgrid:SfDataGrid.GroupColumnDescriptions>
    <sfgrid:GroupColumnDescription ColumnName="ShipCountry" />
</sfgrid:SfDataGrid.GroupColumnDescriptions>  
```

⦁ Execute the application to render the following output.
	
![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/datagrid/gettingstarted/grouping.png)

⦁ You can filter the records in the view by using the SfDataGrid.View.Filter property. You have to call SfDataGrid.View.RefreshFilter() method after assigning the Filter property for the records to get filtered in view. The following code example illustrates this.

**[C#]**
```csharp
//Create a SearchBar in the layout and assign its text to a property. When the property gets changed, run the below code for filtering the view.

if (sfGrid.View != null) {
    this.sfGrid.View.Filter = viewModel.FilerRecords;
    this.sfGrid.View.RefreshFilter ();
} 

//create a method FilterRecords in the viewModel

public bool FilerRecords (object orderInfo)
{
    //your code

    //For Example
    var order = orderInfo as OrderInfo;
    if (order.CustomerID.Contains ("An"))
        return true;
    false;
} 
```
 
#<a id="DataGridAndroid"></a>DataGrid for Xamarin.Android

This section provides a quick overview for working with Essential DataGrid for Xamarin.Android. We will walk through the entire process of creating a real world datagrid.

This is how the final output will look like on Android devices. You can also download the entire source code of this demo from [here](http://files2.syncfusion.com/Installs/v13.2.0.29/Samples/Xamarin/DataGrid_GettingStartedAndroid.zip).

![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/android/datagrid/gettingstarted/grouping.png)

**Referencing Essential Studio components in your solution**
 
This topic describes about the assembly that is required in your Android application when you use SfDataGrid. After installing Essential Studio for Xamarin, you can find all the required assemblies in the installation folders.

**{Syncfusion Essential Studio Installed location}\Essential Studio\13.2.0.29\lib**

***Note: Assemblies can be found in unzipped package location in Mac***

```
Syncfusion.Linq.Android.dll
Syncfusion.SfDataGrid.Android.dll
Syncfusion.GridCommon.Portable.dll
```

**Create your first DataGrid in Xamarin Android**

1.Create a new Android application in Xamarin Studio.

2.Now, create a simple data source as shown in the following code example. Add the following code example in a newly created class file and save it as OrderInfo.cs file.

```csharp
public class OrderInfo
{
    private int orderID;
    private string customerID;
    private string customer;
    private string shipCity;
    private string shipCountry;

    public int OrderID {
        get { return orderID; }
        set { this.orderID = value; }
    }

    public string CustomerID {
        get { return customerID; }
        set { this.customerID = value; }
    }

    public string ShipCountry {
        get { return shipCountry; }
        set { this.shipCountry = value; }
    }

    public string Customer {
        get { return this.customer; }
        set { this.customer = value; }
    }

    public string ShipCity {
        get { return shipCity; }
        set { this.shipCity = value; }
    }

    public OrderInfo (int orderId, string customerId, string country, string customer, string shipCity)
    {
        this.OrderID = orderId;
        this.CustomerID = customerId;
        this.Customer = customer;
        this.ShipCountry = country;
        this.ShipCity = shipCity;
    }
} 
```


3.Add the following code example in a newly created class file and save it as OrderInfoRepositiory.cs file
	  
```csharp
public class OrderInfoRepository
{
    private ObservableCollection<OrderInfo> orderInfo;
    public ObservableCollection<OrderInfo> OrderInfoCollection {
        get { return orderInfo; }
        set { this.orderInfo = value; }
    }
    public OrderInfoRepository ()
    {
        orderInfo = new ObservableCollection<OrderInfo> ();
        this.GenerateOrders ();
    }
    private void GenerateOrders ()
    {
        orderInfo.Add (new OrderInfo (1001, "Maria Anders", "Germany", "ALFKI", "Berlin"));
        orderInfo.Add (new OrderInfo (1002, "Ana Trujilo", "Mexico", "ANATR", "México D.F."));
        orderInfo.Add (new OrderInfo (1003, "Ant Fuller", "Mexico", "ANTON", "México D.F."));
        orderInfo.Add (new OrderInfo (1004, "Thomas Hardy", "UK", "AROUT", "London"));
        orderInfo.Add (new OrderInfo (1005, "Tim Adams", "Sweden", "BERGS", "Luleå"));
        orderInfo.Add (new OrderInfo (1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim"));
        orderInfo.Add (new OrderInfo (1007, "Andrew Fuller", "France", "BLONP", "Strasbourg"));
        orderInfo.Add (new OrderInfo (1008, "Martin King", "Spain", "BOLID", "Madrid"));
        orderInfo.Add (new OrderInfo (1009, "Lenny Lin", "France", "BONAP", "Marseille"));
        orderInfo.Add (new OrderInfo (1010, "John Carter", "Canada", "BOTTM", "Tsawassen"));
        orderInfo.Add (new OrderInfo (1011, "Lauro King", "UK", "AROUT", "London"));
        orderInfo.Add (new OrderInfo (1012, "Anne Wilson", "Germany", "BLAUS", "Mannheim"));
    }
} 

```
4.You can set the data source of the DataGrid by using the SfDataGrid.ItemsSource property as follows.

```csharp
[Activity (Label = "GettingStarted", MainLauncher = true)]
public class MainActivity : Activity
{
    SfDataGrid sfGrid;
    protected override void OnCreate (Bundle bundle)
    {
        base.OnCreate (bundle);
        SetContentView (Resource.Layout.Main);
        RelativeLayout layout = (RelativeLayout)FindViewById (Resource.Id.Relative);
        sfGrid = new SfDataGrid (BaseContext);
        sfGrid.ItemsSource = (new OrderInfoRepository ().OrderInfoCollection);
        layout.AddView (sfGrid);
    }
} 

```
5.By default, the Essential DataGrid for Android automatically creates columns for all properties in the data source.

6.Run the application to render the following output.

![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/android/datagrid/gettingstarted/gettingstarted.png)

7.You can also define the columns manually by setting the SfDataGrid.AutoGenerateColumns property to false and add the GridColumn objects to the SfDataGrid.Columns collection. The following code example illustrates this.
	  
```csharp
sfGrid.AutoGenerateColumns = false;

GridTextColumn orderIdColumn = new GridTextColumn ();
orderIdColumn.MappingName = "OrderID";
orderIdColumn.HeaderText = "Order ID";

GridTextColumn customerIdColumn = new GridTextColumn ();
customerIdColumn.MappingName = "CustomerID";
customerIdColumn.HeaderText = "Customer ID";

GridTextColumn customerColumn = new GridTextColumn ();
customerColumn.MappingName = "Customer";
customerColumn.HeaderText = "Customer";

GridTextColumn countryColumn = new GridTextColumn ();
countryColumn.MappingName = "ShipCountry";
countryColumn.HeaderText = "Ship Country";

sfGrid.Columns.Add (orderIdColumn);
sfGrid.Columns.Add (customerIdColumn);
sfGrid.Columns.Add (customerColumn);
sfGrid.Columns.Add (countryColumn); 
```	  

8.Essential DataGrid for Android allows you to apply sorting on its data by setting AllowSorting to true. The following code illustrates this.

```csharp
sfGrid.AllowSorting = true; 
```
	
9.Run the application and touch the header cell to sort the data and the following output is displayed. 

 ![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/android/datagrid/gettingstarted/sorting.png)	 

10.You can also specify the column to be sorted from the code behind by adding the column to the SfDataGrid.SortColumnDescriptions collection. The following code illustrates this.

```csharp
sfGrid.SortColumnDescriptions.Add (new SortColumnDescription () { ColumnName = "OrderID" });
```

11.Essential DataGrid for Android allows you to group a column by adding the column to the SfDataGrid.GroupColumnDescriptions collection. The following code example illustrates this.

```csharp
sfGrid.GroupColumnDescriptions.Add (new GroupColumnDescription (){ ColumnName = "ShipCountry" }); 
````

12.Run the application to render the following output.
	
![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/android/datagrid/gettingstarted/grouping.png)

13.Essential DataGrid for Android allows you to filter the records in the view by using the SfDataGrid.View.Filter property. You have to call SfDataGrid.View.RefreshFilter() method after assigning the Filter property for the records to get filtered in view. The following code example illustrates this.

```csharp
//Create an EditText in the layout and assign its text to a property. When the property gets changed, run the below code for filtering the view.

if (sfGrid.View != null) {
    this.sfGrid.View.Filter = viewModel.FilerRecords;
    this.sfGrid.View.RefreshFilter ();
} 

//create a method FilterRecords in the viewModel

public bool FilerRecords (object orderInfo)
{
    //your code

    //For Example
    var order = orderInfo as OrderInfo;
    if (order.CustomerID.Contains ("An"))
        return true;
    false;
} 
```

#<a id="DataGridiOS"></a>DataGrid for Xamarin.iOS

This section provides a quick overview for working with Essential DataGrid for Xamarin.iOS. We will walk through the entire process of creating a real world datagrid.

This is how the final output will look like on iOS devices. You can also download the entire source code of this demo from [here](http://files2.syncfusion.com/Installs/v13.2.0.29/Samples/Xamarin/DataGrid_GettingStartediOS.zip).

![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/ios/datagrid/gettingstarted/grouping.png)

**Referencing Essential Studio components in your solution**

This topic describes about the assembly that is required in your iOS application, when you use SfDataGrid. After installing Essential Studio for Xamarin, you can find all the required assemblies in the following installation folders,

**{Syncfusion Essential Studio Installed location}\Essential Studio\13.2.0.29\lib**

***Note: Assemblies can be found in unzipped package location in Mac***

```
Syncfusion.Linq.iOS.dll
Syncfusion.SfDataGrid.iOS.dll
Syncfusion.GridCommon.Portable.dll
```

Create your first DataGrid in Xamarin iOS

1.Create new iOS application in Xamarin Studio.

2.Now, create a simple data source as shown in the following code example. Add the following code example in a newly created class file and save it as OrderInfo.cs file.

```csharp
public class OrderInfo
{
    private int orderID;
    private string customerID;
    private string customer;
    private string shipCity;
    private string shipCountry;

    public int OrderID {
        get { return orderID; }
        set { this.orderID = value; }
    }

    public string CustomerID {
        get { return customerID; }
        set { this.customerID = value; }
    }

    public string ShipCountry {
        get { return shipCountry; }
        set { this.shipCountry = value; }
    }

    public string Customer {
        get { return this.customer; }
        set { this.customer = value; }
    }

    public string ShipCity {
        get { return shipCity; }
        set { this.shipCity = value; }
    }

    public OrderInfo (int orderId, string customerId, string country, string customer, string shipCity)
    {
        this.OrderID = orderId;
        this.CustomerID = customerId;
        this.Customer = customer;
        this.ShipCountry = country;
        this.ShipCity = shipCity;
    }
} 
```
3.Add the following code example in a newly created class file and save it as OrderInfoRepositiory.cs file.

```csharp
public class OrderInfoRepository
{
    private ObservableCollection<OrderInfo> orderInfo;
    public ObservableCollection<OrderInfo> OrderInfoCollection {
        get { return orderInfo; }
        set { this.orderInfo = value; }
    }
    public OrderInfoRepository ()
    {
        orderInfo = new ObservableCollection<OrderInfo> ();
        this.GenerateOrders ();
    }
    private void GenerateOrders ()
    {
        orderInfo.Add (new OrderInfo (1001, "Maria Anders", "Germany", "ALFKI", "Berlin"));
        orderInfo.Add (new OrderInfo (1002, "Ana Trujilo", "Mexico", "ANATR", "México D.F."));
        orderInfo.Add (new OrderInfo (1003, "Ant Fuller", "Mexico", "ANTON", "México D.F."));
        orderInfo.Add (new OrderInfo (1004, "Thomas Hardy", "UK", "AROUT", "London"));
        orderInfo.Add (new OrderInfo (1005, "Tim Adams", "Sweden", "BERGS", "Luleå"));
        orderInfo.Add (new OrderInfo (1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim"));
        orderInfo.Add (new OrderInfo (1007, "Andrew Fuller", "France", "BLONP", "Strasbourg"));
        orderInfo.Add (new OrderInfo (1008, "Martin King", "Spain", "BOLID", "Madrid"));
        orderInfo.Add (new OrderInfo (1009, "Lenny Lin", "France", "BONAP", "Marseille"));
        orderInfo.Add (new OrderInfo (1010, "John Carter", "Canada", "BOTTM", "Tsawassen"));
        orderInfo.Add (new OrderInfo (1011, "Lauro King", "UK", "AROUT", "London"));
        orderInfo.Add (new OrderInfo (1012, "Anne Wilson", "Germany", "BLAUS", "Mannheim"));
    }
} 
```

4.You can set the data source of the DataGrid by using the SfDataGrid.ItemsSource property as follows.

```csharp
public partial class GettingStartedViewController : UIViewController
{
    SfDataGrid sfGrid;

    static bool UserInterfaceIdiomIsPhone {
        get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
    }

    public GettingStartedViewController ()
        : base (UserInterfaceIdiomIsPhone ? "GettingStartedViewController_iPhone" : "GettingStartedViewController_iPad", null)
    {
        sfGrid = new SfDataGrid ();
        sfGrid.ItemsSource = (new OrderInfoRepository ().OrderInfoCollection);
        sfGrid.HeaderRowHeight = 45;
        sfGrid.RowHeight = 45;
    }

    public override void ViewDidLoad ()
    {
        base.ViewDidLoad ();
        sfGrid.Frame = new CGRect (0, 30, View.Frame.Width, View.Frame.Height);
        View.AddSubview (sfGrid);
    }
} 
```

5.By default, the Essential DataGrid for iOS automatically creates columns for all the properties in the data source. 

6.Run the application to render the following output.

![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/ios/datagrid/gettingstarted/gettingstarted.png)

7.You can also define the columns manually by setting the SfDataGrid.AutoGenerateColumns property to false and add the GridColumn objects to the SfDataGrid.Columns collection. The following code example illustrates this. 

```csharp
sfGrid.AutoGenerateColumns = false;

GridTextColumn orderIdColumn = new GridTextColumn ();
orderIdColumn.MappingName = "OrderID";
orderIdColumn.HeaderText = "Order ID";

GridTextColumn customerIdColumn = new GridTextColumn ();
customerIdColumn.MappingName = "CustomerID";
customerIdColumn.HeaderText = "Customer ID";

GridTextColumn customerColumn = new GridTextColumn ();
customerColumn.MappingName = "Customer";
customerColumn.HeaderText = "Customer";

GridTextColumn countryColumn = new GridTextColumn ();
countryColumn.MappingName = "ShipCountry";
countryColumn.HeaderText = "Ship Country";

sfGrid.Columns.Add (orderIdColumn);
sfGrid.Columns.Add (customerIdColumn);
sfGrid.Columns.Add (customerColumn);
sfGrid.Columns.Add (countryColumn); 
```

8.Essential DataGrid for iOS allows you to apply sorting on its data by setting AllowSorting to true. The following code illustrates this.

```csharp
sfGrid.AllowSorting = true; 
```
9.Run the application and touch the header cell to sort the data and the following output is displayed. 

![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/ios/datagrid/gettingstarted/sorting.png)


10.You can also specify the column to be sorted from the code behind by adding the column to the SfDataGrid.SortColumnDescriptions collection. The following code illustrates this.

```csharp
sfGrid.SortColumnDescriptions.Add (new SortColumnDescription () { ColumnName = "OrderID" });
```

11.Essential DataGrid for iOS allows you to group a column by adding the column to the SfDataGrid.GroupColumnDescriptions collection. Following code example illustrates this.

```csharp
sfGrid.GroupColumnDescriptions.Add (new GroupColumnDescription (){ ColumnName = "ShipCountry" }); 
```

12.Run the application to render the following output.

![datagrid]( http://www.syncfusion.com/Content/en-US/products/Images/ios/datagrid/gettingstarted/grouping.png)

13.Essential DataGrid for iOS allows you to filter the records in the view by using the SfDataGrid.View.Filter property. You have to call SfDataGrid.View.RefreshFilter() method after assigning the Filter property for the records to get filtered in view. The following code example illustrates this.

```csharp
//Create a UITextView in the layout and assign its text to a property. When the property gets changed, run the below code for filtering the view. 

if (sfGrid.View != null) {
    this.sfGrid.View.Filter = viewModel.FilerRecords;
    this.sfGrid.View.RefreshFilter ();
} 

//create a method FilterRecords in the viewModel

public bool FilerRecords (object orderInfo)
{
    //your code

    //For Example
    var order = orderInfo as OrderInfo;
    if (order.CustomerID.Contains ("An"))
        return true;
    false;
} 
```



#<a id="Chart"></a>Creating your first Chart in Xamarin.Forms

This section provides a quick overview for working with Essential Chart for Xamarin.Forms. We will walk through the entire process of creating a real world chart.

The goal of this tutorial is to visualize the weather data for Washington, DC during the period 1961-1990. The raw sample data is given below.

| Month | High | Low | Precipitation |
| --- | --- | --- | --- |
| January | 42 | 27 | 3.03 |
| February | 44 | 28 | 2.48 |
| March | 53 | 35 | 3.23 |
| April | 64 | 44 | 3.15 |
| May | 75 | 54 | 4.13 |
| June | 83 | 63 | 3.23 |
| July | 87 | 68 | 4.13 |
| August | 84 | 66 | 4.88 |
| September | 78 | 59 | 3.82 |
| October | 67 | 48 | 3.07 |
| November | 55 | 38 | 2.83 |
| December | 45 | 29 | 2.8 |

Table 1: Sample weather data.

This is how the final output will look like on iOS, Android and Windows Phone devices. You can also download the entire source code of this demo from [here](http://files2.syncfusion.com/Installs/v12.2.0.40/Samples/Xamarin/Chart_GettingStarted.zip).

![chart](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/chart/gettingstarted/weatheranalysis.png)

**Referencing Essential Studio components in your solution**

If you had acquired Essential Studio components through the Xamarin component store interface from within your IDE, then after adding the components to your Xamarin.iOS, Xamarin.Android and Windows Phone projects through the Component manager, you will still need to manually reference the PCL (Portable Class Library) assemblies in the Xamarin.Forms PCL project in your solution. You can do this by manually adding the relevant PCL assembly references to your PCL project contained in the following path inside of your solution folder  

```
Components/syncfusionessentialstudio-version/lib/pcl/
```

Alternatively if you had downloaded Essential Studio from Syncfusion.com or through the Xamarin store web interface then all assembly references need to be added manually.  

After installing Essential Studio for Xamarin, all the required assemblies can be found in the installation folders, typically
	
**{Syncfusion Installed location}\Essential Studio\13.1.0.21\lib**

_Eg: C:\Program Files (x86)\Syncfusion\Essential Studio\13.1.0.21\lib_

or after downloading through the Xamarin store web interface, all the required assemblies can be found in the below folder

**{download location}\syncfusionessentialstudio-version\lib**

You can then add the assembly references to the respective projects as shown below

**PCL project**

```
pcl\Syncfusion.SfChart.XForm.dll 
```

**Android project**

```
android\Syncfusion.SfChart.Android.dll
android\Syncfusion.SfChart.xForms.Android.dll
```

**iOS(Classic) project**

```
ios\Syncfusion.SfChart.iOS.dll 
ios\Syncfusion.SfChart.xForms.iOS.dll
ios\Syncfusion.SfChart.XForm.dll
```

**iOS(Unified) project**

```
ios-unified\Syncfusion.SfChart.iOS.dll 
ios-unified\Syncfusion.SfChart.xForms.iOS.dll
ios-unified\Syncfusion.SfChart.XForm.dll
```

**Windows Phone project**

```
wp8\Syncfusion.SfChart.WP8.dll
wp8\Syncfusion.SfChart.xForms.WinPhone.dll
```

Note: Essential Chart for Xamarin is compatible with Xamarin.Forms v1.2.3.6257.

Currently an additional step is required for configuring Windows Phone and iOS projects. We need to create an instance of the chart custom renderer as shown below.

Create an instance of SfChartRenderer in the MainPage constructor of the Windows Phone project as shown below

```csharp
public MainPage()
{
	new SfChartRenderer();
	...  
}
```

Create an instance of SfChartRenderer in FinishedLaunching overridden method of AppDelegate class in the iOS Project as shown below

```csharp
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
	new SfChartRenderer();
	...  
}
```

**Adding and configuring the chart**

The chart control can be configured entirely in C# code or using XAML markup.

1. Create an instance of SfChart
2. Add the primary and secondary axis for the chart as shown below.

**[C#]**

```csharp
SfChart chart = new SfChart ();

//Initializing Primary Axis   
CategoryAxisprimaryAxis=newCategoryAxis();
primaryAxis.Title=newChartAxisTitle(){Text="Month"};
chart.PrimaryAxis=primaryAxis;

//Initializing Secondary Axis
NumericalAxissecondaryAxis=newNumericalAxis();
secondaryAxis.Title=newChartAxisTitle(){Text="Temperature"};
chart.SecondaryAxis=secondaryAxis;

this.Content = chart;
```

**[XAML]** 

```xml
<chart:SfChart>
	<chart:SfChart.PrimaryAxis>
		<chart:CategoryAxis>
			<chart:CategoryAxis.Title>
				<chart:ChartAxisTitle Text="Month"/>
			</chart:CategoryAxis.Title>
		</chart:CategoryAxis>
	</chart:SfChart.PrimaryAxis>

	<chart:SfChart.SecondaryAxis>
		<chart:NumericalAxis>
			<chart:NumericalAxis>
				<chart:ChartAxisTitle Text="Month"/>
			</chart:NumericalAxis>
		</chart:NumericalAxis>
	</chart:SfChart.SecondaryAxis>
</chart:SfChart>
```

A title for the chart is set using the Title property as shown below,

**[C#]**

```csharp
chart.Title=newChartTitle(){Text="WeatherAnalysis"};
```

**[XAML]**

```xml
<chart:SfChart>
	<chart:SfChart.Title>
		<chart:ChartTitle Text="Weather Analysis"/>
	</chart:SfChart.Title>
	<!-- ... -->
</chart:SfChart>
```

**Add Chart series**

In this sample we will be visualizing the temperature over the months using a Column Series. Before creating the series, let's create a data model representing the climate details data.

In SfChart, the series itemsource needs to be a collection of _ChartDataPoint_ objects. Add the following class for generating the datapoints.

```csharp
publicclassDataModel
{
	publicObservableCollectionHighTemperature;

	publicDataModel()
	{
		HighTemperature=newObservableCollection();

		HighTemperature.Add(newChartDataPoint("Jan",42));
		HighTemperature.Add(newChartDataPoint("Feb",44));
		HighTemperature.Add(newChartDataPoint("Mar",53));
		HighTemperature.Add(newChartDataPoint("Apr",64));
		HighTemperature.Add(newChartDataPoint("May",75));
		HighTemperature.Add(newChartDataPoint("Jun",83));
		HighTemperature.Add(newChartDataPoint("Jul",87));
		HighTemperature.Add(newChartDataPoint("Aug",84));
		HighTemperature.Add(newChartDataPoint("Sep",78));
		HighTemperature.Add(newChartDataPoint("Oct",67));
		HighTemperature.Add(newChartDataPoint("Nov",55));
		HighTemperature.Add(newChartDataPoint("Dec",45));
	}
}    
```
   

Now add the series to the chart and set its ItemsSource as shown below

**[C#]**

```csharp
//Adding the series to the chart

chart.Series.Add(newColumnSeries(){
	ItemsSource=dataModel.HighTemperature
});
```

**[XAML]**

```xml
<chart:SfChart>
	<!-- ... -->	
	<chart:SfChart.Series>
		<chart:ColumnSeries ItemsSource = "{Binding HighTemperature}"/>				
	</chart:SfChart.Series>
</chart:SfChart>
```
	
**Adding Legends**

Legends can be enabled in SfChart by initializing the _Legend_ property with _ChartLegend_ instance as shown below

**[C#]**

```csharp
    //Adding Legend
    chart.Legend=newChartLegend();
```

**[XAML]**

```xml
<chart:SfChart>
	<chart:SfChart.Legend>
		<chart:ChartLegend/>
	</chart:SfChart.Legend>
	<!-- ... -->
</chart:SfChart>
```

Circular legend icons will be displayed for each series by default. Next, we need to provide the labels for the series using the Label property, this information will be displayed along the legend icon.

The next step is to add the HighTemperature column series as shown below

**[C#]**

```csharp
//Adding the column series to the chart
chart.Series.Add(newColumnSeries(){ItemsSource=dataModel.HighTemperature,
	Label="Series1"
});
```

**[XAML]**

```xml
<chart:SfChart>
	<!-- ... -->
	<chart:SfChart.Series>
		<chart:ColumnSeries Label = "Series 1" ItemsSource =
			"{Binding HighTemperature}"/>
	</chart:SfChart.Series>
</chart:SfChart>
```

**Adding multiple series to the chart**

So far we have visualized just the high temperature data over time. Now let's visualize other data such as low temperature and precipitation.

Let's add two _SplineSeries_ for displaying high and low temperatures and a _ColumnSeries_ for displaying the precipitation as shown below

**[C#]**

```csharp
DataModeldataModel=newDataModel();

//Adding Column Series to the chart for displaying precipitation
chart.Series.Add(newColumnSeries(){
	ItemsSource=dataModel.Precipitation,
	Label="Precipitation"
});

//Adding the Spline Series to the chart for displaying high temperature
chart.Series.Add(newSplineSeries(){
	ItemsSource=dataModel.HighTemperature,
	Label="High"
});

//Adding the Spline Series to the chart for displaying low temperature
chart.Series.Add(newSplineSeries(){
	ItemsSource=dataModel.LowTemperature,
	Label="Low"
});
```

**[XAML]**

```xml
<chart:SfChart>
	<!-- ... -->	
	<chart:SfChart.Series>
		<chart:ColumnSeries   Label = "Low" ItemsSource =
			"{Binding Precipitation}"/>
		<chart:SplineSeries  Label = "High" ItemsSource =
			"{Binding HighTemperature}"/>
		<chart:SplineSeries  Label = "Low" ItemsSource =
			"{Binding LowTemperature}"/>
	</chart:SfChart.Series>
</chart:SfChart>
```

Currently all the data is plotted against a single scale but the precipitation data needs to be plotted against a different scale.

**Adding multiple Y-axis**

Let's add a secondary axis(y axis) to the chart as shown below

**[C#]**
	
```csharp
//Adding Column Series to the chart for displaying precipitation
chart.Series.Add(newColumnSeries(){
	ItemsSource=dataModel.Precipitation,
	Label="Precipitation",
	YAxis=newNumericalAxis(){OpposedPosition=true}
);
```

**[XAML]**

```xml
	<chart:SfChart>
	<!-- ... -->
	<chart:ColumnSeries   Label = "Low" ItemsSource =
		"{Binding Precipitation}">
		<chart:ColumnSeries.YAxis>
			<chart:NumericalAxis OpposedPosition ="true"/>
		</chart:ColumnSeries.YAxis>
	</chart:ColumnSeries>
	<!-- ... -->
</chart:SfChart>
```

The _OpposedPostion_ has been set to true to place the secondary axis on the opposite side.

Here is the complete code snippet for creating the chart

**[C#]**

```csharp
public class WeatherChartDemo:ContentPage
{
	public WeatherChartDemo()
	{
		//Initializing chart
		SfChartchart=newSfChart();
		chart.Title=newChartTitle(){Text="WeatherAnalysis"};

		//Initializing Primary Axis
		CategoryAxisprimaryAxis=newCategoryAxis();
		primaryAxis.Title=newChartAxisTitle(){Text="Month"};
		chart.PrimaryAxis=primaryAxis;

		//Initializing Secondary Axis
		NumericalAxissecondaryAxis=newNumericalAxis();
		secondaryAxis.Title=newChartAxisTitle(){Text="Temperature"};
		chart.SecondaryAxis=secondaryAxis;
		DataModeldataModel=newDataModel();

		//Adding Column Series to the chart for displaying precipitation
		chart.Series.Add(newColumnSeries(){
			ItemsSource=dataModel.Precipitation,
			Label="Precipitation",
			YAxis=newNumericalAxis(){OpposedPosition=true,
			ShowMajorGridLines = false}
		});

		//Adding the Spline Series to the chart for displaying high temperature
		chart.Series.Add(newSplineSeries(){
			ItemsSource=dataModel.HighTemperature,
			Label="High"
		});

		//Adding the Spline Series to the chart for displaying low temperature
		chart.Series.Add(newSplineSeries(){
			ItemsSource=dataModel.LowTemperature,
			Label="Low"
		});

		//Adding Chart Legend for the Chart
			chart.Legend=newChartLegend();
			his.Content=chart;
		}
	}

	public class DataModel
	{
		public ObservableCollectionHighTemperature;
		public ObservableCollectionLowTemperature;
		public ObservableCollectionPrecipitation;

		public DataModel()
		{
			HighTemperature=newObservableCollection();
			HighTemperature.Add(newChartDataPoint("Jan",42));
			HighTemperature.Add(newChartDataPoint("Feb",44));
			HighTemperature.Add(newChartDataPoint("Mar",53));
			HighTemperature.Add(newChartDataPoint("Apr",64));
			HighTemperature.Add(newChartDataPoint("May",75));
			HighTemperature.Add(newChartDataPoint("Jun",83));
			HighTemperature.Add(newChartDataPoint("Jul",87));
			HighTemperature.Add(newChartDataPoint("Aug",84));
			HighTemperature.Add(newChartDataPoint("Sep",78));
			HighTemperature.Add(newChartDataPoint("Oct",67));
			HighTemperature.Add(newChartDataPoint("Nov",55));
			HighTemperature.Add(newChartDataPoint("Dec",45));

			LowTemperature=newObservableCollection();
			LowTemperature.Add(newChartDataPoint("Jan",27));
			LowTemperature.Add(newChartDataPoint("Feb",28));
			LowTemperature.Add(newChartDataPoint("Mar",35));
			LowTemperature.Add(newChartDataPoint("Apr",44));
			LowTemperature.Add(newChartDataPoint("May",54));
			LowTemperature.Add(newChartDataPoint("Jun",63));
			LowTemperature.Add(newChartDataPoint("Jul",68));
			LowTemperature.Add(newChartDataPoint("Aug",66));
			LowTemperature.Add(newChartDataPoint("Sep",59));
			LowTemperature.Add(newChartDataPoint("Oct",48));
			LowTemperature.Add(newChartDataPoint("Nov",38));
			LowTemperature.Add(newChartDataPoint("Dec",29));

			Precipitation=newObservableCollection();
			Precipitation.Add(newChartDataPoint("Jan",3.03));
			Precipitation.Add(newChartDataPoint("Feb",2.48));
			Precipitation.Add(newChartDataPoint("Mar",3.23));
			Precipitation.Add(newChartDataPoint("Apr",3.15));
			Precipitation.Add(newChartDataPoint("May",4.13));
			Precipitation.Add(newChartDataPoint("Jun",3.23));
			Precipitation.Add(newChartDataPoint("Jul",4.13));
			Precipitation.Add(newChartDataPoint("Aug",4.88));
			Precipitation.Add(newChartDataPoint("Sep",3.82));
			Precipitation.Add(newChartDataPoint("Oct",3.07));
			Precipitation.Add(newChartDataPoint("Nov",2.83));
			Precipitation.Add(newChartDataPoint("Dec",2.8));
		}
	}
}
```

**[XAML]**

```xml
<chart:SfChart>
	<chart:SfChart.Legend>
		<chart:ChartLegend/>
	</chart:SfChart.Legend>

	<chart:SfChart.Title>
		<chart:ChartTitle Text="Weather Analysis"/>
	</chart:SfChart.Title>

	<chart:SfChart.PrimaryAxis>
		<chart:CategoryAxis>
			<chart:CategoryAxis.Title>
				<chart:ChartAxisTitle Text="Month"/>
			</chart:CategoryAxis.Title>
		</chart:CategoryAxis>
	</chart:SfChart.PrimaryAxis>
	<chart:SfChart.SecondaryAxis>
		<chart:NumericalAxis>
			<chart:NumericalAxis.Title>
				<chart:ChartAxisTitle Text="Month"/>
			</chart:NumericalAxis.Title>
		</chart:NumericalAxis>
	</chart:SfChart.SecondaryAxis>

	<chart:SfChart.Series>
		<chart:ColumnSeries   Label = "Low" ItemsSource = "{Binding Precipitation}">
			<chart:ColumnSeries.YAxis>
				<chart:NumericalAxis OpposedPosition="true"
					ShowMajorGridLines="false"/>
			</chart:ColumnSeries.YAxis>
		</chart:ColumnSeries>
		<chart:SplineSeries  Label = "High" ItemsSource =
			"{Binding HighTemperature}"/>
		<chart:SplineSeries  Label = "Low" ItemsSource =
			"{Binding LowTemperature}"/>
	</chart:SfChart.Series>
</chart:SfChart>
```
	
![chart](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/chart/gettingstarted/weatheranalysis.png)

#<a id="Gauge"></a>Gauge

**Introduction**

This section provides a quick overview for working with Essential Gauge for Xamarin.Forms. We will walk through the entire process of configuring a real world gauge.
You can also download the entire source code of this demo from [here](http://files2.syncfusion.com/Installs/v13.1.0.21/Samples/Xamarin/Gauge_GettingStarted.zip).

**Referencing Essential Studio components in your solution**

If you had acquired Essential Studio components through the Xamarin component store interface from within your IDE, then after adding the components to your Xamarin.iOS, Xamarin.Android and Windows Phone projects through the Component manager,  you will still need to manually reference the PCL (Portable Class Library) assemblies in the Xamarin.Forms PCL project in your solution. You can do this by manually adding the relevant PCL assembly references to your PCL project contained in the following path inside of your solution folder  

```
Components/syncfusionessentialstudio-version/lib/pcl/
```

Alternatively if you had downloaded Essential Studio from Syncfusion.com or through the Xamarin store web interface then all assembly references need to be added manually.  

After installing Essential Studio for Xamarin, all the required assemblies can be found in the installation folders, typically
	
**{Syncfusion Installed location}\Essential Studio\13.1.0.21\lib**

_Eg: C:\Program Files (x86)\Syncfusion\Essential Studio\13.1.0.21\lib_

or after downloading through the Xamarin store web interface, all the required assemblies can be found in the below folder

**{download location}\syncfusionessentialstudio-version\lib**

You can then add the assembly references to the respective projects as shown below

**PCL project**

```
pcl\Syncfusion.SfGauge.XForms.dll 
```

**Android project**

```
android\Syncfusion.SfGauge.Android.dll
android\Syncfusion.SfGauge.XForms.Android.dll
```

**iOS project**

```
ios\Syncfusion.SfGauge.iOS.dll 
ios\Syncfusion.SfGauge.XForms.iOS.dll
ios\Syncfusion.SfGauge.XForms.dll
```

**Windows Phone project**

```
wp8\Syncfusion.SfGauge.WP8.dll
wp8\Syncfusion.SfGauge.XForms.WinPhone.dll
```

Note: Essential Gauge for Xamarin is compatible with Xamarin.Forms v1.2.3.6257.

Currently an additional step is required for Windows Phone and iOS projects. We need to create an instance of the Gauge custom renderer as shown below.

Create an instance of SfGaugeRenderer in the MainPage constructor of the Windows Phone project as shown below

```csharp
public MainPage()
{
	new SfGaugeRenderer ();
	...  
}
```

Create an instance of SfGaugeRenderer in the FinishedLaunching overridden method of the AppDelegate class in the iOS Project as shown below

```csharp
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
	...
	new SfGaugeRenderer ();
	...
}
```

**Adding and configuring the gauge**

The gauge control can be configured entirely in C# code or using XAML markup.

Create an instance of SfCircularGauge

**[C#]**

```csharp

   SfCircularGauge circularGauge = new SfCircularGauge();

```

**[XAML]**

```xml

<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns=http://xamarin.com/schemas/2014/forms
	xmlns:local="clr-
	namespace:Syncfusion.SfGauge.XForms;assembly=Syncfusion.SfGauge.XForms"
	xmlns:x=http://schemas.microsoft.com/winfx/2009/xaml
	x:Class="GaugeGettingStarted.Sample">
	<ContentPage.Content>
		<local:SfCircularGauge>
		</local:SfCircularGauge>
	</ContentPage.Content>
</ContentPage>
```
	
**Insert a Scale**

The next step is to add one of more scales.

**[C#]**

```csharp
SfCircularGauge circularGauge = new SfCircularGauge();

// Add a scale

Scale scale = new Scale();
scale.StartValue= 0;
scale.EndValue =100;
scale.Interval = 10;
scale.StartAngle =135;
scale.SweepAngle =270;
scale.RimThickness = 10;
scale.RimColor = Color.FromHex("#FFFB0101");
scale.MinorTicksPerInterval = 3;

circularGauge.Scales.Add(scale);
```

**[XAML]**

```xml
<gauge:SfCircularGauge>
	<gauge.SfCircularGauge.Scales>
		<gauge.Scale StartValue="0"
			EndValue="100" Interval="10"
			StartAngle="135" SweepAngle="230"
			RimColor="#FFFB0101" RimThickness="10"  />
	</gauge.SfCircularGauge.Scales>
</gauge:SfCircularGauge>
```

**Specify Ranges**

We can improve the readability of data by including ranges that quickly show when values fall within specific ranges.

**[C#]**

```csharp
... 
Range range = new Range();
range.StartValue = 0;
range.EndValue = 80;
range.Color = Color.FromHex("#FF777777");
range.Thickness = 10;

scale.Ranges.Add(range);
```

**[XAML]**

```xml
<local:SfCircularGauge>
	<local:SfCircularLocal:Scales>
		<local:Scale StartValue="0" EndValue="100"
			Interval="10" StartAngle="135"
			SweepAngle="230" RimColor="#FFFB0101"
			RimThickness="10" >
			<local:Scale.Ranges>
				<local:Range StartValue="0" EndValue="80" Color="#FF777777" Thickness="15" />
			</local:Scale.Ranges>
		</local:Scale>
	</local:SfCircularLocal:Scales>
</local:SfCircularGauge>
```

**Add a Needle Pointer**

We will now create a needle pointer and associate it with a scale to display the current value.

**[C#]**

```csharp
NeedlePointer needlePointer = new NeedlePointer();
needlePointer.Value = 60;
needlePointer.Color = Color.White;
needlePointer.KnobColor = Color.White;
needlePointer.Thickness = 5;
needlePointer.KnobRadius = 20;
needlePointer.LengthFactor = 0.8;

scale.Pointers.Add(needlePointer);
...
```

**[XAML]**

```xml
<local:SfCircularGauge>
	<local:SfCircularLocal:Scales>
		<local:Scale StartValue="0" EndValue="100"
			Interval="10" StartAngle="135"
			SweepAngle="230" RimColor="#FFFB0101"
			RimThickness="10" >
			<local:Scale.Ranges>
				<local:Range StartValue="0" EndValue="80" Color="#FF777777" Thickness="15" />
			</local:Scale.Ranges>
			<local:Scale.Pointers>
				<local:NeedlePointer Value="60" LengthFactor="0.8"
					Color="White" Thickness="5"
					KnobColor="White" KnobRadius="20"  />
			</local:Scale.Pointers>
		</local:Scale>
	</local:SfCircularLocal:Scales>
</local:SfCircularGauge>
```

**Add a Range Pointer**

A range pointer provides an alternative way of indicating the current value.

**[C#]**

```csharp
RangePointer rangePointer = new RangePointer();
rangePointer.Value = 60;
rangePointer.Color = Color.FromHex("#FFA9A9A9");
rangePointer.Thickness = 10;

scale.Pointers.Add(rangePointer);
...
```

**[XAML]**

```xml
<local:SfCircularGauge>
	<local:SfCircularLocal:Scales>
		<local:Scale StartValue="0" EndValue="100"
			Interval="10" StartAngle="135"
			SweepAngle="230" RimColor="#FFFB0101"
			RimThickness="10" >
			<local:Scale.Ranges>
				<local:Range StartValue="0" EndValue="80" Color="#FF777777" Thickness="15" />
			</local:Scale.Ranges>
			<local:Scale.Pointers>
				<local:NeedlePointer Value="60" LengthFactor="0.8"
					Color="White" Thickness="5"
					KnobColor="White" KnobRadius="20"  />
				<local:RangePointer Value="60" Color="White"
						Thickness="10" />
			</local:Scale.Pointers>
		</local:Scale>
	</local:SfCircularLocal:Scales>
</local:SfCircularGauge>
```

![gauge](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/gauge/getting-started.png)

#<a id="DigitalGauge"></a>Digital Gauge

**Introduction**

Essential Digital Gauge for Xamarin.Forms lets you visualize alpha and numeric values over a digital gauge frame. The appearance of the digital gauge can be fully customized to seamlessly integrate with your applications.

This section provides a quick overview for working with Essential Digital Gauge for Xamarin.Forms. We will walk through the entire process of creating a real world Digital gauge.

## Adding Syncfusion assembly reference

Add the required Syncfusion assembly references to the respective projects as explained below.

All the required assemblies can be found in the installation folders, typically

**{Syncfusion Installed location}\Essential Studio\13.1.0.21\lib**

_Eg: C:\Program Files (x86)\Syncfusion\Essential Studio\13.1.0.21\lib_

**PCL project**

```
XForms\Syncfusion.SfGauge.XForms.dll 
```

**Android project**

```
Android\Syncfusion. SfGauge.Andriod.dll
Android\Syncfusion.SfGauge.XForms.Andriod.dll
```

**iOS project**

```
iOS\Syncfusion.SfGauge.iOS.dll 
iOS\Syncfusion.SfGauge.XForms.iOS.dll
```

**Windows Phone project**

```
WinPhone\Syncfusion.SfGauge.WP8.dll
WinPhone\Syncfusion SfGauge.XForms.WinPhone.dll
```

Note: Essential Digital Gauge for Xamarin is compatible with Xamarin Forms 1.2.2.0.

Currently an additional step is required for Windows Phone and iOS projects. We need to create an instance of the Digital Gauge custom renderer as mentioned below.

Create an instance of the SfDigitalGaugeRenderer in MainPage constructor in Windows Phone project as shown below

     public MainPage()

       {

             new SfDigitalGaugeRenderer ();

             ...  

      }

Create an instance of the SfDigitalGaugeRenderer in FinishedLaunching overridden method of AppDelegate class in iOS Project as shown below

	public override bool FinishedLaunching(UIApplication app, NSDictionary options)

        {

            ...

            new SfDigitalGaugeRenderer ();

             ...

       }

**Adding and configuring the DigitalGauge**

The digitalgauge control can be configured entirely in C# code or using XAML markup.

Create an instance of SfDigitalrGauge

**[C#]**

```csharp
_//We have to update App.cs source this file._
usingSyncfusion.SfGauge.XForms;
usingSystem;  
usingSystem.Collections.Generic;  
usingSystem.Linq;  
usingSystem.Text;  
usingXamarin.Forms;  
usingSystem.Collections.ObjectModel;publicstaticPage GetMainPage(){         SfDigitalGauge digitalGauge = newSfDigitalGauge();   returnnewContentPage   {       Content = digitalGauge,   };} 

```

**[XAML]**

```xml
_//we have to use this this in App.CS source.//publicstaticPage GetMainPage()//{//    return Sample();//}<?xml version="1.0" encoding="UTF-8"?>_
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"  
	xmlns:local="clr-namespace:Syncfusion.XForms.SfGauge; assembly=Syncfusion..XForms.SfGauge "  
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"x:Class="DigitalGaugeGettingStarted.Sample">
	<ContentPage.Content>  
		<local:SfDigitalGauge> 
		</local:SfDigitalGauge>
	</ContentPage.Content>  
</ContentPage>
```

## Configure the Digital Gauge Properties

The next step is to add Digital Gauge properties in application/

**[C#]**

```charp
SfDigitalGauge DigitalGauge = newSfDigitalGauge();
digitalGauge1.Value = "SYNCFUSION";
digitalGauge1.CharacterType = CharacterType.SegmentSeven;
digitalGauge1.CharacterHeight = 58;
digitalGauge1.CharacterWidth= 29;digitalGauge1.SegmentThickness = 3;
digitalGauge1.DisabledColorOpacity = 30;
digitalGauge1.BackgroundColor = Color.FromRgb (235, 235, 235);
digitalGauge1.CharacterForeColor = Color.FromRgb (20,108,237);
digitalGauge1.CharacterDisabledColor = Color.FromRgb (20,108,237); 
```

**[XAML]**

```xml
<digitalGauge1:SfDigitalGauge Value="SYNCFUSION" CharacterHeight="58" CharacterWidth ="29" SegmentThickness="3" DisabledColorOpacity="30" BackgroundColor="#EBEBEB" CharacterType= CharacterType.SegmentSeven        CharacterForeColor ="#146CED" CharacterDisabledColor ="#146CED"> 
</digitalGauge1:SfDigitalGauge >
```

![digitalgauge](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/digitalgauge/digitalgauge.png)

#<a id="LinearGauge"></a>Linear Gauge

**Introduction**

Essential Linear Gauge for Xamarin.Forms lets you visualize values on a linear scale. The appearance of the linear gauge can be fully customized to seamlessly integrate with your applications.

This section provides a quick overview for working with Essential Linear Gauge for Xamarin.Forms. We will walk through the entire process of creating a real world gauge.

## Adding Syncfusion assembly reference

Add the required Syncfusion assembly references to the respective projects as explained below.

All the required assemblies can be found in the installation folders, typically

**{Syncfusion Installed location}\Essential Studio\13.1.0.21\lib**

_Eg: C:\Program Files (x86)\Syncfusion\Essential Studio\13.1.0.21\lib_

**PCL project**

```
XForms\Syncfusion.SfGauge.XForms.dll 
```

**Android project**

```
Android\Syncfusion.SfGauge.Andriod.dll
Android\Syncfusion.SfGauge.XForms.Andriod.dll
```

**iOS project**

```
iOS\Syncfusion.SfGauge.iOS.dll 
iOS\Syncfusion.SfGauge.XForms.iOS.dll
```

**Windows Phone project**

```
WinPhone\Syncfusion SfGauge.WP8.dll
WinPhone\Syncfusion SfGauge.XForms.WinPhone.dll
```

Note: Essential Linear Gauge for Xamarin is compatible with Xamarin Forms 1.2.2.0.

Currently an additional step is required for Windows Phone and iOS projects. We need to create an instance of the Linear Gauge custom renderer as mentioned below.

Create an instance of the SfLinearGaugeRenderer in MainPage constructor in Windows Phone project as shown below

     public MainPage()

       {

             new SfLinearGaugeRenderer ();

             ...  

      }

Create an instance of the SfLinearGaugeRenderer in FinishedLaunching overridden method of AppDelegate class in iOS Project as shown below

	public override bool FinishedLaunching(UIApplication app, NSDictionary options)

        {

            ...

            new SfLinearGaugeRenderer ();

             ...

       }

**Adding and configuring the gauge**

The Linear gauge control can be configured entirely in C# code or using XAML markup.

Create an instance of SfLinearGauge

**[C#]**

```charp
_// We have to update App.cs source this file._
usingSyncfusion.SfGauge.XForms;  
usingSystem;  
usingSystem.Collections.Generic;  
usingSystem.Linq;  
usingSystem.Text;  
usingXamarin.Forms;  
usingSystem.Collections.ObjectModel;
publicstaticPage GetMainPage()
{
SfLinearGauge linearGauge = newSfLinearGauge();
returnnewContentPage {Content = linearGauge,};
} 
```

**[XAML]**

```xml
_//we have to use this this in App.CS source.**//publicstaticPage GetMainPage()//{//    return Sample();//}<?xml version="1.0" encoding="UTF-8"?>_
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"  
	xmlns:local="clr-namespace:Syncfusion.XForms.SfGauge;assembly=Syncfusion.XForms.SfGauge "  
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"x:Class="LinearGaugeGettingStarted.Sample">
	<ContentPage.Content>  
		<local:SfLinearGauge> 
		</local:SfLinearGauge>
	</ContentPage.Content>  
</ContentPage> 
```

## Insert a Scale

The next step is to add one of more scales.

**[C#]**

```charp
linearGauge=newSfLinearGauge();  
linearGauge.BackgroundColor=Color.White;  
linearGauge.Orientation=Orientation.OrientationVertical;  
_//Scale_  
ObservableCollection<LinearScale>scales=newObservableCollection<LinearScale>();  
LinearScalescale=newLinearScale();  
scale.MinimumValue=0;  
scale.MaximumValue=100;  
scale.Interval=20;  
scale.ScaleBarLength=100;  
scale.ScaleBarColor=Color.FromRgb(250,236,236);  
scale.LabelColor=Color.FromRgb(84,84,84);  
scale.MinorTicksPerInterval=1;  
scale.ScaleBarSize=13;  
scale.ScalePosition=ScalePosition.BackWard;  
. . .   
```

**[XAML]**

```xml
<gauge:SflinearGauge>
	<gauge.SfLinearGauge.Scales>
		<gauge.ScaleMinimumValue="0" MaximumValue="100"ScaleBarLength="100" LablePostfix="%"ScaleBarColor="230" ScaleBarColor="#EDEDED"LableColor="#545454" MinorTicksPerInterval="1" ScaleBarSize="13" />
	</gauge.SfLinearGauge.Scales> 
</gauge:SfLinearGauge>
```

## Specify Range

We can improve the readability of data by including ranges that quickly show when values fall within specific ranges.

**[C#]**

```charp
_//Range_  
LinearRangerange=newLinearRange();  
range.StartValue=0;  
range.EndValue=50;  
range.Color=Color.FromRgb(234,248,249);  
range.StartWidth=10;  
range.EndWidth=10;  
range.Offset=-0.17;  
scale.Ranges.Add(range);
```

**[XAML]**

```xml
<local:SfLinearGauge>
	<local:SfLinearGauge:Scales>
		<local:ScaleMinimumValue="0" MaximumValue="100"ScaleBarLength="100" LablePostfix="%"ScaleBarColor="230" ScaleBarColor="#EDEDED"LableColor="#545454" MinorTicksPerInterval="1" ScaleBarSize="20" >
			<local:Scale.Ranges>
				<local:Range StartValue="0" EndValue="50" Color="#3288C6" Offset="-0.3" />
			</local:Scale.Ranges>
		</local:Scale>
	</local:SfLinearGauge:Scales>
</local:SfLinearGauge> 
```

## Add a Pointer

We will now create a pointer and associate it with a scale.

**[C#]**

```charp
List<LinearPointer>pointers=newList<LinearPointer>();  
_//SymbolPointer_  
SymbolPointersymbolPointer=newSymbolPointer();  
symbolPointer.Value=50;  
symbolPointer.Offset=0.0;  
symbolPointer.Thickness=3;  
symbolPointer.Color=Color.FromRgb(65,77,79);  
  
_//BarPointer_  
BarPointerrangePointer=newBarPointer();  
rangePointer.Value=50;  
rangePointer.Color=Color.FromRgb(206,69,69);  
rangePointer.Thickness=10;  
pointers.Add(symbolPointer);  
pointers.Add(rangePointer);  
... scale.Pointers=pointers;  
scales.Add(scale);  
linearGauge.Scales=scales;
...
```

**[XAML]**

```xml
<local:SfLinearGauge>
	<local:SflinearGauge:Scales>
		<local:Scale MinimumValue="0" MaximumValue="100" ScaleBarLength="100" LablePostfix="%"ScaleBarColor="230" ScaleBarColor="#EDEDED" LableColor="#545454" MinorTicksPerInterval="1" ScaleBarSize="20" >
			<local:Scale.Ranges>
				<local:Range StartValue="0" EndValue="50" Color="#3288C6"Offset="-0.3" />
			</local:Scale.Ranges>
			<local:Scale.Pointers>
				<local:SymbolPointer Value="50" Color="Red" Offset="0.3" />
				<local:BarPointerValue="50" Color="White"/>
			</local:Scale.Pointers>
		</local:Scale>
	</local:SfLinearGauge:Scales>
</local:SfLinearGauge >
```

## Add a Minor and Major Ticksettings

A minor and major ricksettings provides a way of indicating the current value.

**[C#]**

```charp
_//MinorTickssetting_  
LinearTickSettingsminor=newLinearTickSettings();  
minor.Length=10;  
minor.Color=Color.FromRgb(175,175,175);  
minor.Thickness=1;  
scale.MinorTickSettings=minor;  
  
_//MajorTickssetting_  
LinearTickSettingsmajor=newLinearTickSettings();  
major.Length=10;  
major.Color=Color.FromRgb(175,175,175);  
major.Thickness=1;  
scale.MajorTickSettings=major;  
```

**[XAML]**

```xml
<local:SfLinearGauge>
	<local:SfLinearGauge:Scales>
		<local:Scale MinimumValue="0" MaximumValue="100" ScaleBarLength="100" LablePostfix="%" ScaleBarColor="230" ScaleBarColor="#EDEDED" LableColor="#545454" MinorTicksPerInterval="1" ScaleBarSize="20" >
			<local:Scale.Ranges>
				<local:Range StartValue="0" EndValue="50" Color="#3288C6" Offset="-0.3" />
			</local:Scale.Ranges>
			<local:Scale.Pointers>
				<local:SymbolPointer Value="50" Color="Red" Offset="0.3" />
				<local:BarPointer Value="50" Color="White"/>
			</local:Scale.Pointers>
			<local:Scale.MinorTickSettings>
				<local:LinearTickSettings Length="10" Color="#4B4B4B" Thickness="1" />
			</local:Scale.MinorTickSettings>
			<local:Scale.MajorTickSettings>
				<local:LinearTickSettings Length="10" Color="#4B4B4B" Thickness="1" />
			</local:Scale.MajorTickSettings>
		</local:Scale>
	</local:SfLinearGauge:Scales>
</local:SfLinearGauge>
```

![LinearGauge](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/lineargauge/lineargauge.png)


#<a id="TreeMap"></a>TreeMap

**Overview**

This section provides a quick overview for working with Essential Treemap for Xamarin.Forms. We will walk through the entire process of creating a real world Treemap.

The goal of this tutorial is to visualize population growth across continents.
You can also download the entire source code of this demo from [here](http://files2.syncfusion.com/Installs/v13.1.0.21/Samples/Xamarin/TreeMap_GettingStarted.zip).

**Referencing Essential Studio components in your solution**

If you had acquired Essential Studio components through the Xamarin component store interface from within your IDE, then after adding the components to your Xamarin.iOS, Xamarin.Android and Windows Phone projects through the Component manager,  you will still need to manually reference the PCL (Portable Class Library) assemblies in the Xamarin.Forms PCL project in your solution. You can do this by manually adding the relevant PCL assembly references to your PCL project contained in the following path inside of your solution folder  

```
Components/syncfusionessentialstudio-version/lib/pcl/
```

Alternatively if you had downloaded Essential Studio from Syncfusion.com or through the Xamarin store web interface then all assembly references need to be added manually.  

After installing Essential Studio for Xamarin, all the required assemblies can be found in the installation folders, typically
	
**{Syncfusion Installed location}\Essential Studio\13.1.0.21\lib**

_Eg: C:\Program Files (x86)\Syncfusion\Essential Studio\13.1.0.21\lib_

or after downloading through the Xamarin store web interface, all the required assemblies can be found in the below folder

**{download location}\syncfusionessentialstudio-version\lib**

You can then add the assembly references to the respective projects as shown below

**PCL project**

```
pcl\Syncfusion.SfTreeMap.XForms.dll 
```

**Android project**

```
android\Syncfusion.SfTreeMap.Android.dll
android\Syncfusion.SfTreeMap. XForms.Android.dll
```

**iOS project**
```
ios\Syncfusion.SfTreeMap.iOS.dll 
ios\Syncfusion.SfTreeMap.XForms.iOS.dll
ios\Syncfusion.SfTreeMap.XForms.dll
```

**Windows Phone project**

```
wp8\Syncfusion.SfTreeMap.WP8.dll
wp8\Syncfusion.SfTreeMap.XForms.WinPhone.dll
```

Note: Essential TreeMap for Xamarin is compatible with Xamarin.Forms v1.2.3.6257.

Currently an additional step is required for Windows Phone and iOS projects. We need to create an instance of the TreeMap custom renderer as shown below.

Create an instance of SfTreeMapRenderer in the MainPage constructor of the Windows Phone project as shown below

```csharp
public MainPage()
{
	new SfTreeMapRenderer ();
     ...  
}
```

Create an instance of SfTreeMapRenderer in the FinishedLaunching overridden method of the AppDelegate class in iOS Project as shown below

```csharp
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
	new SfTreeMapRenderer ();
	...  
}
```

**Initializing the TreeMap**

The Treemap control can be configured entirely in C# code or using XAML markup.

The first step is to create a TreeMap object

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns=http://xamarin.com/schemas/2014/forms
xmlns:local="clr-
namespace:Syncfusion.SfTreeMap.XForms;assembly=Syncfusion.SfTreeMap.XForms"
xmlns:x=http://schemas.microsoft.com/winfx/2009/xaml
x:Class="TreeMapGettingStarted.Sample" BackgroundColor=îBlackî>
	<ContentPage.Content >
		<local:SfTreeMap x:Name="treeMap">
		</local:SfTreeMap>
	</ContentPage.Content>
</ContentPage>
```

```csharp
public static Page GetMainPage()
{
        SfTreeMap treeMap = new SfTreeMap();
        return new ContentPage {
		BackgroundColor = Color.Black,
		Content = treeMap,
	};
}
```

**Populating TreeMap Items**

The TreeMap accepts a collection of TreeMapItems as input.

**[XAML]**

```xml
// BindingContext is set for the content page class.
// DataModel model = new DataModel();
//..
//..
//this.BindingContext = model;

<local:SfTreeMap x:Name="treeMap" Items = "{Binding TreeMapItems}">
</local:SfTreeMap>    
```

**[C#]**
```csharp
public class DataModel : BindableObject
{
	public static readonly BindableProperty TreeMapItemsProperty =
		BindableProperty.Create>(p =>
			p.TreeMapItems, null, BindingMode.TwoWay, null, null, null, null);

	public ObservableCollection TreeMapItems
	{
		get { return (ObservableCollection)GetValue(TreeMapItemsProperty); }
		set { SetValue(TreeMapItemsProperty, value); }
	}

	public DataModel()
	{
		this.TreeMapItems = new ObservableCollection();

		TreeMapItems.Add(newTreeMapItem() { Label = "Indonesia", ColorWeight = 3,Weight = 237641326 });
		TreeMapItems.Add(newTreeMapItem() { Label = "Russia", ColorWeight = 2, Weight = 152518015 });
		TreeMapItems.Add(newTreeMapItem() { Label = "United States", ColorWeight = 4, Weight = 315645000 });
		TreeMapItems.Add(newTreeMapItem() { Label = "Mexico", ColorWeight = 2, Weight = 112336538 });
		TreeMapItems.Add(newTreeMapItem() { Label = "Nigeria", ColorWeight = 2, Weight = 170901000 });
		TreeMapItems.Add(newTreeMapItem() { Label = "Egypt", ColorWeight = 1, Weight = 83661000 });
		TreeMapItems.Add(newTreeMapItem() { Label = "Germany", ColorWeight = 1, Weight = 81993000 });
		TreeMapItems.Add(newTreeMapItem() { Label = "France", ColorWeight = 1, Weight = 65605000 });
		TreeMapItems.Add(newTreeMapItem() { Label = "UK", ColorWeight = 1, Weight = 63181775 });
	}
}

SfTreeMap treeMap = new SfTreeMap();
DataModel model = new DataModel();
treeMap.Items = model.TreeMapItems;
```

Grouping of TreeMap Items using Levels

You can group TreeMap Items using two types of levels

1. TreeMap Flat Level
2. TreeMap Hierarchical Level


**Customizing TreeMap Appearance using ranges**

Fill colors for value ranges can be specified using From and To properties.

**[XAML]**

```xml
<local:SfTreeMap x:Name="treeMap" Items = "{Binding TreeMapItems}">
	<local:SfTreeMap.LeafItemColorMapping>
		<local:RangeColorMapping>
			<local:RangeColorMapping.Ranges>
				<local:Range LegendLabel = "1 % Growth" From = "0" To = "1" Color =  "#77D8D8"  />
				<local:Range LegendLabel = "2 % Growth" From = "0" To = "2" Color =  "#AED960"  />
				<local:Range LegendLabel = "3 % Growth" From = "0" To = "3" Color =  "#FFAF51"  />
				<local:Range LegendLabel = "4 % Growth" From = "0" To = "4" Color =  "#F3D240"  />
			</local:RangeColorMapping.Ranges>
		</local:RangeColorMapping>
	</local:SfTreeMap.LeafItemColorMapping>
</local:SfTreeMap>
```

**[C#]**

```csharp
... 
ObservableCollection ranges = new ObservableCollection();
ranges.Add(newRange() { LegendLabel="1 % Growth", From = 0, To = 1, Color = Color.FromHex("#77D8D8") });
ranges.Add(newRange() { LegendLabel = "2 % Growth", From = 0, To = 2, Color = Color.FromHex("#AED960") });
ranges.Add(newRange() { LegendLabel = "3 % Growth", From = 0, To = 3, Color = Color.FromHex("#FFAF51") });
ranges.Add(newRange() { LegendLabel = "4 % Growth", From = 0, To = 4, Color = Color.FromHex("#F3D240") });

treeMap.LeafItemColorMapping = new RangeColorMapping (){ Ranges = ranges };
```

**Leaf level TreeMap item customization**

The Leaf level TreeMap items can be customized using LeafItem Setting.

**[XAML]**

```xml
<local:SfTreeMap x:Name="treeMap" Items = "{Binding TreeMapItems}">
	<!-- ... -->
	<local:SfTreeMap.LeafItemSettings>
		<local: LeafItemSettings BorderWidth="1" BorderColor="White"  />
	</local:SfTreeMap.LeafItemSettings >
</local:SfTreeMap>
```

**[C#]**

```csharp
...
LeafItemSettings leafSetting = new LeafItemSettings();
leafSetting.BorderWidth = 1;
leafSetting.BorderColor = Color.White;
    
treeMap.LeafItemSettings = leafSetting;
```

**Enable Legend**

Displaying legends if only appropriate for TreeMaps whose leaf nodes have been colored using RangeColorMapping. You can set ShowLegend property value to "True"to make the legend visible.

**Label for Legends**

You can customize the labels of the legend items using the LegendLabel property of RangeColorMapping.

**[XAML]**

```xml
<local:SfTreeMap.LegendSettings>
	<local:LegendSettings  ShowLegend ="true" IconSize="15,15" Size="350,70"  />
</local:SfTreeMap.LegendSettings>
```

**[C#]**

```csharp
...
LegendSettings legendSettings = new LegendSettings();
legendSettings.ShowLegend= true;
legendSettings.IconSize = new Size(15, 15);
legendSettings.Size = new Size (350, 70);

treeMap.LegendSettings= legendSettings;
```

![treemap](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/tree-map/getting-started/treemap.png)

#<a id="Barcode"></a>Creating your first Barcode in Xamarin.Forms

Essential Barcode for Xamarin Forms provides a perfect approach to encode texts using supported symbol types that comprises one dimensional barcodes and two dimensional barcodes. The basic structure of a barcode consists of one or more data characters, optionally one or two check characters, a start pattern as well as a stop pattern.

This section explains how to configure a barcode for Xamarin Forms application. The following screenshot illustrates the final output of barcode on iOS, Android and Windows Phone devices. You can also download the entire source code of this demo [here](http://files2.syncfusion.com/Installs/v13.1.0.21/Samples/Xamarin/BarcodeGettingStarted.zip).

![Barcode](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/barcode/QR_code.png)

**Referencing Essential Studio components in your solution**

When you acquire Essential Studio components through the Xamarin Component Store interface from your IDE, after adding the components to your Xamarin.iOS, Xamarin.Android and Windows Phone projects through the Component Manager, you have to manually reference the PCL (Portable Class Library) assemblies in the Xamarin.Forms PCL Project in your solution. You can do this manually by adding the relevant PCL assembly references to your PCL project contained in the following path inside your solution folder.

```
Components/syncfusionessentialstudio-version/lib/pcl/
```

Alternatively, when you download Essential Studio from Syncfusion.com or through the Xamarin Store web interface, add all the assembly references manually.  

After installing Essential Studio for Xamarin, you can find all the required assemblies in the installation folders, typically
	
**{Syncfusion Installed location}\Essential Studio\13.1.0.21\lib**

_Eg: C:\Program Files (x86)\Syncfusion\Essential Studio\13.1.0.21\lib_

Otherwise, after downloading through the Xamarin Store web interface, you can find all the required assemblies in the following folder

**{download location}\syncfusionessentialstudio-version\lib**

Then, you can add the assembly references to the respective projects as follows.

**PCL project**

```
pcl\Syncfusion.SfBarcode.XForm.dll 
```

**Android project**

```
android\Syncfusion.SfBarcode.Android.dll
android\Syncfusion.SfBarcode.XForms.Android.dll
```

**iOS project**

```
ios\Syncfusion.SfBarcode.iOS.dll 
ios\Syncfusion.SfBarcode.XForms.iOS.dll
ios\Syncfusion.SfBarcode.XForm.dll
```

**Windows Phone project**

```
wp8\Syncfusion.SfBarcode.WP8.dll
wp8\Syncfusion.SfBarcode.XForms.WinPhone.dll
```

Note: Essential Barcode for Xamarin is compatible with Xamarin.Forms 1.3.4.6332.

Currently an additional step is required for configuring Windows Phone and iOS projects. We need to create an instance of the Barcode custom renderer as shown below.

Create an instance of SfBarcodeRenderer in the MainPage constructor of the Windows Phone project as shown below

```csharp
public MainPage()
{
	new SfBarcodeRenderer();
	...  
}
```

Create an instance of SfBarcodeRenderer in FinishedLaunching overridden method of AppDelegate class in the iOS Project as shown below

```csharp
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
	new SfBarcodeRenderer();
	...  
}
```

**Adding and configuring the Barcode**

The Barcode control can be configured entirely in C# code or using XAML markup.

Add reference to SFBarcode such as follows

**[C#]**

```csharp
using Syncfusion.SfBarcode.XForms;
```

**[XAML]**

```xml
xmlns:syncfusion="clr-namespace:Syncfusion.SfBarcode.XForms;assembly=Syncfusion.SfBarcode.XForms"
```

Create an instance of SfBarcode in XAML or code-behind using the reference of SfBarcode.

**[C#]**

```csharp
SfBarcode barcode = new SfBarcode();
```

**[XAML]**

```xml
<syncfusion:SfBarcode/>
```

Then, you can assign the text that you want to encode.

**[C#]**

```csharp
barcode.Text = "www.wikipedia.org";
```

**[XAML]**

```xml
<syncfusion:SfBarcode Text="www.wikipedia.org"/>
```

Specify the required symbology to encode the given text. By default, the given text is encoded using Code 39 symbology.

**[C#]**

```csharp
barcode.Symbology = BarcodeSymbolType.QRCode;
```

**[XAML]**

```xml
<syncfusion:SfBarcode Text="www.wikipedia.org" Symbology="QRCode"/>
```

For customizing the barcode, initialize the settings of corresponding barcode symbology.

**[C#]**

```csharp
SfQRBarcodeSettings settings = new SfQRBarcodeSettings();
settings.XDimension = 6;
barcode.SymbologySettings = settings;
```

**[XAML]**

```xml
<syncfusion:SfBarcode Text="www.wikipedia.org" Symbology="QRCode">
    <syncfusion:SfBarcode.SymbologySettings>
      <syncfusion:SfQRBarcodeSettings XDimension="6"/>
    </syncfusion:SfBarcode.SymbologySettings>
</syncfusion:SfBarcode>
```

Finally, the barcode is generated as displayed in the following screenshot for the following code example.

**[C#]**

```csharp
public SamplePage()
{
      InitializeComponent();
      SfBarcode barcode = new SfBarcode();
      barcode.BackgroundColor = Color.Gray;
      barcode.Text = "www.wikipedia.org";
      barcode.Symbology = BarcodeSymbolType.QRCode;
      SfQRBarcodeSettings settings = new SfQRBarcodeSettings();
      settings.XDimension = 6;
      barcode.SymbologySettings = settings;
      this.Content = barcode;
}
```

**[XAML]**

```xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:syncfusion="clr-namespace:Syncfusion.SfBarcode.XForms;assembly=Syncfusion.SfBarcode.XForms"
             x:Class="BarcodeGettingStarted.SamplePage">
  <syncfusion:SfBarcode BackgroundColor="Gray" Text="www.wikipedia.org" Symbology="QRCode">
    <syncfusion:SfBarcode.SymbologySettings>
      <syncfusion:SfQRBarcodeSettings XDimension="6"/>
    </syncfusion:SfBarcode.SymbologySettings>
  </syncfusion:SfBarcode>
</ContentPage>
```
	
![Barcode](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/barcode/QR_code.png)

#<a id="XlsIO"></a>XlsIO

Essential XlsIO for Xamarin is a .NET PCL library that can be used to create and modify Microsoft Excel documents from within Xamarin.iOS, Xamarin.Android and Xamarin.Forms applications.

**Supported Features**

- Charts for data visualization
- Conditional Formatting
- Data Validation
- Tables
- Importing XML data
- Importing Business Objects
- Formulas
- Template Marker
- Auto-Shapes
- Cells Formatting
- Cell Grouping
- Data Filtering
- Data Sorting
- Find Data
- Comments
- HTML Conversion
- Named Ranges
- Number Formats
- Page settings
- Page breaks
- Header and footer images
- R1C1 Reference Mode
- Re-calculation
- R1C1 Formulas
- Dis-contiguous Named Ranges
- Hyperlinks
- Freeze panes
- Sheet Tab color RGB
- Hide rows and columns

**Getting Started**

The following steps demonstrate how to create a simple excel document in a Xamarin.Forms project using Essential XlsIO. You can also download the entire source code of this demo from [here](http://files2.syncfusion.com/Installs/v12.2.0.40/Samples/Xamarin/XlsIO_GettingStarted.zip).

1. Create new Xamarin.Forms portable project.

2. Next, you need to reference Essential Studio components in your solution. 
   XlsIO is packaged as a portable class library so currently there is no way to add reference to it from within the Xamarin component store IDE interface. You would need to obtain the required assemblies either through the Xamarin component store  web interface or from Syncfusion.com. Typically you would add reference to XlsIO only in the PCL project of your Xamarin.Forms application. The required assembly references are

	```
	Syncfusion.Compression.Portable.dll
	Syncfusion.XlsIO.Portable.dll
	```
	Note: If you had already referenced one of our UI components (Chart, Gauge or TreeMap) components from within the Xamarin component store IDE interface then the XlsIO assembly has already been downloaded and available in your solution folder, You can then manually add references from that folder.

	```
	Components/syncfusionessentialstudio-version/lib/pcl/
	```		

3. Use the following C# code to generate a simple excel file using Essential XlsIO

	```csharp
	//Instantiate excel engine
	ExcelEngine excelEngine = new ExcelEngine();

	//Excel application
	IApplication application = excelEngine.Excel;
	application.DefaultVersion = ExcelVersion.Excel2013;

	//A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
	//The new workbook will have 1 worksheet
	IWorkbook workbook = application.Workbooks.Create(1);

	//The first worksheet object in the worksheets collection is accessed.
	IWorksheet sheet = workbook.Worksheets[0];
	sheet.Range["A1"].Text = "Hello World!";
	workbook.Version = ExcelVersion.Excel2013;

	//Saving workbook as stream
	MemoryStream stream = new MemoryStream();
	workbook.SaveAs(stream);

	//Closing workbook
	workbook.Close();

	//Disposing excel engine
	excelEngine.Dispose();
	```

**Screenshots**

![XlsIO]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/XlsIO/gettingstarted.png )

#<a id="DocIO"></a>DocIO

Essential DocIO for Xamarin is a .NET PCL library that can be used to read and write Microsoft Word documents from within Xamarin.iOS, Xamarin.Android and Xamarin.Forms applications.

**Features**

Here is a quick summary of the features available in Essential DocIO

- Create new Word documents.
- Modify existing Microsoft Word documents.
- Format text, tables using built-in and custom styles.
- Insert bullets and numbering.
- Insert, edit, and remove fields, form fields, hyperlinks, endnotes, footnotes, comments, Header footers.
- Insert and extract images, OLE objects.
- Insert line breaks, page breaks, column breaks and section breaks.
- Find and Replace text with its original formatting.
- Insert Bookmarks and navigate corresponding bookmarks to insert, replace, and delete content.
- Advanced Mail Merge support with different data sources.
- Clone multiple documents and merge into a single document.
- Read and write Built-In and Custom Document Properties.
- Define page setup settings and background.
- Create or edit Word 97-2003, 2007, 2010, and 2013 documents

**Getting Started**

The following steps demonstrate how to create a simple word document in a Xamarin.Forms project using Essential DocIO.
You can also download the entire source code of this demo from [here](http://files2.syncfusion.com/Installs/v12.2.0.40/Samples/Xamarin/DocIO_GettingStarted.zip).

1. Create new Xamarin.Forms portable project.

2. Next, you need to reference Essential Studio components in your solution. 
   DocIO is packaged as a portable class library so currently there is no way to add reference to it from within the Xamarin component store IDE interface. You would need to obtain the required assemblies either through the Xamarin component store  web interface or from Syncfusion.com. Typically you would add reference to DocIO only in the PCL project of your application. The required assembly references are

	```
	Syncfusion.Compression.Portable.dll
	Syncfusion.DocIO.Portable.dll
	```
	If you had already referenced one of our UI components (Chart, Gauge or Treemap) components from within the Xamarin component store IDE interface then the DocIO assembly has already been downloaded and available in your solution folder, You can then manually add references from that folder.

	```
	Components/syncfusionessentialstudio-version/lib/pcl/
	```

3. A new Word document can be easily created from scratch by instantiating a new instance of the WordDocument class. This class is the root node for all other nodes in the Document Object Model for Essential DocIO library. Using this DOM, you can add, edit, and remove content from documents by iterating elements. The following code example illustrates how to create a Word document with minimal content (one section and one paragraph).

	```csharp
	//Creates a new Word document instance
	WordDocument doc = new WordDocument();

	//Adds one section and one paragraph to the document.
	doc.EnsureMinimal();
	```

4. Add a new section at the end of a document by invoking the AddSection method of WordDocument class. The following code example illustrates how to add a new section to a Word document.

	```csharp
	//Adds a new section to the document.
	WSection section = doc.AddSection();
	```

5. Add a new paragraph at the end of section by invoking the AddParagraph method of WSection class; also, you can add a new table at the end of section by invoking the AddTable method of WSection class. The following code example illustrates how to add a new Paragraph and Table to a Word document.

	```csharp
	//Adds a new Paragraph to the section.
	IWParagraph para = section.AddParagraph();

	//Adds a new Table to the section.
	IWTable table = section.AddTable();
	```

6. You can append text to a paragraph by invoking the AppendText method of WParagraph class. The following code example illustrates how to append text to a Word document.

	```csharp
	//Appends text to the paragraph.
	paragraph.AppendText("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
	```

7. You can save a Word document by invoking the Save method of WordDocument class. The following code example illustrates how to save a Word document.

	```csharp
	//Saves the generated Word document.
	MemoryStream stream = new MemoryStream();
	doc.Save(stream, FormatType.Word2013);

	//Releases the resources used by the WordDocument instance.
	doc.Close();
	```


**Screenshots**

![DocIO]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/DocIO/gettingstarted.png )



#<a id="PDF"></a>PDF


Essential PDF for Xamarin is a .NET PCL library that can be used to create and modify Adobe PDF documents from within Xamarin.iOS, Xamarin.Android and Xamarin.Forms applications.

All of the elements in a typical PDF file like the text, formatting, images and tables are accessible through a comprehensive set of API's. This makes it possible to easily create richly formatted PDF documents as well as modify existing ones.

**Features:**

**Document level features:**

- Create and load PDF documents files and streams
- Save PDF files to disk and Streams
- Document information
- Document viewer preference
- Document file attachments
- Document level java scripts and actions
- Document outline
- Add and remove Pdf pages
- Import page form existing document
- Document merging 
- Booklet
- Stamp
- Page orientation
- Page sizes
- Headers and Footers
- Actions

**Text**

- Drawing Text
- Text formatting
- Pagination

**Graphics**

- Pen and brush for stroking operations
- Graphics primitives: lines, ellipses, rectangles, arcs, pie, Bezier curves, paths.
- Layers
- Patterns
- Drawing of external page content
- Color spaces
- Barcode

**Forms**

- Create, load and save PDF forms
- Add, edit, remove and rename form fields
- Supporting text box fields, combo box fields, list box fields, push button fields, radio button fields
- Flatten form fields
- Enumerating the form fields
- Form actions

**Fonts**

- Standard Fonts

**Images**

- Jpeg image support

**Tables** :

- Cell/Row/Column formatting
- Header
- Pagination
- Borders
- Row span and column span
- Nested
- Cell Padding and spacing

**Page Level Operations**

- Headers and Footers
- Page Label
- Automatic fields

**Pdf Annotations**

- Add, edit and remove pdf annotations
- Custom appearance for annotations

**Supported annotations**

- Free Text annotation
- Rubber stamp annotations
- File attachment annotation
- Link annotation
- Line annotation
- Ink annotations
- Text markup annotations
- sound annotations
- 3D-Annotations.

**Barcode**

- Add the barcode into the PDF document

**Supported barcodes:**

- QR barcode
- Data matrix barcode
- Code39
- Code39ext
- Code 11
- Coda bar
- Code32
- Code93
- Code93 extended
- Code128 A
- Code128 B
- Code128 C

**Getting Started:**

The following steps demonstrate how create a simple PDF document in a Xamarin.Forms project using Essential PDF. You can also download the entire source code of this demo from [here](http://files2.syncfusion.com/Installs/v12.2.0.40/Samples/Xamarin/PDF_GettingStarted.zip).

1. Create a new Xamarin.Forms portable project.

2. Next, you need to reference Essential Studio components in your solution. 
   Essential PDF is packaged as a portable class library so currently there is no way to add reference to it from within the Xamarin component store IDE interface. You would need to obtain the required assemblies either through the Xamarin component store  web interface or from Syncfusion.com. Typically you would add reference to Essential PDF only in the PCL project of your application. The required assembly references are

	```
	Syncfusion.Compression.Portable.dll
	Syncfusion.Pdf.Portable.dll
	```
	Note: If you had already referenced one of our UI components (Chart, Gauge or Treemap) components from within the Xamarin component store IDE interface then the DocIO assembly has already been downloaded and available in your solution folder, You can then manually add references from that folder.

	```
	Components/syncfusionessentialstudio-version/lib/pcl/
	```

3. Use the following C# code to generate a simple PDF using Essential PDF

	```csharp
        //Create a new PDF document.
        PdfDocument document = new PdfDocument();

        //Add a page
        PdfPage page = document.Pages.Add();

        //Creates Pdf graphics for the page
        PdfGraphics graphics = page.Graphics;

        //Creates a solid brush.
        PdfBrushbrush =newPdfSolidBrush(Color.Black);

        //Sets the font.
        PdfFontfont =newPdfStandardFont(PdfFontFamily.Helvetica, fontSize);

        //Draws the text.
        graphics.DrawString("Lorem Ipsum is simply dummy text of the
		printing and typesetting industry. Lorem Ipsum has been the
		standard dummy text ever since the 1500s, when an unknown printer
		took a galley of type and scrambled it to make a type specimen
		book.", font, brush, new RectangleF(0,0, page.GetClientSize().
		Width,200));

        //Saves the document.
        MemoryStream stream = new MemoryStream();
        document.Save(stream);
        document.Close(true);
	```

**Screenshots**

![Pdf]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/Pdf/gettingstarted.png )




#<a id="BusyIndicator"></a>BusyIndicator

**Introduction**

The Busy Indicator control enables you to know when the application is busy. SfBusyIndicator includes over 10 pre-built animations that can be displayed within your applications.

![busyindicator](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/busyindicator/title.png)

This section provides a quick overview for working with Essential BusyIndicator for Xamarin.Forms.

## Adding Syncfusion assembly reference

Add the required Syncfusion assembly references to the respective projects as explained below.

All the required assemblies can be found in the installation folders, typically

**{Syncfusion Installed location}\Essential Studio\13.1.0.1\lib**

_Eg: C:\Program Files (x86)\Syncfusion\Essential Studio\13.1.0.1\lib_

**PCL project**

```
XForms\Syncfusion.SfBusyIndicator.XForms.dll 
```

**Android project**

```
Android\Syncfusion. SfBusyIndicator.Andriod.dll
Android\Syncfusion.SfBusyIndicator.XForms.Andriod.dll
```

**iOS project**

```
iOS\Syncfusion.SfBusyIndicator.iOS.dll 
iOS\Syncfusion.SfBusyIndicator.XForms.iOS.dll
```

**Windows Phone project**

```
WinPhone\Syncfusion.SfBusyIndicator.WP8.dll
WinPhone\Syncfusion SfBusyIndicator.XForms.WinPhone.dll
```

Note: Essential BusyIndicator for Xamarin is compatible with Xamarin Forms 1.3.

Currently an additional step is required for Windows Phone and iOS projects. We need to create an instance of the BusyIndicator custom renderer as mentioned below.

Create an instance of the SfBusyIndicatorRenderer in MainPage constructor in Windows Phone project as shown below

     public MainPage()

       {

             new SfBusyIndicatorRenderer ();

             ...  

      }

Create an instance of the SfBusyIndicatorRenderer in FinishedLaunching overridden method of AppDelegate class in iOS Project as shown below

	public override bool FinishedLaunching(UIApplication app, NSDictionary options)

        {

            ...

            new SfBusyIndicatorRenderer ();

             ...

       }

**Adding and configuring the BusyIndicator**

The BusyIndicator control can be configured entirely in C# code or using XAML markup.

Create an instance of SfBusyIndicator

**[C#]**

```csharp
// Update App.cs source in this file.
using Syncfusion.XForms.SfBusyIndicator;
…
…
public class App : Application
    {
        public App()
        {
            MainPage = new BusyIndicatorPage ();
        }

    }
public class BusyIndicatorPage : ContentPage
{
        SfBusyIndicator sfbusyindicator;
        public BusyIndicatorPage ()
        {
            sfbusyindicator = new SfBusyIndicator();
        } 
}
```

**[XAML]**

```xml
// Use this in App.CS source.
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"  xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
            x:Class="BusyIndicatorGettingStarted.BusyIndicatorGettingStarted" BackgroundColor="White"
            xmlns:syncfusion="clr-namespace:Syncfusion.SfBusyIndicator.XForms;assembly=Syncfusion.SfBusyIndicator.XForms"
            xmlns:picker="clr-namespace:BusyIndicatorGettingStarted;assembly=BusyIndicatorGettingStarted">
    <ContentPage.Content> x:Class="BusyIndicatorGettingStarted.Sample">
<ContentPage.Content>
        <syncfusion:SfBusyIndicator  
    </ContentPage.Content>
</ContentPage>
```

## Configure the BusyIndicator Properties

The next step is to add BusyIndicator properties in application/

**[C#]**

```charp
SfBusyIndicator sfbusyindicator = new SfBusyIndicator();
sfbusyindicator.AnimationType = AnimationTypes.Battery;
sfbusyindicator.ViewBoxWidth = 150;
sfbusyindicator.ViewBoxHeight = 150;
sfbusyindicator.BackgroundColor = Color.White; 
```

**[XAML]**

```xml
<syncfusion:SfBusyIndicator x:Name="sfbusyindicator" BackgroundColor="White" ViewBoxHeight="150" ViewBoxWidth="150" AnimationType="Ball"/>
```

**Screenshots**

![busyindicator]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/busyindicator/busyindicator.png )




#<a id="RangeSlider"></a>RangeSlider

**Introduction**

RangeSlider control allows you to select the range of value within the specified minimum and maximum limit. You can select the range by moving the thumb control along a track.

![rangeslider](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/rangeslider/rangeslider.png)

This section provides a quick overview for working with Essential RangeSlider for Xamarin.Forms.

## Adding Syncfusion assembly reference

Add the required Syncfusion assembly references to the respective projects as explained below.

All the required assemblies can be found in the installation folders, typically

**{Syncfusion Installed location}\Essential Studio\13.1.0.1\lib**

_Eg: C:\Program Files (x86)\Syncfusion\Essential Studio\13.1.0.1\lib_

**PCL project**

```
XForms\Syncfusion.SfRangeSlider.XForms.dll 
```

**Android project**

```
Android\Syncfusion. SfRangeSlider.Andriod.dll
Android\Syncfusion.SfRangeSlider.XForms.Andriod.dll
```

**iOS project**

```
iOS\Syncfusion.SfRangeSlider.iOS.dll 
iOS\Syncfusion.SfRangeSlider.XForms.iOS.dll
```

**Windows Phone project**

```
WinPhone\Syncfusion.SfInput.WP8.dll
WinPhone\Syncfusion.SfShared.WP8.dll
WinPhone\Syncfusion SfRangeSlider.XForms.WinPhone.dll
```

Note: Essential RangeSlider for Xamarin is compatible with Xamarin Forms 1.3.

Currently an additional step is required for Windows Phone and iOS projects. We need to create an instance of the RangeSlider custom renderer as mentioned below.

Create an instance of the SfRangeSliderRenderer in MainPage constructor in Windows Phone project as shown below

     public MainPage()

       {

             new SfRangeSliderRenderer ();

             ...  

      }

Create an instance of the SfRangeSliderRenderer in FinishedLaunching overridden method of AppDelegate class in iOS Project as shown below

	public override bool FinishedLaunching(UIApplication app, NSDictionary options)

        {

            ...

            new SfRangeSliderRenderer ();

             ...

       }

**Adding and configuring the RangeSlider**

The RangeSlider control can be configured entirely in C# code or using XAML markup.

Create an instance of SfRangeSlider

**[C#]**

```csharp
// Update App.cs source in this file.
using Syncfusion.XForms.SfRangeSlider;
…
…
public class App : Application
    {
        public App()
        {
            MainPage = new RangeSliderPage ();
        }

    }
public class RangeSliderPage : ContentPage
{
        SfRangeSlider sfrangeslider;
        public RangeSliderPage ()
        {
            sfrangeslider = new SfRangeSlider();
        }
}
```

**[XAML]**

```xml
// Use this in App.CS source.
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" BackgroundColor="White"
 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="RangeSliderGettingStarted.RadialSliderPage"
 xmlns:syncfusion="clr-namespace:Syncfusion.SfRangeSlider.XForms;assembly=Syncfusion.SfRangeSlider.XForms">
    <ContentPage.Content>
            <syncfusion:SfRangeSlider />
    </ContentPage.Content>
</ContentPage> </ContentPage.Content>
</ContentPage>
```

## Configure the RangeSlider Properties

The next step is to add RangeSlider properties in application/

**[C#]**

```charp
SfRangeSlider sfrangeslider = new SfRangeSlider();
sfrangeslider.Minimum= 0;
sfrangeslider.Maximum = 12;
sfrangeslider.ShowRange= true;
sfrangeslider.RangeStart = 0;
sfrangeslider.RangeEnd = 12;
sfrangeslider.ShowValueLabels= True; 
```

**[XAML]**

```xml
<syncfusion:SfRangeSlider HeightRequest="100" TickFrequency="2" Minimum="0" Maximum="12" TickPlacement="BottomRight" ShowRange="True" RangeStart="4" RangeEnd="8" Orientation="Horizontal" WidthRequest="400"></syncfusion:SfRangeSlider>
```

**Screenshots**

![rangeslider]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/rangeslider/rangeslider.png )




#<a id="AutoComplete"></a>AutoComplete

**Introduction**

AutoComplete functionality provides suggestions to the user while typing. There are several modes of suggestions. The suggested text can be appended to the original text or it can be displayed in a drop-down list so that user can choose from different options.

![autocomplete](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/autocomplete/autocomplete.png)

This section provides a quick overview for working with Essential AutoComplete for Xamarin.Forms.

## Adding Syncfusion assembly reference

Add the required Syncfusion assembly references to the respective projects as explained below.

All the required assemblies can be found in the installation folders, typically

**{Syncfusion Installed location}\Essential Studio\13.1.0.1\lib**

_Eg: C:\Program Files (x86)\Syncfusion\Essential Studio\13.1.0.1\lib_

**PCL project**

```
XForms\Syncfusion.SfAutoComplete.XForms.dll 
```

**Android project**

```
Android\Syncfusion. SfAutoComplete.Andriod.dll
Android\Syncfusion.SfAutoComplete.XForms.Andriod.dll
```

**iOS project**

```
iOS\Syncfusion.SfAutoComplete.iOS.dll 
iOS\Syncfusion.SfAutoComplete.XForms.iOS.dll
```

**Windows Phone project**

```
WinPhone\Syncfusion.SfInput.WP8.dll
WinPhone\Syncfusion.SfShared.WP8.dll
WinPhone\Syncfusion SfAutoComplete.XForms.WinPhone.dll
```

Note: Essential AutoComplete for Xamarin is compatible with Xamarin Forms 1.3.

Currently an additional step is required for Windows Phone and iOS projects. We need to create an instance of the AutoComplete custom renderer as mentioned below.

Create an instance of the SfAutoCompleteRenderer in MainPage constructor in Windows Phone project as shown below

     public MainPage()

       {

             new SfAutoCompleteRenderer ();

             ...  

      }

Create an instance of the SfAutoCompleteRenderer in FinishedLaunching overridden method of AppDelegate class in iOS Project as shown below

	public override bool FinishedLaunching(UIApplication app, NSDictionary options)

        {

            ...

            new SfAutoCompleteRenderer ();

             ...

       }

**Adding and configuring the AutoComplete**

The AutoComplete control can be configured entirely in C# code or using XAML markup.

Create an instance of SfAutoComplete

**[C#]**

```csharp
// Update App.cs source in this file.
using Syncfusion.XForms.SfAutoComplete;
…
…
public class App : Application
    {
        public App()
        {
            MainPage = new AutoCompletePage ();
        }

    }
public class AutoCompletePage : ContentPage
{
        SfAutoComplete sfautocomplete;
        public AutoCompletePage ()
        {
            sfautocomplete = new SfAutoComplete();
        }
}
```

**[XAML]**

```xml
// Use this in App.CS source.
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" BackgroundColor="White"
 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="AutoCompleteStarted.AutoCompletePage"
 xmlns:syncfusion="clr-namespace:Syncfusion.SfAutoComplete.XForms;assembly=Syncfusion.SfAutoComplete.XForms">
    <ContentPage.Content>
            <syncfusion:SfAutoComplete />
    </ContentPage.Content>
</ContentPage> </ContentPage.Content>
</ContentPage>
```

## Configure the AutoComplete Properties

The next step is to add AutoComplete properties in application/

**[C#]**

```charp
SfAutoComplete sfautocomplete = new SfAutoComplete  ();
sfautocomplete .AutoCompleteSource= list1;
sfautocomplete .MinimumPrefixCharacter= 2;
sfautocomplete .MaximumDropDownHeight= 200;
sfautocomplete .PopUpelay= 100; 
```

**[XAML]**

```xml
<syncfusion:SfAutoComplete x:Name="sfautocomplete" BackgroundColor="White" MinimumPrefixCharacter="2" MaximumDropDownHeight="200" PopUpDelay="100"/>
```

**Screenshots**

![autocomplete]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/autocomplete/autocomplete.png )


#<a id="NumericTextBox"></a>NumericTextBox

**Introduction**

NumericTextBox is an advanced version of the EditText control which restricts input to numeric values. The control respects the UI culture and can be configured to display different formats like currency format, scientific format, etc.
![numerictextbox](http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/numerictextbox/numerictextbox.png)

This section provides a quick overview for working with Essential NumericTextBox for Xamarin.Forms.

## Adding Syncfusion assembly reference
Add the required Syncfusion assembly references to the respective projects as explained below.

All the required assemblies can be found in the installation folders, typically

**{Syncfusion Installed location}\Essential Studio\13.1.0.1\lib**

_Eg: C:\Program Files (x86)\Syncfusion\Essential Studio\13.1.0.1\lib_

**PCL project**

```
XForms\Syncfusion.SfNumericTextBox.XForms.dll 
```

**Android project**

```
Android\Syncfusion.SfNumericTextBox.Andriod.dll
Android\Syncfusion.SfNumericTextBox.XForms.Andriod.dll
```

**iOS project**

```
iOS\Syncfusion.SfNumericTextBox.iOS.dll 
iOS\Syncfusion.SfNumericTextBox.XForms.iOS.dll
```

**Windows Phone project**

```
WinPhone\Syncfusion.SfInput.WP8.dll
WinPhone\Syncfusion.SfShared.WP8.dll
WinPhone\Syncfusion.SfNumericTextBox.XForms.WinPhone.dll
```

Note: Essential NumericTextBox for Xamarin is compatible with Xamarin Forms 1.3.

Currently an additional step is required for Windows Phone and iOS projects. We need to create an instance of the NumericTextBox custom renderer as mentioned below.

Create an instance of the SfNumericTextBoxRenderer in MainPage constructor in Windows Phone project as shown below

     public MainPage()

       {

             new SfNumericTextBoxRenderer ();

             ...  

      }

Create an instance of the SfNumericTextBoxRenderer in FinishedLaunching overridden method of AppDelegate class in iOS Project as shown below

	public override bool FinishedLaunching(UIApplication app, NSDictionary options)

        {

            ...

            new SfNumericTextBoxRenderer ();

             ...

       }
**Adding and configuring the NumericTextBox**

The NumericTextBox control can be configured entirely in C# code or using XAML markup.

Create an instance of SfNumericTextBox

**[C#]**

```csharp
// Update App.cs source in this file.
using Syncfusion.XForms.SfNumericTextBox;
…
…
public class App : Application
    {
        public App()
        {
            MainPage = new NumericTextBoxPage ();
        }

    }
public class NumericTextBoxPage : ContentPage
{
        SfNumericTextBox sfnumerictextbox;
        public NumericTextBoxPage ()
        {
            sfnumerictextbox = new SfNumericTextBox();
        }
}
```

**[XAML]**

```xml
// Use this in App.CS source.
Use this in App.CS source.
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" BackgroundColor="White"
 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="NumericTextBoxGettingStarted.NumericTextBoxPage"
 xmlns:syncfusion="clr-namespace:Syncfusion.SfNumericTextBox.XForms;assembly=Syncfusion.SfNumericTextBox.XForms">
    <ContentPage.Content>
            <syncfusion:SfNumericTextBox />
    </ContentPage.Content>
</ContentPage> </ContentPage.Content>
</ContentPage>
```

**Configure the NumericTextBox Properties**

The next step is to add NumericTextBox properties in application

**[C#]**

```csharp
SfNumericTextBox sfnumerictextbox = new SfNumericTextBox();
sfnumerictextbox.Value= 1000;
sfnumerictextbox.FormatString= “c”;
sfnumerictextbox.AllowNull= true;
sfnumerictextbox.MaximumNumberDecimalDigits= 2;
```

**[XAML]**

```xml
<syncfusion:SfNumericTextBox HeightRequest="100"  Value="1000"  Orientation="Horizontal" WidthRequest="200" FormatString=”C” AllowNull=”true” MaximumNumberDecimalDigits=”2”>
 </syncfusion:SfNumericTextBox>
```

**Screenshots**

![numerictextbox]( http://www.syncfusion.com/Content/en-US/products/Images/Xamarin/numerictextbox/numerictextbox.png )