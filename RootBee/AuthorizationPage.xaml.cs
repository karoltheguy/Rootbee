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

namespace RootBee
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuthorizationPage : Page
    {
        EcobeeAPIPin pin = new EcobeeAPIPin();
        EcobeeTokenRefresh token = new EcobeeTokenRefresh();
        AppAuthorization auth = new AppAuthorization();
        DispatcherTimer pinTimer = new DispatcherTimer();
        DispatcherTimer authTimer = new DispatcherTimer();

        public AuthorizationPage()
        {
            this.InitializeComponent();

            pinTimer.Interval = new TimeSpan(0,9,0);
            pinTimer.Tick += PinTimer_Tick;

            authTimer.Interval = new TimeSpan(0, 0, 3);
            authTimer.Tick += AuthTimer_Tick;
        }

        private async void PinButton_Click(object sender, RoutedEventArgs e)
        {
            pin = await auth.GetPinAsync();

            if (!string.IsNullOrEmpty(pin.ecobeePin))
            {
                PinTextBox.Text = pin.ecobeePin;
                pinTimer.Start();
                authTimer.Start();
            }
            else
            {
                ErrorTextBox.Text = pin.error_description;
            }
        }

        private async void AuthTimer_Tick(object sender, object e)
        {
            authTimer.Stop();
            token = await auth.GetNewTokenAsync();

            if (!string.IsNullOrEmpty(token.access_token))
            {
                new CredentialStorage().CreateCredentialInLocker(typeof(App).GetTypeInfo().Assembly.FullName, token.access_token, token.refresh_token);
                this.Frame.Navigate(typeof(MainPage));
            }
            else authTimer.Start();
        }

        private void PinTimer_Tick(object sender, object e)
        {
            authTimer.Stop();
            pinTimer.Stop();
            ErrorTextBox.Text = "Time has elapsed, click on Get Pin to get a new PIN.";
        }

    }
}
