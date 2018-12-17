using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
using Cuneiform.Private;
using Foundation;
using System.Net.Http;
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

      var idpConfig = new AmazonCognitoIdentityProviderConfig
      {
        HttpClientFactory = new IOSClientFactory(), 
        RegionEndpoint = RegionEndpoint.USEast1
      };
      LoadApplication(new App(idpConfig, new StaticCognitoConfiguration()));
      
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