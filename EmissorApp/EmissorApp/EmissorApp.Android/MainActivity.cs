﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Util;

namespace EmissorApp.Droid
{
    [Activity(Label = "Move Online", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static float at;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            try
            {
                at = (float)Resources.DisplayMetrics.Density;
            }
            catch { at = 1; }

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
     
    }
}

