using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using EcobeeLibUWP;
using EcobeeLibUWP.Messages;
using Windows.ApplicationModel.Resources;

namespace RootBee
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuthorizationPage : Page
    {
        //EcobeeAPIPin pin = new EcobeeAPIPin();
        Pin pin = new Pin();
        AuthToken token = new AuthToken();

        //EcobeeTokenRefresh token = new EcobeeTokenRefresh();
        //AppAuthorization auth = new AppAuthorization();

        ResourceLoader resources = new Windows.ApplicationModel.Resources.ResourceLoader();
        string AppKey = string.Empty;

        DispatcherTimer pinTimer = new DispatcherTimer();
        DispatcherTimer authTimer = new DispatcherTimer();

        public AuthorizationPage()
        {
            this.InitializeComponent();
            AppKey = resources.GetString("AppKey");

            pinTimer.Interval = new TimeSpan(0,9,0);
            pinTimer.Tick += PinTimer_Tick;

            authTimer.Interval = new TimeSpan(0, 0, 31);
            authTimer.Tick += AuthTimer_Tick;
        }

        private async void PinButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pin = await Client.GetPin(AppKey);
                //pin = await auth.GetPinAsync();
                PinTextBox.Text = pin.EcobeePin;
                RemainingTimeTextBlock.Visibility = Visibility.Visible;
                RemainingTimeTextBlock.Text = string.Format("You have {0} minutes to use the PIN.", pin.ExpiresIn);
                pinTimer.Start();
                authTimer.Start();
            }
            catch (ApiException ex)
            {
                ErrorTextBox.Text = ex.ErrorMessage.error_description;
            }
            
            
        }

        private async void AuthTimer_Tick(object sender, object e)
        {
            authTimer.Stop();

            try
            {
                token = await Client.GetAccessToken(AppKey, pin.Code);
                //token = await auth.GetVeryFirstTokenAsync(pin.Code);
                CredentialStorage.CreateCredentialInLocker(typeof(App).GetTypeInfo().Assembly.FullName, token.AccessToken, token.RefreshToken);
                this.Frame.Navigate(typeof(MainPage));
            }
            catch (ApiException ex)
            {
                ErrorTextBox.Text = ex.ErrorMessage.error_description;

                if (ex.ErrorMessage.error.Contains("authorization_pending"))
                    authTimer.Start();
            }
        }

        private void PinTimer_Tick(object sender, object e)
        {
            authTimer.Stop();
            pinTimer.Stop();
            ErrorTextBox.Text = "Time has elapsed, click on Get Pin to get a new PIN.";
        }

    }
}
