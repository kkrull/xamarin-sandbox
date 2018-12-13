using System;
using Foundation;
using UIKit;

namespace Phoneword_iOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            string translatedNumber = "";

            TranslateButton.TouchUpInside += (object sender, EventArgs e) => {
                translatedNumber = PhoneTranslator.ToNumber(PhoneNumberText.Text);
                DismissKeyboard();
                if (translatedNumber == "")
                {
                    CallButton.SetTitle("Call", UIControlState.Normal);
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
                    CallButton.Enabled = true;
                }
            };

            CallButton.TouchUpInside += (object sender, EventArgs e) => {
                var url = PhoneAppUrl(translatedNumber);
                if (!UIApplication.SharedApplication.OpenUrl(url))
                {
                    var alert = PhoneNotSupported();
                    PresentViewController(alert, true, null);
                }
            };
        }

        void DismissKeyboard()
        {
            PhoneNumberText.ResignFirstResponder();
        }

        NSUrl PhoneAppUrl(string translatedNumber)
        {
            return new NSUrl("tel:" + translatedNumber);
        }

        UIAlertController PhoneNotSupported()
        {
            UIAlertController alert = UIAlertController.Create(
                "Not supported", 
                "Scheme 'tel:' is not supported on this device", 
                UIAlertControllerStyle.Alert
            );
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            return alert;
        }
    }
}
