using Amazon.CognitoIdentityProvider;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Cuneiform
{
  public partial class App : Application
  {
    public App(AmazonCognitoIdentityProviderConfig idpConfig, IConfigureCognito cognitoConfig)
    {
      InitializeComponent();
      var viewModel = new LoginViewModel(idpConfig, cognitoConfig);
      MainPage = new MainPage { BindingContext = viewModel };
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