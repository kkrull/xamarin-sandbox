using System.Net.Http;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
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

      var application = new App(new AmazonCognitoIdentityProviderConfig
      {
        HttpClientFactory = new IOSClientFactory(), 
        RegionEndpoint = RegionEndpoint.USEast1
      });
      
      LoadApplication(application);
      return base.FinishedLaunching(app, options);
    }
  }
  
  public class IOSClientFactory : IHttpClientFactory
  {
    public HttpClient CreateHttpClient(IClientConfig clientConfig)
    {
      return new HttpClient();
    }
  }
}