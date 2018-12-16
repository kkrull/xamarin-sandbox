using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cuneiform
{
  public class LoginViewModel : INotifyPropertyChanged
  {
    private string _message;

    public LoginViewModel()
    {
      Password = "";
      Message = "Please enter your credentials";
      SignInCommand = new Command(() => { Message = "Signing in..."; });
    }

    public string Password { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public string Message
    {
      get => _message;
      set
      {
        _message = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Message"));
      }
    }

    public string Username { get; set; }

    public ICommand SignInCommand { get; }
  }
}