using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using EcobeeLibUWP.Protocol.Thermostat;
using System.Threading.Tasks;

namespace RootBee
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Client client;
        public MainPage()
        {
            this.InitializeComponent();
            client = ((App)App.Current).client;
            GetCurrentTemp();
        }

        private async Task GetCurrentTemp()
        {
            var request = new ThermostatRequest
            {
                Selection = new EcobeeLibUWP.Protocol.Objects.Selection
                {
                    SelectionType = "registered",
                    IncludeRuntime = true
                }
            };

            var response = await client.GetAsync<ThermostatRequest, ThermostatResponse>(request);

            int celciusTemp = (response.ThermostatList[0].Runtime.ActualTemperature - 320) * 5 / 90;
            CurrentTempTextBlock.Text = celciusTemp.ToString();
        }
    }
}
