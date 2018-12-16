using Amazon.CognitoIdentityProvider;
using Xamarin.Forms;

namespace Cuneiform
{
  public partial class MainPage : ContentPage
  {
    private readonly AmazonCognitoIdentityProviderConfig _idpConfig;

    public MainPage(AmazonCognitoIdentityProviderConfig idpConfig)
    {
      _idpConfig = idpConfig;
      InitializeComponent();
    }
  }
}