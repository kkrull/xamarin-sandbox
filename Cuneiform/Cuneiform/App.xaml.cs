using Amazon.CognitoIdentityProvider;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Cuneiform
{
  public partial class App : Application
  {
    public App(AmazonCognitoIdentityProviderConfig idpConfig)
    {
      InitializeComponent();
      MainPage = new MainPage(idpConfig);
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}