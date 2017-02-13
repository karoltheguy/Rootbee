using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using Windows.Security.Credentials;

namespace RootBee
{
    public class AppAuthorization
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://api.ecobee.com/") };
        string APP_KEY = "6DUypFBjrvA5HshRS96Q6anmkbvPZRog";
        string SCOPE = "smartWrite";

        public async Task<EcobeeAPIPin> GetPinAsync()
        {
            string json = await GetAPIFromSite(string.Format("authorize?response_type=ecobeePin&client_id={0}&scope={1}", APP_KEY, SCOPE));

            EcobeeAPIPin pin = JsonConvert.DeserializeObject<EcobeeAPIPin>(json);
            Debug.WriteLine(json);

            return pin;
        }

        async Task<string> GetAPIFromSite(string path)
        {
            String stringResponse = string.Empty;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                stringResponse = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(stringResponse);
            }
            return stringResponse;
        }

        public async Task<EcobeeTokenRefresh> GetNewTokenAsync()
        {
            var assemblyName = typeof(App).GetTypeInfo().Assembly.FullName;
            string[] passArray = new CredentialStorage().GetCredentialFromLocker(assemblyName);

            string json = await GetAPIFromSite(string.Format("token?grant_type=refresh_token&refresh_token={0}&client_id={1}", passArray[1], APP_KEY));
            EcobeeTokenRefresh token = JsonConvert.DeserializeObject<EcobeeTokenRefresh>(json);
            return token;
        }
    }
}
