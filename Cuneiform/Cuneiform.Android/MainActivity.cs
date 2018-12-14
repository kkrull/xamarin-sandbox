﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Cuneiform.Droid
{
  [Activity(
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
    Icon = "@mipmap/icon",
    Label = "Cuneiform",
    MainLauncher = true,
    Theme = "@style/MainTheme"
  )]
  public class MainActivity : FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(savedInstanceState);
      Forms.Init(this, savedInstanceState);
      LoadApplication(new App());
    }
  }
}