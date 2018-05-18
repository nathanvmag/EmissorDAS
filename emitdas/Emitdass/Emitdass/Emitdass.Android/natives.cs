using System;
using Xamarin.Forms;
using Emitdass.Droid;
using System.Net;
using System.Text;

using Java.Net;
using System.Diagnostics;
using System.IO;
using Android.OS;
using Android.Support.V7.App;
using Android.App;
using Android.Util;
using Android.Views;
using Android.Runtime;
using System.Collections.Specialized;

[assembly: Dependency(typeof(natives))]

namespace Emitdass.Droid
{
    class natives : INatives
    {
    }
}