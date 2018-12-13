using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Cuneiform.Droid
{
  // ReSharper disable once UnusedMember.Global
  [Activity(
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
    Icon = "@drawable/icon",
    Label = "Cuneiform.Droid",
    MainLauncher = true,
    Theme = "@style/MyTheme")]
  public class MainActivity : FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle bundle)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);
      Forms.Init(this, bundle);
      LoadApplication(new App());
    }
  }
}