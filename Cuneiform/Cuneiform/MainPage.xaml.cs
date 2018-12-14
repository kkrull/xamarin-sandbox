using System;
using Xamarin.Forms;

namespace Cuneiform
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
    }

    private void OnAcknowledgement(object sender, EventArgs e)
    {
      ((Button) sender).Text = $"You clicked a button! Go you.";
    }
  }
}