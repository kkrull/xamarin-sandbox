using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cuneiform
{
  public class LoginViewModel : INotifyPropertyChanged
  {
    private readonly AmazonCognitoIdentityProviderConfig _idpConfig;
    private readonly IConfigureCognito _cognitoConfig;

    public LoginViewModel(AmazonCognitoIdentityProviderConfig idpConfig, IConfigureCognito cognitoConfig)
    {
      _idpConfig = idpConfig;
      _cognitoConfig = cognitoConfig;
      
      Message = "Please enter your credentials";
      Password = "";
      SignInCommand = new Command(OnSignIn);
    }

    private string _accessTokenPrefix;
    public string AccessTokenPrefix
    {
      get => _accessTokenPrefix;
      protected set
      {
        _accessTokenPrefix = value.Substring(0, 12);
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AccessTokenPrefix"));
      }
    }

    private string _message;
    public string Message
    {
      get => _message;
      set
      {
        _message = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Message"));
      }
    }

    public string Password { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public string Username { get; set; }

    public ICommand SignInCommand { get; }

    private async void OnSignIn()
    {
      Message = "Signing in...";

      var userName = Username?.Trim().ToLower();
      var password = Password?.Trim();
      try
      {
        //TODO KDK: Login challenge and other types of challenges.
        using (var client = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), _idpConfig))
        {
          var userPool = new CognitoUserPool(_cognitoConfig.UserPoolId, _cognitoConfig.ClientId, client);
          var user = new CognitoUser(userName, _cognitoConfig.ClientId, userPool, client);
          AuthFlowResponse context = await user.StartWithSrpAuthAsync(new InitiateSrpAuthRequest
          {
            Password = password
          }).ConfigureAwait(false);
          
          Message = "Signed in!";
          AccessTokenPrefix = context.AuthenticationResult.AccessToken;
        }
      }
      catch (NotAuthorizedException)
      {
        Message = "Not Authorized";
      }
      catch (UserNotFoundException)
      {
        Message = "User not found";
      }
      catch (UserNotConfirmedException)
      {
        Message = "User not confirmed";
      }
      catch (Exception e)
      {
        Message = e.Message;
      }
    }
  }
}