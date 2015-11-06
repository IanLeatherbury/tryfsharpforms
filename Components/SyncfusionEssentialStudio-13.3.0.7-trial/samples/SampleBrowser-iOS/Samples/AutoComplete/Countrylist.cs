#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

#if __UNIFIED__
using Foundation;
using UIKit;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;

#endif

namespace SampleBrowser
{
	public class Countrylist
	{
		NSMutableArray listt = new NSMutableArray();
		public Countrylist ()
		{
			listt.Add ((NSString)"Afghanistan");
			listt.Add ((NSString)"Akrotiri");
			listt.Add ((NSString)"Albania");
			listt.Add ((NSString)"Algeria");
			listt.Add ((NSString)"American Samoa");
			listt.Add ((NSString)"Andorra");
			listt.Add ((NSString)"Angola");
			listt.Add ((NSString)"Anguilla");
			listt.Add ((NSString)"Antarctica");
			listt.Add ((NSString)"Antigua and Barbuda");
			listt.Add ((NSString)"Argentina");
			listt.Add ((NSString)"Armenia");
			listt.Add ((NSString)"Aruba");
			listt.Add ((NSString)"Ashmore and Cartier Islands");
			listt.Add ((NSString)"Australia");
			listt.Add ((NSString)"Austria");
			listt.Add ((NSString)"Azerbaijan");
			listt.Add ((NSString)"Bahamas, The");
			listt.Add ((NSString)"Bahrain");
			listt.Add ((NSString)"Bangladesh");
			listt.Add ((NSString)"Barbados");
			listt.Add ((NSString)"Bassas da India");
			listt.Add ((NSString)"Belarus");
			listt.Add ((NSString)"Belgium");
			listt.Add ((NSString)"Belize");
			listt.Add ((NSString)"Benin");
			listt.Add ((NSString)"Bermuda");
			listt.Add ((NSString)"Bhutan");
			listt.Add ((NSString)"Bolivia");
			listt.Add ((NSString)"Bosnia and Herzegovina");
			listt.Add ((NSString)"Botswana");
			listt.Add ((NSString)"Bouvet Island");
			listt.Add ((NSString)"Brazil");
			listt.Add ((NSString)"British Indian Ocean Territory");
			listt.Add ((NSString)"British Virgin Islands");
			listt.Add ((NSString)"Brunei");
			listt.Add ((NSString)"Bulgaria");
			listt.Add ((NSString)"Burkina Faso");
			listt.Add ((NSString)"Burma");
			listt.Add ((NSString)"Burundi");
			listt.Add ((NSString)"Cambodia");
			listt.Add ((NSString)"Cameroon");
			listt.Add ((NSString)"Canada");
			listt.Add ((NSString)"Cape Verde");
			listt.Add ((NSString)"Cayman Islands");
			listt.Add ((NSString)"Central African Republic");
			listt.Add ((NSString)"Chad");
			listt.Add ((NSString)"Chile");
			listt.Add ((NSString)"China");
			listt.Add ((NSString)"Christmas Island");
			listt.Add ((NSString)"Clipperton Island");
			listt.Add ((NSString)"Cocos (Keeling) Islands");
			listt.Add ((NSString)"Colombia");
			listt.Add ((NSString)"Comoros");
			listt.Add ((NSString)"Congo");
			listt.Add ((NSString)"Congo, Republic of the");
			listt.Add ((NSString)"Cook Islands");
			listt.Add ((NSString)"Coral Sea Islands");
			listt.Add ((NSString)"Costa Rica");
			listt.Add ((NSString)"Cote d'Ivoire");
			listt.Add ((NSString)"Croatia");
			listt.Add ((NSString)"Cuba");
			listt.Add ((NSString)"Cyprus");
			listt.Add ((NSString)"Czech Republic");
			listt.Add ((NSString)"Denmark");
			listt.Add ((NSString)"Dhekelia");
			listt.Add ((NSString)"Djibouti");
			listt.Add ((NSString)"Dominica");
			listt.Add ((NSString)"Dominican Republic");
			listt.Add ((NSString)"Ecuador");
			listt.Add ((NSString)"Egypt");
			listt.Add ((NSString)"El Salvador");
			listt.Add ((NSString)"Equatorial Guinea");
			listt.Add ((NSString)"Eritrea");
			listt.Add ((NSString)"Estonia");
			listt.Add ((NSString)"Ethiopia");
			listt.Add ((NSString)"Europa Island");
			listt.Add ((NSString)"Falkland Islands");
			listt.Add ((NSString)"Faroe Islands");
			listt.Add ((NSString)"Fiji");
			listt.Add ((NSString)"Finland");
			listt.Add ((NSString)"France");
			listt.Add ((NSString)"French Guiana");
			listt.Add ((NSString)"French Polynesia");
			listt.Add ((NSString)"French Southern and Antarctic Lands");
			listt.Add ((NSString)"Gabon");
			listt.Add ((NSString)"Gambia, The");
			listt.Add ((NSString)"Gaza Strip");
			listt.Add ((NSString)"Georgia");
			listt.Add ((NSString)"Germany");
			listt.Add ((NSString)"Ghana");
			listt.Add ((NSString)"Gibraltar");
			listt.Add ((NSString)"Glorioso Islands");
			listt.Add ((NSString)"Greece");
			listt.Add ((NSString)"Greenland");
			listt.Add ((NSString)"Grenada");
			listt.Add ((NSString)"Guadeloupe");
			listt.Add ((NSString)"Guam");
			listt.Add ((NSString)"Guatemala");
			listt.Add ((NSString)"Guernsey");
			listt.Add ((NSString)"Guinea");
			listt.Add ((NSString)"Guinea-Bissau");
			listt.Add ((NSString)"Guyana");
			listt.Add ((NSString)"Haiti");
			listt.Add ((NSString)"Heard Island and McDonald Islands");
			listt.Add ((NSString)"Holy See");
			listt.Add ((NSString)"Honduras");
			listt.Add ((NSString)"Hong Kong");
			listt.Add ((NSString)"Hungary");
			listt.Add ((NSString)"Iceland");
			listt.Add ((NSString)"India");
			listt.Add ((NSString)"Indonesia");
			listt.Add ((NSString)"Iran");
			listt.Add ((NSString)"Iraq");
			listt.Add ((NSString)"Ireland");
			listt.Add ((NSString)"Isle of Man");
			listt.Add ((NSString)"Israel");
			listt.Add ((NSString)"Italy");
			listt.Add ((NSString)"Jamaica");
			listt.Add ((NSString)"Jan Mayen");
			listt.Add ((NSString)"Japan");
			listt.Add ((NSString)"Jersey");
			listt.Add ((NSString)"Jordan");
			listt.Add ((NSString)"Juan de Nova Island");
			listt.Add ((NSString)"Kazakhstan");
			listt.Add ((NSString)"Kenya");
			listt.Add ((NSString)"Kiribati");
			listt.Add ((NSString)"Korea, North");
			listt.Add ((NSString)"Korea, South");
			listt.Add ((NSString)"Kuwait");
			listt.Add ((NSString)"Kyrgyzstan");
			listt.Add ((NSString)"Laos");
			listt.Add ((NSString)"Latvia");
			listt.Add ((NSString)"Lebanon");
			listt.Add ((NSString)"Lesotho");
			listt.Add ((NSString)"Liberia");
			listt.Add ((NSString)"Libya");
			listt.Add ((NSString)"Liechtenstein");
			listt.Add ((NSString)"Lithuania");
			listt.Add ((NSString)"Luxembourg");
			listt.Add ((NSString)"Macau");
			listt.Add ((NSString)"Macedonia");
			listt.Add ((NSString)"Madagascar");
			listt.Add ((NSString)"Malawi");
			listt.Add ((NSString)"Malaysia");
			listt.Add ((NSString)"Maldives");
			listt.Add ((NSString)"Mali");
			listt.Add ((NSString)"Malta");
			listt.Add ((NSString)"Marshall Islands");
			listt.Add ((NSString)"Martinique");
			listt.Add ((NSString)"Mauritania");
			listt.Add ((NSString)"Mauritius");
			listt.Add ((NSString)"Mayotte");
			listt.Add ((NSString)"Mexico");
			listt.Add ((NSString)"Micronesia");
			listt.Add ((NSString)"Moldova");
			listt.Add ((NSString)"Monaco");
			listt.Add ((NSString)"Mongolia");
			listt.Add ((NSString)"Montserrat");
			listt.Add ((NSString)"Morocco");
			listt.Add ((NSString)"Mozambique");
			listt.Add ((NSString)"Namibia");
			listt.Add ((NSString)"Nauru");
			listt.Add ((NSString)"Navassa Island");
			listt.Add ((NSString)"Nepal");
			listt.Add ((NSString)"Netherlands");
			listt.Add ((NSString)"Netherlands Antilles");
			listt.Add ((NSString)"New Caledonia");
			listt.Add ((NSString)"New Zealand");
			listt.Add ((NSString)"Nicaragua");
			listt.Add ((NSString)"Niger");
			listt.Add ((NSString)"Nigeria");
			listt.Add ((NSString)"Niue");
			listt.Add ((NSString)"Norfolk Island");
			listt.Add ((NSString)"Northern Mariana Islands");
			listt.Add ((NSString)"Norway");
			listt.Add ((NSString)"Oman");
			listt.Add ((NSString)"Pakistan");
			listt.Add ((NSString)"Palau");
			listt.Add ((NSString)"Panama");
			listt.Add ((NSString)"Papua New Guinea");
			listt.Add ((NSString)"Paracel Islands");
			listt.Add ((NSString)"Paraguay");
			listt.Add ((NSString)"Peru");
			listt.Add ((NSString)"Philippines");
			listt.Add ((NSString)"Pitcairn Islands");
			listt.Add ((NSString)"Poland");
			listt.Add ((NSString)"Portugal");
			listt.Add ((NSString)"Puerto Rico");
			listt.Add ((NSString)"Qatar");
			listt.Add ((NSString)"Reunion");
			listt.Add ((NSString)"Romania");
			listt.Add ((NSString)"Russia");
			listt.Add ((NSString)"Rwanda");
			listt.Add ((NSString)"Saint Helena");
			listt.Add ((NSString)"Saint Kitts and Nevis");
			listt.Add ((NSString)"Saint Lucia");
			listt.Add ((NSString)"Saint Pierre and Miquelon");
			listt.Add ((NSString)"Saint Vincent");
			listt.Add ((NSString)"Samoa");
			listt.Add ((NSString)"San Marino");
			listt.Add ((NSString)"Sao Tome and Principe");
			listt.Add ((NSString)"Saudi Arabia");
			listt.Add ((NSString)"Senegal");
			listt.Add ((NSString)"Serbia and Montenegro");
			listt.Add ((NSString)"Seychelles");
			listt.Add ((NSString)"Sierra Leone");
			listt.Add ((NSString)"Singapore");
			listt.Add ((NSString)"Slovakia");
			listt.Add ((NSString)"Slovenia");
			listt.Add ((NSString)"Solomon Islands");
			listt.Add ((NSString)"Somalia");
			listt.Add ((NSString)"South Africa");
			listt.Add ((NSString)"South Georgia");
			listt.Add ((NSString)"Spain");
			listt.Add ((NSString)"Spratly Islands");
			listt.Add ((NSString)"Sri Lanka");
			listt.Add ((NSString)"Sudan");
			listt.Add ((NSString)"Suriname");
			listt.Add ((NSString)"Svalbard");
			listt.Add ((NSString)"Swaziland");
			listt.Add ((NSString)"Sweden");
			listt.Add ((NSString)"Switzerland");
			listt.Add ((NSString)"Syria");
			listt.Add ((NSString)"Taiwan");
			listt.Add ((NSString)"Tajikistan");
			listt.Add ((NSString)"Tanzania");
			listt.Add ((NSString)"Thailand");
			listt.Add ((NSString)"Timor-Leste");
			listt.Add ((NSString)"Togo");
			listt.Add ((NSString)"Tokelau");
			listt.Add ((NSString)"Tonga");
			listt.Add ((NSString)"Trinidad and Tobago");
			listt.Add ((NSString)"Tromelin Island");
			listt.Add ((NSString)"Tunisia");
			listt.Add ((NSString)"Turkey");
			listt.Add ((NSString)"Turkmenistan");
			listt.Add ((NSString)"Turks and Caicos Islands");
			listt.Add ((NSString)"Tuvalu");
			listt.Add ((NSString)"Uganda");
			listt.Add ((NSString)"Ukraine");
			listt.Add ((NSString)"United Arab Emirates");
			listt.Add ((NSString)"United Kingdom");
			listt.Add ((NSString)"United States");
			listt.Add ((NSString)"Uruguay");
			listt.Add ((NSString)"Uzbekistan");
			listt.Add ((NSString)"Vanuatu");
			listt.Add ((NSString)"Venezuela");
			listt.Add ((NSString)"Vietnam");
			listt.Add ((NSString)"Virgin Islands");
			listt.Add ((NSString)"Wake Island");
			listt.Add ((NSString)"Wallis and Futuna");
			listt.Add ((NSString)"West Bank");
			listt.Add ((NSString)"Western Sahara");
			listt.Add ((NSString)"Yemen");
			listt.Add ((NSString)"Zambia");
			listt.Add ((NSString)"Zimbabwe");
		}
		public NSMutableArray Country
		{
			get
			{
				return listt;
			}
		}
	}
}

