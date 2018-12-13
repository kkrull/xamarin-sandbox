using Xamarin.Forms;

namespace Cuneiform
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();
      MainPage = new CuneiformPage();
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