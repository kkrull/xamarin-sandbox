using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Cuneiform.Private;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Cuneiform.Droid
{
  // ReSharper disable once UnusedMember.Global
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

      var idpConfig = new AmazonCognitoIdentityProviderConfig
      {
        HttpClientFactory = new AndroidClientFactory(), 
        RegionEndpoint = RegionEndpoint.USEast1
      };
      LoadApplication(new App(idpConfig, new StaticCognitoConfiguration()));
    }
  }
  
  public class AndroidClientFactory : IHttpClientFactory
  {
    public HttpClient CreateHttpClient(IClientConfig clientConfig)
    {
      return new HttpClient();
    }
  }
}