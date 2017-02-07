using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RootBee
{
    public class AppAuthorization
    {
        static HttpClient client = new HttpClient();
        string APP_KEY = "6DUypFBjrvA5HshRS96Q6anmkbvPZRog";
        string SCOPE = "smartWrite";

        public async Task GetPinAsync()
        {
            client.BaseAddress = new Uri("https://api.ecobee.com/");

            string json = await GetPinSite(string.Format("authorize?response_type=ecobeePin&client_id={0}&scope={1}", APP_KEY, SCOPE));

            EcobeeAuthModel pin = JsonConvert.DeserializeObject<EcobeeAuthModel>(json);
            Debug.WriteLine(json);
        }

        async Task<string> GetPinSite(string path)
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
