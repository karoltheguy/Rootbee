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
using System.Net.Http.Headers;

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

        //async Task<string> PostAPIFromSite(string uri, string code)
        //{
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", code);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

        //    var formContent = new FormUrlEncodedContent(new[]
        //    {
        //        new KeyValuePair<string, string>("grant_type", "ecobeePin"),
        //        new KeyValuePair<string, string>("code", code),
        //        new KeyValuePair<string, string>("client_id", APP_KEY)
        //    });
        //    HttpContent body = new StringContent("token?grant_type=ecobeePin&code=s1P1AlXcMxqW0I74jhPALlUl24Q1K0rl&client_id=6DUypFBjrvA5HshRS96Q6anmkbvPZRog");
        //    body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    var response = await client.PostAsync(uri, body);
        //    return await response.Content.ReadAsStringAsync();
        //}

        //public async Task<EcobeeTokenRefresh> GetNewTokenAsync()
        //{
        //    var assemblyName = typeof(App).GetTypeInfo().Assembly.FullName;
        //    string[] passArray = new CredentialStorage().GetCredentialFromLocker(assemblyName);

        //    var response = await client.PostAsync(string.Format("token?grant_type=ecobeePin&code={0}&client_id={1}", passArray[1], APP_KEY), null);
        //    string json = await response.Content.ReadAsStringAsync();
        //    Debug.WriteLine(json);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        return JsonConvert.DeserializeObject<EcobeeTokenRefresh>(json);

        //    else throw new ApiException(JsonConvert.DeserializeObject<EcobeeError>(json));

        //    //string json = await GetAPIFromSite(string.Format("token?grant_type=refresh_token&refresh_token={0}&client_id={1}", passArray[1], APP_KEY));
        //    //EcobeeTokenRefresh token = JsonConvert.DeserializeObject<EcobeeTokenRefresh>(json)?? new EcobeeTokenRefresh();
        //    //return token;
        //}

        /// <summary>
        /// Returns new combo of Auth and Refresh tokens
        /// </summary>
        /// <param name="refreshToken">coming from saved credential</param>
        /// <returns></returns>
        public async Task<EcobeeTokenRefresh> GetTokenRefreshAsync(string refreshToken)
        {
            var response = await client.PostAsync(string.Format("token?grant_type=refresh_token&refresh_token={0}&client_id={1}", refreshToken, APP_KEY), null).ConfigureAwait(false);
            string json = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(json);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<EcobeeTokenRefresh>(json);

            else throw new ApiException(JsonConvert.DeserializeObject<EcobeeError>(json));
        }

        /// <summary>
        /// Returns first combo Auth and Refresh tokens to save
        /// </summary>
        /// <param name="code">given with PIN</param>
        /// <returns></returns>
        public async Task<EcobeeTokenRefresh> GetVeryFirstTokenAsync(string code)
        {
            var response = await client.PostAsync(string.Format("token?grant_type=ecobeePin&code={0}&client_id={1}", code, APP_KEY), null);
            string json = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(json);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<EcobeeTokenRefresh>(json);
            
            else throw new ApiException(JsonConvert.DeserializeObject<EcobeeError>(json));
        }
    }
}
