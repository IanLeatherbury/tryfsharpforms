using System;
using tryfsharplib;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public class HomePage : ContentPage
	{
		
		public HomePage ()
		{
			// Define command for the items in the TableView.
			Command<Type> navigateCommand = 
				new Command<Type> (async (Type pageType) => {
					Page page = (Page)Activator.CreateInstance (pageType);
					await this.Navigation.PushAsync (page);
				});

			var gettingStartedSection = new TableSection ("Getting Started") {
				new TextCell { 
					Text = "Basic Financial Calculations",
					Command = navigateCommand,
					CommandParameter = typeof(BasicCalc)
				},
				new TextCell { 
					Text = "Units of Measure",
					Command = navigateCommand,
					CommandParameter = typeof(UnitsOfMeasurePage)
				},
				new TextCell { 
					Text = "Exploring Historical Stock Prices",
					Command = navigateCommand,
					CommandParameter = typeof(ExploringHistoricalStockPricesPage)
				},
				new TextCell { 
					Text = "Analyzing Stock Prices",
					Command = navigateCommand,
					CommandParameter = typeof(AnalyzingStockPrices)
				},
				new TextCell { Text = "Charting and Comparing Prices" }
			};

			var financialModelingSection = new TableSection ("Financial Modeling") { 
				new TextCell { Text = "Using the Yahoo Finance Type Provider" },
				new TextCell { Text = "Working with Financial Data" },
			};

			var pricingFinancialOptionsSection = new TableSection ("Pricing Financial Options") { 
				new TextCell { Text = "Understanding European Options" },
				new TextCell { Text = "Simulating and Analyzing Asset Prices" },
				new TextCell { Text = "Pricing European Options" },
			};

			var modelingStockMarketInteractionsSection = new TableSection ("Modeling Market Interactions") { 
				new TextCell { Text = "Analyzing Stock Markets" },
				new TextCell { Text = "Implementing the Kalman Filter" },
				new TextCell { Text = "Training the Model" },
				new TextCell { Text = "Analysing Market Interactions" },
			};

			var stressTestingTheBankingSystemSection = new TableSection ("Stress Testing the Banking System") { 
				new TextCell { Text = "Introduction" },
				new TextCell { Text = "Understanding Systemic Risk" },
				new TextCell { Text = "Modeling Systemic Risk" },
				new TextCell { Text = "Assessing the Mexican Banking System" },
			};

			Content = new TableView { 
				Root = new TableRoot {
					gettingStartedSection,
					financialModelingSection,
					pricingFinancialOptionsSection,
					modelingStockMarketInteractionsSection,
					stressTestingTheBankingSystemSection
				},
				Intent = TableIntent.Menu	
			};
		}
	}
}