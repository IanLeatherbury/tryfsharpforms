#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using Syncfusion.SfBarcode.XForms;

namespace SampleBrowser
{
    public class Barcodes : SamplePage
    {
        StackLayout labelLayout;
        StackLayout barcodeLayout;
        SfBarcode barcode;
        private SfBarcode currentBarcode;
        Thickness padding;
        float fontSize, textFont, xDimension;
        Picker picker_Symbology;
        Label allowedCharactersLabel;
        private Label typeLabel;
        public Barcodes()
        {
            BackgroundColor = Color.White;
            padding = Device.OnPlatform(iOS: new Thickness(8), Android: new Thickness(8), WinPhone: new Thickness(10));
            fontSize = Device.OnPlatform(iOS: 10, Android: 20, WinPhone: 20);
            xDimension = Device.OnPlatform(iOS: 6, Android: 8, WinPhone: 8);
            picker_Symbology = new Picker();

            LoadAllowedCharactersLabel();

            LoadBarcode(ref barcode, BarcodeSymbolType.QRCode, "http://www.syncfusion.com");
            currentBarcode = barcode;
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                this.picker_Symbology.BackgroundColor = Color.Gray;
            }
            this.picker_Symbology.Items.Add("QRCode");
            this.picker_Symbology.Items.Add("DataMatrix");
            this.picker_Symbology.Items.Add("Code32");
            this.picker_Symbology.Items.Add("Code39");
            this.picker_Symbology.Items.Add("Code39Extended");
            this.picker_Symbology.Items.Add("Code93");
            this.picker_Symbology.Items.Add("Code93Extended");
            this.picker_Symbology.Items.Add("Code128A");
            this.picker_Symbology.Items.Add("Code128B");
            this.picker_Symbology.Items.Add("Code128C");
            this.picker_Symbology.Items.Add("CodaBar");
            this.picker_Symbology.Items.Add("Code11");
            this.picker_Symbology.SelectedIndex = 0;
            this.picker_Symbology.SelectedIndexChanged += picker_Symbology_SelectedIndexChanged;

            typeLabel = new Label()
            {
                Text = "Barcode Symbology",
                FontSize = fontSize,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold
            };

            barcodeLayout = new StackLayout
            {
                Spacing = padding.Top,
                Padding = padding,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { typeLabel, picker_Symbology, labelLayout, barcode }
            };
            this.ContentView = barcodeLayout;

        }


