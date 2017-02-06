using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class MainPage : Page
    {
        static HttpClient client = new HttpClient();
        string APP_KEY = "";
        string SCOPE = "smartWrite";

        public MainPage()
        {
            this.InitializeComponent();
            GetPinAsync();
        }

        private async Task GetPinAsync()
        {
            client.BaseAddress = new Uri("https://api.ecobee.com/");
            //authorize?response_type=ecobeePin&client_id=APP_KEY&scope=SCOPE
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string something = await GetProductAsync(string.Format("authorize?response_type=ecobeePin&client_id={0}&scope={1}", APP_KEY, SCOPE));
            Debug.WriteLine(something);
        }

        async Task<string> GetProductAsync(string path)
        {
            String stringResponse = string.Empty;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                stringResponse = await response.Content.ReadAsStringAsync();
            }
            return stringResponse;
        }
    }
}
