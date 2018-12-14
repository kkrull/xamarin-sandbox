using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Cuneiform.iOS
{
  //Launches the user interface and listens for application events from iOS.
  [Register("AppDelegate")]
  public partial class AppDelegate : FormsApplicationDelegate
  {
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
      Forms.Init();
      LoadApplication(new App());
      return base.FinishedLaunching(app, options);
    }
  }
}