        void picker_Symbology_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.picker_Symbology.SelectedIndex)
            {
                case 0:
                    allowedCharactersLabel.Text = "All 128 ASCII Characters";
                    LoadBarcode(ref barcode, BarcodeSymbolType.QRCode, "http://www.syncfusion.com");
                    break;
                case 1:
                    allowedCharactersLabel.Text = "All 128 ASCII Characters";
                    LoadBarcode(ref barcode, BarcodeSymbolType.DataMatrix, "support@syncfusion.com");
                    break;

                case 2:
                    allowedCharactersLabel.Text = "1 2 3 4 5 6 7 8 9 0\\nText length should be 8!!!";
                    LoadBarcode(ref barcode, BarcodeSymbolType.Code32, "87654321");
                    break;
                case 3:
                    allowedCharactersLabel.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F G H I J K L M N O P Q R S T U V W X Y Z dash(-) dot(.) $ / + % SPACE";
                    LoadBarcode(ref barcode, BarcodeSymbolType.Code39, "DR2439F");

                    break;
                case 4:
                    allowedCharactersLabel.Text = "All 128 ASCII Characters";
                    LoadBarcode(ref barcode, BarcodeSymbolType.Code39Extended, "G71C0453");

                    break;
                case 5:
                    allowedCharactersLabel.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F G H I J K L M N O P Q R S T U V W X Y Z dash(-) dot(.) $ / + % SPACE";
                    LoadBarcode(ref barcode, BarcodeSymbolType.Code93, "PN-0AOPC-9876");

                    break;
                case 6:
                    allowedCharactersLabel.Text = "All 128 ASCII Characters";
                    LoadBarcode(ref barcode, BarcodeSymbolType.Code93Extended, "S_IMEI2:9113546");

                    break;
                case 7:
                    allowedCharactersLabel.Text = "ASCII values from 0 to 95\\nNUL SOH STX ETX EOT ENQ ACK BEL BS HT LF VT FF CR SO SI DLE DC1 DC2 DC3 DC4 NAK SYN ETB CAN EM SUB ESC FS GS RS US SPACE ! \\ # $ %  ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ;  = >? @ A B C D E F G H I J K L M N O P Q R S T U V W X Y Z [ \\\\ ]^ _";
                    LoadBarcode(ref barcode, BarcodeSymbolType.Code128A, "ACL32 SF-D8");

                    break;
                case 8:
                    allowedCharactersLabel.Text = "ASCII values from 32 to 127\\nSPACE ! \\ # $ %  ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; = >? @ A B C D E F G H I J K L M N O P Q R S T U V W X Y Z [ \\\\ ]^ _ ` a b c d e f g h i j k l m n o p q r s t u v w x y z { | } ~ DEL";
                    LoadBarcode(ref barcode, BarcodeSymbolType.Code128B, "ISBN-678504");
                    break;
                case 9:
                    allowedCharactersLabel.Text = "0 1 2 3 4 5 6 7 8 9";
                    LoadBarcode(ref barcode, BarcodeSymbolType.Code128C, "092418376");

                    break;
                case 10:
                    allowedCharactersLabel.Text = "0 1 2 3 4 5 6 7 8 9 - $ : / dot(.) +";
                    LoadBarcode(ref barcode, BarcodeSymbolType.CodaBar, "$52675:14-98");

                    break;
                case 11:
                    allowedCharactersLabel.Text = "0 1 2 3 4 5 6 7 8 9 dash(-)";
                    LoadBarcode(ref barcode, BarcodeSymbolType.Code11, "1234-567-890");
                    break;

            }
        }


        void LoadAllowedCharactersLabel()
        {
            Label label = new Label()
            {
                Text = "Allowed Characters",
                FontSize = fontSize,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold
            };

            allowedCharactersLabel = new Label()
            {
                Text = "All 128 ASCII Characters",
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center,
            };
            if (Device.OS == TargetPlatform.iOS)
            {
                allowedCharactersLabel.FontSize = 10;
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                allowedCharactersLabel.FontSize = 14;
            }
            else if (Device.OS == TargetPlatform.WinPhone)
            {
                allowedCharactersLabel.FontSize = 20;
            }
            else
            {
                allowedCharactersLabel.FontSize = 16;
            }
            StackLayout allowedCharactersLayout = new StackLayout
            {
                BackgroundColor = Color.Black,

                Children = { allowedCharactersLabel },
                Padding = new Thickness(5)
            };

            labelLayout = new StackLayout
            {
                Spacing = padding.Top,
                Children = { label, allowedCharactersLayout }
            };
            labelLayout.SizeChanged += layout_SizeChanged;
        }

        void LoadBarcode(ref SfBarcode barcode, BarcodeSymbolType symbolType, string text)
        {
            if (barcode == null)
                barcode = new SfBarcode();
            barcode.VerticalOptions = LayoutOptions.FillAndExpand;
            barcode.HorizontalOptions = LayoutOptions.FillAndExpand;
            barcode.BackgroundColor = Color.FromRgb(234, 234, 234);
            barcode.Text = text;
            barcode.TextFont = Font.SystemFontOfSize(fontSize);
            barcode.Symbology = symbolType;

            if (symbolType == BarcodeSymbolType.QRCode)
            {
                QRBarcodeSettings qr = new QRBarcodeSettings() { XDimension = xDimension, };
                barcode.SymbologySettings = qr;
            }
            else if (symbolType == BarcodeSymbolType.DataMatrix)
            {
                DataMatrixSettings dm = new DataMatrixSettings() { XDimension = xDimension };
                barcode.SymbologySettings = dm;
            }
            else if (symbolType == BarcodeSymbolType.Code32)
            {
                Code32Settings c32 = new Code32Settings();
                barcode.SymbologySettings = c32;
            }
            else if (symbolType == BarcodeSymbolType.Code39)
            {
                Code39Settings c39 = new Code39Settings();
                barcode.SymbologySettings = c39;
            }
            else if (symbolType == BarcodeSymbolType.Code39Extended)
            {
                Code39ExtendedSettings c39e = new Code39ExtendedSettings();
                barcode.SymbologySettings = c39e;
            }
            else if (symbolType == BarcodeSymbolType.Code93)
            {
                Code93Settings c93 = new Code93Settings();
                barcode.SymbologySettings = c93;
            }
            else if (symbolType == BarcodeSymbolType.Code93Extended)
            {
                Code93ExtendedSettings c93e = new Code93ExtendedSettings();
                barcode.SymbologySettings = c93e;
            }
            else if (symbolType == BarcodeSymbolType.Code128C)
            {
                Code128CSettings c128c = new Code128CSettings();
                barcode.SymbologySettings = c128c;
            }
            else if (symbolType == BarcodeSymbolType.Code128A)
            {
                Code128ASettings c128a = new Code128ASettings();
                barcode.SymbologySettings = c128a;
            }
            else if (symbolType == BarcodeSymbolType.Code128B)
            {
                Code128BSettings c128b = new Code128BSettings();
                barcode.SymbologySettings = c128b;
            }
            else if (symbolType == BarcodeSymbolType.Code11)
            {
                Code11Settings c11 = new Code11Settings();
                barcode.SymbologySettings = c11;
            }
            else
            {
                CodaBarSettings coda = new CodaBarSettings();
                barcode.SymbologySettings = coda;
            }
        }



        void layout_SizeChanged(object sender, EventArgs e)
        {
            if (currentBarcode != null)
                currentBarcode.HeightRequest = barcodeLayout.Height - (labelLayout.Height + 2 * padding.Top + padding.Bottom);
        }
    }
}