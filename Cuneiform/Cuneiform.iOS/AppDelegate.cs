using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Cuneiform.iOS
{
  // ReSharper disable once UnusedMember.Global
  [Register("AppDelegate")]
  public class AppDelegate : FormsApplicationDelegate
  {
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
      Forms.Init();
      LoadApplication(new App());
      return base.FinishedLaunching(app, options);
    }
  }
}