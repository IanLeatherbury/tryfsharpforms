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
using System.Threading.Tasks;
using XamarinIOInvoice.WinPhone;
using Xamarin.Forms;
using System.IO;
using Windows.Storage;

[assembly: Dependency(typeof(SaveWindowsPhone))]
namespace XamarinIOInvoice.WinPhone
{
    class SaveWindowsPhone:ISave
    {
        public async Task SaveTextAsync(string filename,string contentType, MemoryStream s)
        {
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile outFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            using (Stream outStream = await outFile.OpenStreamForWriteAsync())
            {
                outStream.Write(s.ToArray(),0,(int)s.Length);

            }
            await Windows.System.Launcher.LaunchFileAsync(outFile);
        }
    }
}
